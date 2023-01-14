using Behlog.Web.Components.Base;

namespace Behlog.Web.Components;

public interface IImageSliderComponent 
    : IBehlogWebComponent<UpdateImageSliderViewModel, ImageSliderViewModel, ICollection<ImageSliderItemViewModel>>
{
}