using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TickTickSharp.Models.Dto
{
    internal class ProjectDto
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("color")]
        public string? Color { get; set; }

        [JsonPropertyName("inboxId")]
        public string? InboxId { get; set; }

        [JsonPropertyName("viewMode")]
        public string? ViewMode { get; set; }

        [JsonPropertyName("kind")]
        public string? Kind { get; set; }

        [JsonPropertyName("teamId")]
        public string? TeamId { get; set; }

        [JsonPropertyName("modifiedTime")]
        public DateTime? ModifiedTime { get; set; }

        [JsonPropertyName("sortOrder")]
        public long? SortOrder { get; set; }

        [JsonPropertyName("sortType")]
        public string? SortType { get; set; }

        [JsonPropertyName("userCount")]
        public int? UserCount { get; set; }

        [JsonPropertyName("etag")]
        public string? Etag { get; set; }

        [JsonPropertyName("closed")]
        public bool? Closed { get; set; }

        [JsonPropertyName("muted")]
        public bool? Muted { get; set; }

        [JsonPropertyName("transferred")]
        public bool? Transferred { get; set; }

        [JsonPropertyName("groupId")]
        public string? GroupId { get; set; }

        [JsonPropertyName("permission")]
        public string? Permission { get; set; }

        [JsonPropertyName("notificationOptions")]
        public List<object>? NotificationOptions { get; set; }

        [JsonPropertyName("timeline")]
        public string? Timeline { get; set; }
    }
}