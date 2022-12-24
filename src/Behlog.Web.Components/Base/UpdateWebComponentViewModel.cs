using System.ComponentModel.DataAnnotations;
using Behlog.Cms.Commands;
using Behlog.Core.Models;
using Behlog.Web.Resources;

namespace Behlog.Web.Components.Base;

public abstract class UpdateWebComponentViewModel : BaseViewModel
{
    public UpdateWebComponentViewModel()
    {
        Meta = new List<MetaCommand>();
        Files = new List<ComponentFileCommand>();
    }
    
    [Required(ErrorMessageResourceType = typeof(ViewModelString), ErrorMessageResourceName = "Required")]
    [MaxLength(256, ErrorMessageResourceType = typeof(ViewModelString), ErrorMessageResourceName = "MaxLen")]
    public string Name { get; set; }
    
    
    [Required(ErrorMessageResourceType = typeof(ViewModelString), ErrorMessageResourceName = "Required")]
    [MaxLength(256, ErrorMessageResourceType = typeof(ViewModelString), ErrorMessageResourceName = "MaxLen")]
    public string Title { get; set; }
    
    public Guid LangId { get; set; }
    
    public Guid WebsiteId { get; set; }
    
    public bool IsRtl { get; set; }
    
    public string? ViewPath { get; set; }
    
    public string? Description { get; set; }

    public Guid? ParentId { get; set; }
    
    public IList<MetaCommand> Meta { get; set; }
    
    public IList<ComponentFileCommand> Files { get; set; }
}