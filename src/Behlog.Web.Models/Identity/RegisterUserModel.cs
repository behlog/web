using System.ComponentModel.DataAnnotations;
using Behlog.Core;
using Behlog.Core.Models;

namespace Behlog.Web.Models.Identity;


public class RegisterUserCommand : BaseViewModel, IBehlogCommand<RegisterUserCommand>
{
    [Required()]
    [MaxLength(256)]
    public string UserName { get; set; }
    
    [DataType(DataType.Password)]
    public string? Password { get; set; }
    
    [EmailAddress]
    [MaxLength(1000)]
    public string? Email { get; set; }
    
    [MaxLength(256)]
    public string? FirstName { get; set; }
    
    [MaxLength(256)]
    public string? LastName { get; set; }
    
    [MaxLength(500)]
    public string? DisplayName { get; set; }
    
    [MaxLength(20)]
    public string? PhoneNumber { get; set; }
    
}