using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TickTickSharp.Client
{
    internal class TickTickDateTimeConverter : JsonConverter<DateTime?>
    {
        private const string DateFormat = "yyyy-MM-ddTHH:mm:ss+0000";

        public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }
        
            if (reader.TokenType == JsonTokenType.String)
            {
                var dateString = reader.GetString();
                if (string.IsNullOrEmpty(dateString))
                {
                    return null;
                }
            
                // Try to parse the TickTick format: "2019-11-13T03:00:00+0000"
                if (DateTimeOffset.TryParseExact(dateString, DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out var dateTimeOffset))
                {
                    return dateTimeOffset.DateTime;
                }
            
                // Fallback to standard parsing
                if (DateTime.TryParse(dateString, out var dateTime))
                {
                    return dateTime;
                }
            }
        
            return null;
        }

        public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNullValue();
            }
            else
            {
                // Write in the exact format TickTick expects: "2025-07-20T09:00:00+0000"
                var utcDateTime = value.Value.ToUniversalTime();
                writer.WriteStringValue(utcDateTime.ToString("yyyy-MM-ddTHH:mm:ss+0000", CultureInfo.InvariantCulture));
            }
        }
    }
}