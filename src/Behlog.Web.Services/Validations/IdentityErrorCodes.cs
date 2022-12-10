namespace Behlog.Web.Services.Validations;

public static class IdentityErrorCodes
{
    public static string InvalidUserName = "username.invalid";
    public static string UserStatusLocked = "user.status.locked";
    public static string UserStatusBlocked = "user.status.blocked";
    public static string UserStatusNotEnabled = "user.status.not.enabled";
    public static string UserStatusDeleted = "user.status.deleted";
    public static string UserStatusInvalid = "user.status.invalid";
    public static string SignInRequireTwoFactor = "signin.2factor.required";
}