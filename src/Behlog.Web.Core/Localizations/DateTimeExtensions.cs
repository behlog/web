using Behlog.Cms;
using Behlog.Cms.Domain;
using Behlog.Core;
using Behlog.Extensions;
using Language = Behlog.Cms.Domain.Language;

namespace Behlog.Web.Core.Localizations;

public static class DateTimeExtensions
{

    public static string ToLocalDisplay(this DateTime date, Language language)
    {
        language.ThrowExceptionIfArgumentIsNull(nameof(language));
        if (language.Code == PersianLanguage.Code)
        {
            return date.ToPersianDateTimeText();
        }
        
        return date.ToLongTimeString();
    }


    public static string ToLocalDisplay(this DateTime date, Guid langId)
    {
        langId.ThrowIfGuidIsEmpty(new BehlogInvalidEntityIdException(nameof(Language)));

        if (langId == PersianLanguage.Id)
        {
            return date.ToPersianDateTimeText();
        }

        return date.ToLocalTime().ToLongTimeString();
    }

    public static string ToLocalDisplay(this DateTime date, string langCode)
    {
        if (langCode.IsNullOrEmptySpace())
            throw new ArgumentNullException(nameof(langCode));

        if (langCode.ToUpper() == PersianLanguage.Code.ToUpper())
        {
            return date.ToPersianDateTimeText();
        }

        return date.ToLocalTime().ToLongTimeString();
    }
    
    
    
}