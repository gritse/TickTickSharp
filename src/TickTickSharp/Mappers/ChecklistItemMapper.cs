using System;
using TickTickSharp.Models;
using TickTickSharp.Models.Dto;

namespace TickTickSharp.Mappers
{
    internal static class ChecklistItemMapper
    {
        public static ChecklistItemDto ToDto(ChecklistItem item)
        {
            return new ChecklistItemDto
            {
                Id = item.Id,
                Title = item.Title,
                Status = item.IsCompleted ? 1 : 0,
                CompletedTime = item.CompletedTime,
                IsAllDay = item.IsAllDay,
                SortOrder = item.SortOrder,
                StartDate = item.StartDate,
                TimeZone = item.TimeZone?.Id
            };
        }

        public static ChecklistItem FromDto(ChecklistItemDto dto)
        {
            return new ChecklistItem
            {
                Id = dto.Id,
                Title = dto.Title,
                IsCompleted = dto.Status == 1,
                CompletedTime = dto.CompletedTime,
                IsAllDay = dto.IsAllDay,
                SortOrder = dto.SortOrder,
                StartDate = dto.StartDate,
                TimeZone = ConvertToTimeZoneInfo(dto.TimeZone)
            };
        }

        private static TimeZoneInfo? ConvertToTimeZoneInfo(string? timeZoneId)
        {
            if (string.IsNullOrEmpty(timeZoneId))
                return null;

            try
            {
                return TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            }
            catch
            {
                // Fallback to UTC if timezone is not found
                return TimeZoneInfo.Utc;
            }
        }
    }
}