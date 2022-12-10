using System.Reflection;
using System.Resources;

namespace Behlog.Web.Resources;

public static class IdentityErrorManager
{
    private static readonly ResourceManager _resource = 
        new ResourceManager("Behlog.Web.Resources.BehlogIdentityErrors", Assembly.GetExecutingAssembly());

    public static string Get(string errorCode)
    {
        return _resource.GetString(errorCode);
    }
}