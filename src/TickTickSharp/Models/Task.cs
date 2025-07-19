using System;
using System.Collections.Generic;
using Ical.Net.DataTypes;

namespace TickTickSharp.Models
{
    /// <summary>
    /// Represents a task in TickTick.
    /// </summary>
    public class Task
    {
        /// <summary>
        /// Gets or sets the task identifier.
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the task project id. Empty project ID means the task is in the inbox.
        /// </summary>
        public string? ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the task title.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the task content.
        /// </summary>
        public string? Content { get; set; }

        /// <summary>
        /// Gets or sets the task description of checklist.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets whether this is an all-day task.
        /// </summary>
        public bool? IsAllDay { get; set; }

        /// <summary>
        /// Gets or sets the start date time in UTC.
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Gets or sets the task due date time in UTC.
        /// </summary>
        public DateTime? DueDate { get; set; }

        /// <summary>
        /// Gets or sets the task timezone.
        /// Example: "America/Los_Angeles"
        /// </summary>
        public TimeZoneInfo? TimeZone { get; set; }

        /// <summary>
        /// Gets or sets the task priority.
        /// </summary>
        public TaskPriority Priority { get; set; } = TaskPriority.None;

        /// <summary>
        /// Gets or sets whether the task is completed.
        /// </summary>
        public bool? IsCompleted { get; set; }

        /// <summary>
        /// Gets or sets the task completed time in UTC.
        /// </summary>
        public DateTime? CompletedTime { get; set; }

        /// <summary>
        /// Gets or sets the task sort order.
        /// </summary>
        public long? SortOrder { get; set; }

        /// <summary>
        /// Gets or sets the subtasks of the task.
        /// </summary>
        public List<ChecklistItem>? Items { get; set; }

        /// <summary>
        /// Gets or sets the recurring rules of the task.
        /// </summary>
        public RecurrencePattern? Recurrence { get; set; }

        /// <summary>
        /// Gets or sets the list of reminder triggers.
        /// </summary>
        public List<Trigger>? Reminders { get; set; }
    }
}