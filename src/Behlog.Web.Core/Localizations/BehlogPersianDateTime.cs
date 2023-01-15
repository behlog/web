using DNTPersianUtils.Core;

namespace Behlog.Web.Core.Localizations;

public static class BehlogPersianDateTime
{

    public static string ToFriendlyPersianDateTime(this DateTime dateTime)
    {
        return dateTime.ToLocalTime().ToFriendlyPersianDateTextify(appendHhMm: true);
    }

    public static string ToFriendlyPersianDate(this DateTime dateTime)
    {
        return dateTime.ToLocalTime().ToFriendlyPersianDateTextify(includePersianDate: true);
    }

    public static string ToPersianDateText(this DateTime dateTime)
    {
        return dateTime.ToLocalTime().ToPersianDateTextify();
    }

    public static string ToPersianDateTimeText(this DateTime dateTime)
    {
        return dateTime.ToLocalTime().ToLongPersianDateTimeString();
    }

    public static string ToPersianDateShort(this DateTime dateTime)
    {
        return dateTime.ToLocalTime().ToShortPersianDateString();
    }
    
}