using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
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
                ViewMode = EnumToString(project.ViewMode),
                Permission = EnumToString(project.Permission),
                Kind = EnumToString(project.Kind),
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
                ViewMode = StringToEnum<ProjectViewMode>(dto.ViewMode),
                Permission = StringToEnum<ProjectPermission>(dto.Permission),
                Kind = StringToEnum<ProjectKind>(dto.Kind),
                SortOrder = dto.SortOrder
            };
        }

        private static string? EnumToString<TEnum>(TEnum? enumValue) where TEnum : struct, Enum
        {
            if (enumValue == null)
                return null;

            var memberInfo = typeof(TEnum).GetMember(enumValue.ToString()!).FirstOrDefault();
            var enumMemberAttr = memberInfo?.GetCustomAttribute<EnumMemberAttribute>();
            return enumMemberAttr?.Value ?? enumValue.ToString();
        }

        private static TEnum? StringToEnum<TEnum>(string? value) where TEnum : struct, Enum
        {
            if (string.IsNullOrEmpty(value))
                return null;

            foreach (var field in typeof(TEnum).GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                var enumMemberAttr = field.GetCustomAttribute<EnumMemberAttribute>();
                if (enumMemberAttr?.Value == value)
                    return (TEnum)field.GetValue(null)!;
            }

            // Fallback to standard enum parsing if no EnumMember match
            if (Enum.TryParse<TEnum>(value, ignoreCase: true, out var result))
                return result;

            return null;
        }
    }
}