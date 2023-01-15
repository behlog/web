using Behlog.Cms;
using Behlog.Core;
using Behlog.Cms.Domain;
using Behlog.Extensions;

namespace Behlog.Web.Core.Localizations;

public static class DateTimeExtensions
{

    public static string ToLocalDisplay(this DateTime date, Language language)
    {
        language.ThrowExceptionIfArgumentIsNull(nameof(language));
        if (language.Code.ToUpper() == PersianLanguage.Code.ToUpper())
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
    
    public static string ToFriendlyLocalDisplay(this DateTime date, Language language)
    {
        language.ThrowExceptionIfArgumentIsNull(nameof(language));
        
        if (language.Code.ToUpper() == PersianLanguage.Code.ToUpper())
        {
            return date.ToFriendlyPersianDate();
        }
        
        return date.ToLongTimeString();
    }

    public static string ToFriendlyLocalDisplay(this DateTime date, Guid langId)
    {
        langId.ThrowIfGuidIsEmpty(new BehlogInvalidEntityIdException(nameof(Language)));

        if (langId == PersianLanguage.Id)
        {
            return date.ToFriendlyPersianDate();
        }

        return date.ToLocalTime().ToLongTimeString();
    }
    
    public static string ToFriendlyLocalDisplay(this DateTime date, string langCode)
    {
        if (langCode.IsNullOrEmptySpace())
            throw new ArgumentNullException(nameof(langCode));

        if (langCode.ToUpper() == PersianLanguage.Code.ToUpper())
        {
            return date.ToFriendlyPersianDate();
        }

        return date.ToLocalTime().ToLongTimeString();
    }
    
}