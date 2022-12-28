namespace Behlog.Web.Services.Contracts;

public interface IUserIdentityService
{

    Task<CommandResult> LoginAsync(
        LoginUserModel model, CancellationToken cancellationToken = default);


    Task<CommandResult> RegisterUserAsync(
        RegisterUserModel model, CancellationToken cancellationToken = default);
}