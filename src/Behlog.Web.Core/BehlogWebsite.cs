namespace Behlog.Web.Core;

public class BehlogWebsite
{
    public BehlogWebsite()
    {
    }
    
    public Guid Id { get; }
    
    public string Theme { get; private set; }

    public static WebsiteAreaNames Areas => new();

    public void SetTheme(string theme)
    {
        Theme = theme;
    }
}
