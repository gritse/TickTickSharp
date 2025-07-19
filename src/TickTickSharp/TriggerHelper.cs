using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Ical.Net.DataTypes;
using Ical.Net.Serialization.DataTypes;

namespace TickTickSharp
{
    internal static class TriggerHelper
    {
        private static readonly TriggerSerializer Serializer = new TriggerSerializer();

        private static string? SerializeTrigger(Trigger? trigger)
        {
            if (trigger == null)
                return null;

            var serialized = Serializer.SerializeToString(trigger);
            return $"TRIGGER:{serialized}";
        }

        private static Trigger? DeserializeTrigger(string? triggerString)
        {
            if (string.IsNullOrEmpty(triggerString))
                return null;

            try
            {
                // Remove TRIGGER: prefix if present
                var cleanTrigger = triggerString.StartsWith("TRIGGER:", StringComparison.OrdinalIgnoreCase)
                    ? triggerString.Substring(8)
                    : triggerString;

                return Serializer.Deserialize(new StringReader(cleanTrigger)) as Trigger;
            }
            catch
            {
                return null;
            }
        }

        public static List<string>? SerializeTriggers(List<Trigger>? triggers)
        {
            return triggers?.Select(SerializeTrigger)
                .Where(s => s != null)
                .Select(s => s!)
                .ToList();
        }

        public static List<Trigger>? DeserializeTriggers(List<string>? triggerStrings)
        {
            return triggerStrings?.Select(DeserializeTrigger)
                .Where(t => t != null)
                .Select(t => t!)
                .ToList();
        }

    }
}