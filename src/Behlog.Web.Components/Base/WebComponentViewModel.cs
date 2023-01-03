namespace Behlog.Web.Components.Base;

public abstract class WebComponentViewModel<TAttributeType>
{
    
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public Guid WebsiteId { get; set; }
    public Guid LangId { get; set; }
    public string LangCode { get; set; }
    public bool IsRtl { get; set; }
    public Guid? ParentId { get; set; }
    public string? ViewPath { get; set; }
    public string? Description { get; set; }
    
    public TAttributeType Attributes { get; set; }
}