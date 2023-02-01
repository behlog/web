using System.Linq;
using Behlog.Core.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Behlog.Web.Extensions;


public static class Convertors
{

    public static SelectList ToSelectList(this SelectListViewModel model)
    {
        if (model is null)
            throw new ArgumentNullException(nameof(model));

        if (!model.Items.Any()) return null;

        return new SelectList(model.Items.Select(_ => _.ToSelectListItem()).ToList());
    }

    public static SelectListItem ToSelectListItem(this SelectListItemViewModel item)
    {
        if (item is null)
            throw new ArgumentNullException(nameof(item));

        return new SelectListItem(item.Text, item.Value, item.Selected, item.Disabled);
    }
}