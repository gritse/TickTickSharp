namespace TickTickSharp.Models
{
    /// <summary>
    /// Represents a project in TickTick.
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Gets or sets the project identifier.
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the project name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the project color.
        /// </summary>
        public string? Color { get; set; }

        /// <summary>
        /// Gets or sets whether the project is closed.
        /// </summary>
        public bool? Closed { get; set; }

        /// <summary>
        /// Gets or sets the project group identifier.
        /// </summary>
        public string? GroupId { get; set; }

        /// <summary>
        /// Gets or sets the view mode: "list", "kanban", or "timeline".
        /// </summary>
        public string? ViewMode { get; set; }

        /// <summary>
        /// Gets or sets the permission level: "read", "write", or "comment".
        /// </summary>
        public string? Permission { get; set; }

        /// <summary>
        /// Gets or sets the project kind: "TASK" or "NOTE".
        /// </summary>
        public string? Kind { get; set; }

        /// <summary>
        /// Gets or sets the order value.
        /// </summary>
        public long? SortOrder { get; set; }
    }
}