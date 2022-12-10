using Behlog.Core.Validations;
using Microsoft.AspNetCore.Identity;

namespace Behlog.Web.Services.Extensions;

public static class CommandExts
{

    public static IEnumerable<ValidationError> ToValidationErrors(this IEnumerable<IdentityError> errors)
    {
        if (errors is null) return null;
        if (!errors.Any()) return new List<ValidationError>();
        
        var result = new List<ValidationError>();
        foreach (var err in errors)
        {
            result.Add(ValidationError.Create(err.Code, err.Description));
        }
        
        return result;
    }
}