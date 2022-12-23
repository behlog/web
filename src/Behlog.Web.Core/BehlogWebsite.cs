namespace Behlog.Web.Core;

public class BehlogWebsite
{
    public BehlogWebsite()
    {
    }
    
    public Guid Id { get; private set; }
    public string TemplateName { get; private set; }
    public string Name { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public string Keywords { get; private set; }
    public string Url { get; private set; }
    public string OwnerUserId { get; private set; }
    public Guid DefaultLangId { get; private set; }
    public bool IsReadOnly { get; private set; }
    public string Email { get; private set; }
    public string CopyrightText { get; private set; }

    public static WebsiteAreaNames Areas => new();

    public BehlogWebsite WithTheme(string templateName)
    {
        TemplateName = templateName;
        return this;
    }

    public BehlogWebsite WithId(Guid id) {
        Id = id;
        return this;
    }

    public BehlogWebsite WithName(string name) {
        Name = name;
        return this;
    }

    public BehlogWebsite WithTitle(string title) {
        Title = title;
        return this;
    }

    public BehlogWebsite WithDescription(string description) {
        Description = description;
        return this;
    }

    public BehlogWebsite WithKeywords(string keywords) {
        Keywords = keywords;
        return this;
    }

    public BehlogWebsite WithUrl(string url) {
        Url = url;
        return this;
    }

    public BehlogWebsite WithOwnerUserId(string ownerUserId) {
        OwnerUserId = ownerUserId;
        return this;
    }

    public BehlogWebsite WithDefaultLangId(Guid defaultLangId) {
        DefaultLangId = defaultLangId;
        return this;
    }

    public BehlogWebsite ReadOnly(bool isReadOnly = true) {
        IsReadOnly = isReadOnly;
        return this;
    }

    public BehlogWebsite WithEmail(string email) {
        Email = email;
        return this;
    }

    public BehlogWebsite WithCopyrightText(string copyrightText) {
        CopyrightText = copyrightText;
        return this;
    }

}
