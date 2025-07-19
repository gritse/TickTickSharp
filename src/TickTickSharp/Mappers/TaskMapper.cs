using System;
using System.Linq;
using TickTickSharp.Models;
using TickTickSharp.Models.Dto;
using Task = TickTickSharp.Models.Task;

namespace TickTickSharp.Mappers
{
    internal static class TaskMapper
    {
        public static TaskDto ToDto(Task task)
        {
            return new TaskDto
            {
                Id = task.Id,
                ProjectId = task.ProjectId,
                Title = task.Title,
                Content = task.Content,
                Desc = task.Description,
                IsAllDay = task.IsAllDay,
                StartDate = task.StartDate,
                DueDate = task.DueDate,
                TimeZone = task.TimeZone?.Id,
                Priority = task.Priority == TaskPriority.None ? null : (int?)task.Priority,
                Status = task.IsCompleted == true ? 2 : 0,
                CompletedTime = task.CompletedTime,
                SortOrder = task.SortOrder,
                Items = task.Items?.Select(ChecklistItemMapper.ToDto).ToList(),
                RepeatFlag = RecurrenceHelper.SerializeRecurrencePattern(task.Recurrence),
                Reminders = TriggerHelper.SerializeTriggers(task.Reminders)
            };
        }

        public static Task FromDto(TaskDto dto)
        {
            return new Task
            {
                Id = dto.Id,
                ProjectId = dto.ProjectId,
                Title = dto.Title,
                Content = dto.Content,
                Description = dto.Desc,
                IsAllDay = dto.IsAllDay,
                StartDate = dto.StartDate,
                DueDate = dto.DueDate,
                TimeZone = ConvertToTimeZoneInfo(dto.TimeZone),
                Priority = dto.Priority == null ? TaskPriority.None : (TaskPriority)dto.Priority,
                IsCompleted = dto.Status == 2,
                CompletedTime = dto.CompletedTime,
                SortOrder = dto.SortOrder,
                Items = dto.Items?.Select(ChecklistItemMapper.FromDto).ToList(),
                Recurrence = RecurrenceHelper.DeserializeRecurrencePattern(dto.RepeatFlag),
                Reminders = TriggerHelper.DeserializeTriggers(dto.Reminders)
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