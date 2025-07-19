using TickTickSharp.Models;
using TickTickSharp.Models.Dto;

namespace TickTickSharp.Mappers
{
    internal static class ColumnMapper
    {
        public static ColumnDto ToDto(Column column)
        {
            return new ColumnDto
            {
                Id = column.Id,
                ProjectId = column.ProjectId,
                Name = column.Name,
                SortOrder = column.SortOrder
            };
        }

        public static Column FromDto(ColumnDto dto)
        {
            return new Column
            {
                Id = dto.Id,
                ProjectId = dto.ProjectId,
                Name = dto.Name,
                SortOrder = dto.SortOrder
            };
        }
    }
}