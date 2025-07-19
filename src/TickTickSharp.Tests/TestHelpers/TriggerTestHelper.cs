using Ical.Net.DataTypes;

namespace TickTickSharp.Tests.TestHelpers
{
    public static class TriggerTestHelper
    {
        public static Trigger CreateAtDueTime()
        {
            return new Trigger(new Duration(seconds: 0));
        }

        public static Trigger CreateMinutesBefore(int minutes)
        {
            return new Trigger(new Duration(minutes: -minutes));
        }

        public static Trigger CreateHoursBefore(int hours)
        {
            return new Trigger(new Duration(hours: -hours));
        }

        public static Trigger CreateDaysBefore(int days)
        {
            return new Trigger(new Duration(days: -days));
        }

        public static Trigger CreateWeeksBefore(int weeks)
        {
            return new Trigger(new Duration(weeks: -weeks));
        }

        public static Trigger CreateCustomDuration(int? weeks = null, int? days = null, int? hours = null, int? minutes = null, int? seconds = null)
        {
            return new Trigger(new Duration(weeks, days, hours, minutes, seconds));
        }
    }
}