using System.Linq;
using TickTickSharp.Models;
using TickTickSharp.Models.Dto;

namespace TickTickSharp.Mappers
{
    internal static class ProjectDataMapper
    {
        public static ProjectDataDto ToDto(ProjectData projectData)
        {
            return new ProjectDataDto
            {
                Project = projectData.Project != null ? ProjectMapper.ToDto(projectData.Project) : null,
                Tasks = projectData.Tasks?.Select(TaskMapper.ToDto).ToList(),
                Columns = projectData.Columns?.Select(ColumnMapper.ToDto).ToList()
            };
        }

        public static ProjectData FromDto(ProjectDataDto dto)
        {
            return new ProjectData
            {
                Project = dto.Project != null ? ProjectMapper.FromDto(dto.Project) : null,
                Tasks = dto.Tasks?.Select(TaskMapper.FromDto).ToList(),
                Columns = dto.Columns?.Select(ColumnMapper.FromDto).ToList()
            };
        }
    }
}