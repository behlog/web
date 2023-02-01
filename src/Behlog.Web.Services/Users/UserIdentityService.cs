namespace Behlog.Web.Services;


public class UserIdentityService : IUserIdentityService
{
    private readonly IIdyfaUserManager _userManager;
    private readonly IIdyfaAuthManager _auth;


    public UserIdentityService(IIdyfaUserManager userManager, IIdyfaAuthManager auth)
    {
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        _auth = auth ?? throw new ArgumentNullException(nameof(auth));
        _auth.AfterSignInEvent += OnAfterSignIn;
    }
    
    
    public async Task<CommandResult> LoginAsync(
        UserLoginModel model, CancellationToken cancellationToken = default)
    {
        model.ThrowExceptionIfArgumentIsNull(nameof(model));
        
        try
        {
            await _auth.AuthenticateAsync(
                model.UserName, model.Password, model.RememberMe, cancellationToken
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

    
    public async Task<CommandResult> RegisterUserAsync(
        RegisterUserModel model, CancellationToken cancellationToken = default)
    {
        model.ThrowExceptionIfArgumentIsNull(nameof(model));
        
        var user = User.New()
            .WithUserName(model.UserName)
            .WithEmail(model.Email)
            .WithFirstName(model.FirstName)
            .WithLastName(model.LastName)
            .WithDisplayName(model.DisplayName)
            .WithPhoneNumber(model.PhoneNumber);

        var result = await _userManager.CreateAsync(user, model.Password).ConfigureAwait(false);
        if (!result.Succeeded)
        {
            return CommandResult.Failed(result.Errors.ToValidationErrors());
        }

        return CommandResult.Success();
    }


    #region private helpers

    private void OnAfterSignIn(AfterSignInEventArgs args)
    {
        var loggedInUserName = args.UserName;
        
    }

    #endregion
}