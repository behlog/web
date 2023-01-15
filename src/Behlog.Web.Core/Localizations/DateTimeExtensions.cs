using Behlog.Cms.Domain;
using Behlog.Extensions;
using Language = Behlog.Cms.Domain.Language;

namespace Behlog.Web.Core.Localizations;

public static class DateTimeExtensions
{

    public static string ToLocalDisplay(this DateTime date, Language language)
    {
        language.ThrowExceptionIfArgumentIsNull(nameof(language));

        return "";
    }
}