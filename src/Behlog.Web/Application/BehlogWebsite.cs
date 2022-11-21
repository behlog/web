namespace Behlog.Web.Application;

public class BehlogWebsite
{
    public BehlogWebsite()
    {
    }
    
    public Guid Id { get; }
    
    public string Theme { get; private set; }

    public static BehlogWebsiteAreaNames Areas => new();

    public void SetTheme(string theme)
    {
        Theme = theme;
    }
}


public class BehlogWebsiteAreaNames
{

    public const string Identity = nameof(Identity);

}