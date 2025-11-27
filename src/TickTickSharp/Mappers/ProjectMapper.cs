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
                ViewMode = project.ViewMode?.ToString().ToLowerInvariant(),
                Permission = project.Permission?.ToString().ToLowerInvariant(),
                Kind = project.Kind?.ToString().ToUpperInvariant(),
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
                ViewMode = ParseViewMode(dto.ViewMode),
                Permission = ParsePermission(dto.Permission),
                Kind = ParseKind(dto.Kind),
                SortOrder = dto.SortOrder
            };
        }

        private static ProjectViewMode? ParseViewMode(string? viewMode)
        {
            if (string.IsNullOrEmpty(viewMode))
                return null;

            return viewMode.ToLowerInvariant() switch
            {
                "list" => ProjectViewMode.List,
                "kanban" => ProjectViewMode.Kanban,
                "timeline" => ProjectViewMode.Timeline,
                _ => null
            };
        }

        private static ProjectPermission? ParsePermission(string? permission)
        {
            if (string.IsNullOrEmpty(permission))
                return null;

            return permission.ToLowerInvariant() switch
            {
                "read" => ProjectPermission.Read,
                "write" => ProjectPermission.Write,
                "comment" => ProjectPermission.Comment,
                _ => null
            };
        }

        private static ProjectKind? ParseKind(string? kind)
        {
            if (string.IsNullOrEmpty(kind))
                return null;

            return kind.ToUpperInvariant() switch
            {
                "TASK" => ProjectKind.Task,
                "NOTE" => ProjectKind.Note,
                _ => null
            };
        }

    }
}