namespace Behlog.Web.Models;


public class LoginUserCommand : BaseViewModel, IBehlogCommand<LoginUserCommand>
{
    
    [Required]
    public string UserName { get; set; }
    
    [Required]
    public string Password { get; set; }
    
    public bool RememberMe { get; set; }
    
    public bool RequireTwoFactorAuthentication { get; set; }
}