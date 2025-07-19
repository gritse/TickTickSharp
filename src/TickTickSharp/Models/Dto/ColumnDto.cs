using System.Text.Json.Serialization;

namespace TickTickSharp.Models.Dto
{
    internal class ColumnDto
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("projectId")]
        public string? ProjectId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("sortOrder")]
        public long? SortOrder { get; set; }
    }
}