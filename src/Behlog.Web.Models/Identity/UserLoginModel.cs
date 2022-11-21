using System.ComponentModel.DataAnnotations;
using Behlog.Core;
using Behlog.Core.Models;

namespace Behlog.Web.Models;


public class LoginUserCommand : BaseViewModel, IBehlogCommand<LoginUserCommand>
{
    
    [Required]
    public string UserName { get; set; }
    
    [Required]
    public string Password { get; set; }
    
    public bool RememberMe { get; set; }
}