namespace Behlog.Web.Models.Identity;

public class RegisterUserModel : BaseViewModel
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


public class RegisterUserCommand : IBehlogCommand<CommandResult>
{
    public RegisterUserCommand()
    {
    }
    
    public RegisterUserCommand(string userName)
    {
        UserName = userName;
    }
    
    public string UserName { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? DisplayName { get; set; }
    public string? PhoneNumber { get; set; }
}