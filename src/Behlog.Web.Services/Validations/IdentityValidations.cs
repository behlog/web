using Behlog.Core.Validations;
using Behlog.Web.Resources;

namespace Behlog.Web.Services.Validations;

public static class IdentityValidations
{
    
    public static ValidationError InvalidUserName 
        => ValidationError.Create(
            "UserName", IdentityErrorCodes.InvalidUserName, 
            IdentityErrorManager.Get(IdentityErrorCodes.InvalidUserName)
            );

    public static ValidationError UserLocked
        => ValidationError.Create(IdentityErrorManager.Get(IdentityErrorCodes.UserStatusLocked))
            .WithErrorCode(IdentityErrorCodes.UserStatusLocked);

    public static ValidationError UserBlocked
        => ValidationError.Create(IdentityErrorManager.Get(IdentityErrorCodes.UserStatusBlocked))
            .WithErrorCode(IdentityErrorCodes.UserStatusBlocked);

    public static ValidationError UserDisabled
        => ValidationError.Create(IdentityErrorManager.Get(IdentityErrorCodes.UserStatusNotEnabled))
            .WithErrorCode(IdentityErrorCodes.UserStatusNotEnabled);

    public static ValidationError DeletedUser
        => ValidationError.Create(IdentityErrorManager.Get(IdentityErrorCodes.UserStatusDeleted))
            .WithErrorCode(IdentityErrorCodes.UserStatusDeleted);

    public static ValidationError InvalidUserStatus
        => ValidationError.Create(IdentityErrorManager.Get(IdentityErrorCodes.UserStatusInvalid))
            .WithErrorCode(IdentityErrorCodes.UserStatusInvalid);

    public static ValidationError SignInRequireTwoFactor
        => ValidationError.Create(IdentityErrorManager.Get(IdentityErrorCodes.SignInRequireTwoFactor))
            .WithErrorCode(IdentityErrorCodes.SignInRequireTwoFactor);
}