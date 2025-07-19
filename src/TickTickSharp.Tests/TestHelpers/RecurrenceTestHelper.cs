using Ical.Net.DataTypes;
using Ical.Net;

namespace TickTickSharp.Tests.TestHelpers
{
    public static class RecurrenceTestHelper
    {
        public static RecurrencePattern CreateDaily(int interval = 1)
        {
            return new RecurrencePattern(FrequencyType.Daily, interval);
        }

        public static RecurrencePattern CreateWeekly(int interval = 1, params DayOfWeek[] daysOfWeek)
        {
            var pattern = new RecurrencePattern(FrequencyType.Weekly, interval);
            if (daysOfWeek.Length > 0)
            {
                pattern.ByDay = daysOfWeek.Select(d => new WeekDay(d)).ToList();
            }
            return pattern;
        }

        public static RecurrencePattern CreateMonthly(int interval = 1, int? dayOfMonth = null)
        {
            var pattern = new RecurrencePattern(FrequencyType.Monthly, interval);
            if (dayOfMonth.HasValue)
            {
                pattern.ByMonthDay = new List<int> { dayOfMonth.Value };
            }
            return pattern;
        }

        public static RecurrencePattern CreateYearly(int interval = 1, int? month = null, int? dayOfMonth = null)
        {
            var pattern = new RecurrencePattern(FrequencyType.Yearly, interval);
            if (month.HasValue)
            {
                pattern.ByMonth = new List<int> { month.Value };
            }
            if (dayOfMonth.HasValue)
            {
                pattern.ByMonthDay = new List<int> { dayOfMonth.Value };
            }
            return pattern;
        }
    }
}