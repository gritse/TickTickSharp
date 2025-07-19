using System;

namespace TickTickSharp.Models
{
    /// <summary>
    /// Represents a subtask item in a checklist.
    /// </summary>
    public class ChecklistItem
    {
        /// <summary>
        /// Gets or sets the subtask identifier.
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the subtask title.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets whether the subtask is completed.
        /// </summary>
        public bool IsCompleted { get; set; }

        /// <summary>
        /// Gets or sets the subtask completed time in UTC.
        /// </summary>
        public DateTime? CompletedTime { get; set; }

        /// <summary>
        /// Gets or sets whether this is an all-day subtask.
        /// </summary>
        public bool? IsAllDay { get; set; }

        /// <summary>
        /// Gets or sets the subtask sort order.
        /// </summary>
        public long SortOrder { get; set; }

        /// <summary>
        /// Gets or sets the subtask start date time in UTC.
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Gets or sets the subtask timezone.
        /// Example: "America/Los_Angeles"
        /// </summary>
        public TimeZoneInfo? TimeZone { get; set; }
    }
}