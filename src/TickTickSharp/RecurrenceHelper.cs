using System;
using System.IO;
using Ical.Net.DataTypes;
using Ical.Net.Serialization.DataTypes;

namespace TickTickSharp
{
    internal static class RecurrenceHelper
    {
        private static readonly RecurrencePatternSerializer Serializer = new RecurrencePatternSerializer();

        public static string? SerializeRecurrencePattern(RecurrencePattern? pattern)
        {
            if (pattern == null)
                return null;
        
            var serialized = Serializer.SerializeToString(pattern);
            return $"RRULE:{serialized}";
        }

        public static RecurrencePattern? DeserializeRecurrencePattern(string? rrule)
        {
            if (string.IsNullOrEmpty(rrule))
                return null;

            try
            {
                // Remove RRULE: prefix if present
                var cleanRrule = rrule.StartsWith("RRULE:", StringComparison.OrdinalIgnoreCase)
                    ? rrule.Substring(6)
                    : rrule;
            
                return Serializer.Deserialize(new StringReader(cleanRrule)) as RecurrencePattern;
            }
            catch
            {
                return null;
            }
        }

    }
}