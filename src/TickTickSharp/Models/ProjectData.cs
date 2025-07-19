using System.Collections.Generic;

namespace TickTickSharp.Models
{
    /// <summary>
    /// Represents project data containing project information, tasks, and columns.
    /// </summary>
    public class ProjectData
    {
        /// <summary>
        /// Gets or sets the project information.
        /// </summary>
        public Project? Project { get; set; }
    
        /// <summary>
        /// Gets or sets the undone tasks under the project.
        /// </summary>
        public List<Task>? Tasks { get; set; }
    
        /// <summary>
        /// Gets or sets the columns under the project.
        /// </summary>
        public List<Column>? Columns { get; set; }
    }
}