using Behlog.Cms.Domain;

namespace Behlog.Web.Models;


public class ContentViewModel
{
    public Guid Id { get; }
    public string Title { get; }
    public string Slug { get; }
    public Guid ContentTypeId { get; }
    public string ContentTypeTitle { get; }
    public string ContentTypeSlug { get; }
    public string Body { get; }
    public ContentBodyType BodyType { get; }
    public string AuthorUserId { get; }
    public string Summary { get; }
    public ContentStatus Status { get; }
    public string AltTitle { get; }
    public int OrderNum { get; }
}