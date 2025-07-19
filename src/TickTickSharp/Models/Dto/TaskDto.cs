using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using TickTickSharp.Client;

namespace TickTickSharp.Models.Dto
{
    internal class TaskDto
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("projectId")]
        public string? ProjectId { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("content")]
        public string? Content { get; set; }

        [JsonPropertyName("desc")]
        public string? Desc { get; set; }

        [JsonPropertyName("isAllDay")]
        public bool? IsAllDay { get; set; }

        [JsonPropertyName("startDate")]
        [JsonConverter(typeof(TickTickDateTimeConverter))]
        public DateTime? StartDate { get; set; }

        [JsonPropertyName("dueDate")]
        [JsonConverter(typeof(TickTickDateTimeConverter))]
        public DateTime? DueDate { get; set; }

        [JsonPropertyName("timeZone")]
        public string? TimeZone { get; set; }

        [JsonPropertyName("reminders")]
        public List<string>? Reminders { get; set; }

        [JsonPropertyName("repeatFlag")]
        public string? RepeatFlag { get; set; }

        [JsonPropertyName("priority")]
        public int? Priority { get; set; }

        [JsonPropertyName("status")]
        public int? Status { get; set; }

        [JsonPropertyName("completedTime")]
        [JsonConverter(typeof(TickTickDateTimeConverter))]
        public DateTime? CompletedTime { get; set; }

        [JsonPropertyName("sortOrder")]
        public long? SortOrder { get; set; }

        [JsonPropertyName("items")]
        public List<ChecklistItemDto>? Items { get; set; }
    }
}