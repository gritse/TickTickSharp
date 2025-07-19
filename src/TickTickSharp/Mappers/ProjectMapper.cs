using TickTickSharp.Models;
using TickTickSharp.Models.Dto;

namespace TickTickSharp.Mappers
{
    internal static class ProjectMapper
    {
        public static ProjectDto ToDto(Project project)
        {
            return new ProjectDto
            {
                Id = project.Id,
                Name = project.Name,
                Color = project.Color,
                Closed = project.Closed,
                GroupId = project.GroupId,
                ViewMode = project.ViewMode,
                Permission = project.Permission,
                Kind = project.Kind,
                SortOrder = project.SortOrder
            };
        }

        public static Project FromDto(ProjectDto dto)
        {
            return new Project
            {
                Id = dto.Id,
                Name = dto.Name,
                Color = dto.Color,
                Closed = dto.Closed,
                GroupId = dto.GroupId,
                ViewMode = dto.ViewMode,
                Permission = dto.Permission,
                Kind = dto.Kind,
                SortOrder = dto.SortOrder
            };
        }
    }
}