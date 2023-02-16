namespace Behlog.Web.Models;


public class UserLoginModel : BaseViewModel
{
    [Required(ErrorMessageResourceType = typeof(BehlogIdentityErrors), ErrorMessageResourceName = "signin_username_req")]
    [MaxLength(256, ErrorMessageResourceType = typeof(ViewModelString), ErrorMessageResourceName = "MaxLen")]
    public string UserName { get; set; }
    
    [Required(ErrorMessageResourceType = typeof(BehlogIdentityErrors), ErrorMessageResourceName = "signin_password_req")]
    public string Password { get; set; }
    
    public bool RememberMe { get; set; }
    
    public string? ReturnUrl { get; set; }
}


public class LoginUserCommand : IBehlogCommand<CommandResult>
{
    public LoginUserCommand(
        string userName, string password, bool rememberMe)
    {
        UserName = userName;
        Password = password;
        RememberMe = rememberMe;
    }
    
    public string UserName { get; }
    public string Password { get; }
    public bool RememberMe { get; }
    public bool RequireTwoFactorAuthentication { get; }
}