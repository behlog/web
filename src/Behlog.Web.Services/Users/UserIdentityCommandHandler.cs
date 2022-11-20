using Behlog.Core;
using Behlog.Extensions;
using Behlog.Web.Models;
using Behlog.Web.Models.Identity;
using Idyfa.Core;
using Idyfa.Core.Contracts;

namespace Behlog.Web.Services;


public class UserIdentityCommandHandler : 
    IBehlogCommandHandler<RegisterUserCommand, RegisterUserCommand>
{
    private readonly IIdyfaUserManager _userManager;

    public UserIdentityCommandHandler(
        IIdyfaUserManager userManager)
    {
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
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
            command.AddError("The user creation has error", "");
            return command;
        }

        command.Succeed();
        return command;
    }
}