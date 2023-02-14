using Behlog.Cms.Domain;

namespace Behlog.Web.Models;

public class CommentViewModel
{
    public string? Title { get; protected set; }
    public string Body { get; protected set; }
    public ContentBodyType BodyType { get; protected set; }
    public CommentStatusEnum Status { get; protected set; }
    public string? Email { get; protected set; }
    public string? WebUrl { get; protected set; }
    public string? AuthorUserId { get; protected set; }
    public string? AuthorName { get; protected set; }
    public Guid ContentId { get; protected set; }
    public DateTime CreatedDate { get; protected set; }
    public DateTime? LastUpdated { get; protected set; }
    public DateTime? LastStatusChangedOn { get; protected set; }
    public string? CreatedByUserId { get; protected set; }
    public string? LastUpdatedByUserId { get; protected set; }
    public string? CreatedByIp { get; protected set; }
    public string? LastUpdatedByIp { get; protected set; }
}