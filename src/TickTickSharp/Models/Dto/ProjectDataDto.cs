using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TickTickSharp.Models.Dto
{
    internal class ProjectDataDto
    {
        [JsonPropertyName("project")]
        public ProjectDto? Project { get; set; }

        [JsonPropertyName("tasks")]
        public List<TaskDto>? Tasks { get; set; }

        [JsonPropertyName("columns")]
        public List<ColumnDto>? Columns { get; set; }
    }
}