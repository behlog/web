using Behlog.Core;
using Behlog.Extensions;
using Behlog.Web.Models;
using Behlog.Web.Models.Identity;
using Idyfa.Core;
using Idyfa.Core.Contracts;
using Idyfa.Core.Extensions;

namespace Behlog.Web.Services;


public class UserIdentityCommandHandler : 
    IBehlogCommandHandler<RegisterUserCommand, RegisterUserCommand>,
    IBehlogCommandHandler<LoginUserCommand, LoginUserCommand>
{
    private readonly IIdyfaUserManager _userManager;
    private readonly IIdyfaSignInManager _signInManager;

    public UserIdentityCommandHandler(
        IIdyfaUserManager userManager, IIdyfaSignInManager signInManager)
    {
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
    }

    
    public async Task<RegisterUserCommand> HandleAsync(
        RegisterUserCommand command, CancellationToken cancellationToken = default)
    {
        command.ThrowExceptionIfArgumentIsNull(nameof(command));
        if (command.HasError)
        {
            return command;
        }


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
            command.AddError(result.ToString());
            return command;
        }

        command.Succeed();
        return command;
    }

    public async Task<LoginUserCommand> HandleAsync(
        LoginUserCommand command, CancellationToken cancellationToken = default)
    {
        command.ThrowExceptionIfArgumentIsNull(nameof(command));
        if (command.HasError)
        {
            return command;
        }
        
    }
}