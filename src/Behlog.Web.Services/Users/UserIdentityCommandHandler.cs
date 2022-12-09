//using Behlog.Core;
//using Behlog.Extensions;
//using Behlog.Web.Models;
//using Behlog.Web.Models.Identity;
//using Idyfa.Core;
//using Idyfa.Core.Contracts;
//using Idyfa.Core.Events;
//using Idyfa.Core.Exceptions;
//using Idyfa.Core.Extensions;

//namespace Behlog.Web.Services;


//public class UserIdentityCommandHandler : 
//    IBehlogCommandHandler<RegisterUserCommand, RegisterUserCommand>,
//    IBehlogCommandHandler<LoginUserCommand, LoginUserCommand>
//{
//    private readonly IIdyfaUserManager _userManager;
//    private readonly IIdyfaAuthManager _auth;

//    public UserIdentityCommandHandler(
//        IIdyfaUserManager userManager, IIdyfaAuthManager auth)
//    {
//        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
//        _auth = auth ?? throw new ArgumentNullException(nameof(auth));
//        _auth.AfterSignInEvent += OnAfterSignIn;
//    }

//    private void OnAfterSignIn(AfterSignInEventArgs args)
//    {
//        var loggedInUserName = args.UserName;
        
//    }


//    public async Task<RegisterUserCommand> HandleAsync(
//        RegisterUserCommand command, CancellationToken cancellationToken = default)
//    {
//        command.ThrowExceptionIfArgumentIsNull(nameof(command));
//        if (command.HasError)
//        {
//            return command;
//        }


//        var user = User.New()
//            .WithUserName(command.UserName)
//            .WithEmail(command.Email)
//            .WithFirstName(command.FirstName)
//            .WithLastName(command.LastName)
//            .WithDisplayName(command.DisplayName)
//            .WithPhoneNumber(command.PhoneNumber);

//        var result = await _userManager.CreateAsync(user, command.Password).ConfigureAwait(false);
//        if (!result.Succeeded)
//        {
//            command.AddError(result.ToString());
//            return command;
//        }

//        command.Succeed();
//        return command;
//    }

//    public async Task<LoginUserCommand> HandleAsync(
//        LoginUserCommand command, CancellationToken cancellationToken = default)
//    {
//        command.ThrowExceptionIfArgumentIsNull(nameof(command));
//        if (command.HasError)
//        {
//            return command;
//        }

//        try
//        {
//            await _auth.AuthenticateAsync(
//                command.UserName, command.Password, command.RememberMe, cancellationToken
//            ).ConfigureAwait(false);
//        }
//        catch (InvalidUserNameException ex)
//        {
//            command.AddError($"InvalidUserName : '{ex.Message}'");
//        }
//        catch (IdyfaUserNotFoundException)
//        {
//            command.AddError("User not found.");
//        }
//        catch (InvalidUserStatusForSignInException ex)
//        {
//            command.AddError($"The Status for the user is not valid because the current status is : {ex.UserStatus.ToString()}");
//        }
//        catch (IdyfaSignInRequireTwoFactorAuthenticationException ex)
//        {
//            command.RequireTwoFactorAuthentication = true;
//            return command;
//        }
        
//        if(!command.HasError) command.Succeed();
        
//        return command;
//    }
//}