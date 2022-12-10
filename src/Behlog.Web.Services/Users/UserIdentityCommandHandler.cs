using Behlog.Core;
using Behlog.Core.Models;
using Behlog.Extensions;
using Behlog.Web.Models;
using Behlog.Web.Models.Identity;
using Behlog.Web.Services.Extensions;
using Behlog.Web.Services.Validations;
using Idyfa.Core;
using Idyfa.Core.Contracts;
using Idyfa.Core.Events;
using Idyfa.Core.Exceptions;
using Idyfa.Core.Extensions;

namespace Behlog.Web.Services;


public class UserIdentityCommandHandler : 
    IBehlogCommandHandler<RegisterUserCommand, CommandResult>,
    IBehlogCommandHandler<LoginUserCommand, CommandResult>
{
    private readonly IIdyfaUserManager _userManager;
    private readonly IIdyfaAuthManager _auth;

    public UserIdentityCommandHandler(
        IIdyfaUserManager userManager, IIdyfaAuthManager auth)
    {
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        _auth = auth ?? throw new ArgumentNullException(nameof(auth));
        _auth.AfterSignInEvent += OnAfterSignIn;
    }

    private void OnAfterSignIn(AfterSignInEventArgs args)
    {
        var loggedInUserName = args.UserName;
        
    }


    public async Task<CommandResult> HandleAsync(
        RegisterUserCommand command, CancellationToken cancellationToken = default)
    {
        command.ThrowExceptionIfArgumentIsNull(nameof(command));

        var user = User.New()
            .WithUserName(command.UserName)
            .WithEmail(command.Email)
            .WithFirstName(command.FirstName)
            .WithLastName(command.LastName)
            .WithDisplayName(command.DisplayName)
            .WithPhoneNumber(command.PhoneNumber);

        var result = await _userManager.CreateAsync(user, command.Password).ConfigureAwait(false);
        if (!result.Succeeded)
        {
            return CommandResult.Failed(result.Errors.ToValidationErrors());
        }

        return CommandResult.Success();
    }

    public async Task<CommandResult> HandleAsync(
        LoginUserCommand command, CancellationToken cancellationToken = default)
    {
        command.ThrowExceptionIfArgumentIsNull(nameof(command));
        try
        {
            await _auth.AuthenticateAsync(
                command.UserName, command.Password, command.RememberMe, cancellationToken
            ).ConfigureAwait(false);
        }
        catch (InvalidUserNameException ex)
        {
            return CommandResult.Failed(IdentityValidations.InvalidUserName);
        }
        catch (IdyfaUserNotFoundException)
        {
            return CommandResult.Failed(IdentityValidations.InvalidUserName);
        }
        catch (InvalidUserStatusForSignInException ex)
        {
            if (ex.UserStatus == UserStatus.Blocked)
                return CommandResult.Failed(IdentityValidations.UserBlocked);
            if (ex.UserStatus == UserStatus.Created)
                return CommandResult.Failed(IdentityValidations.UserDisabled);
            if (ex.UserStatus == UserStatus.Locked)
                return CommandResult.Failed(IdentityValidations.UserLocked);
            if (ex.UserStatus == UserStatus.Deleted)
                return CommandResult.Failed(IdentityValidations.DeletedUser);

            return CommandResult.Failed(IdentityValidations.InvalidUserStatus);
        }
        catch (IdyfaSignInRequireTwoFactorAuthenticationException ex)
        {
            return CommandResult.Failed(IdentityValidations.SignInRequireTwoFactor);
        }

        return CommandResult.Success();
    }
}