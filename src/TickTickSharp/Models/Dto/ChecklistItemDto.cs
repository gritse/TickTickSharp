using System;
using System.Text.Json.Serialization;
using TickTickSharp.Client;

namespace TickTickSharp.Models.Dto
{
    internal class ChecklistItemDto
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("status")]
        public int Status { get; set; }

        [JsonPropertyName("completedTime")]
        [JsonConverter(typeof(TickTickDateTimeConverter))]
        public DateTime? CompletedTime { get; set; }

        [JsonPropertyName("isAllDay")]
        public bool? IsAllDay { get; set; }

        [JsonPropertyName("sortOrder")]
        public long SortOrder { get; set; }

        [JsonPropertyName("startDate")]
        [JsonConverter(typeof(TickTickDateTimeConverter))]
        public DateTime? StartDate { get; set; }

        [JsonPropertyName("timeZone")]
        public string? TimeZone { get; set; }
    }
}