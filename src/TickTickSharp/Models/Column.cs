namespace TickTickSharp.Models
{
    /// <summary>
    /// Represents a column in a project.
    /// </summary>
    public class Column
    {
        /// <summary>
        /// Gets or sets the column identifier.
        /// </summary>
        public string? Id { get; set; }
    
        /// <summary>
        /// Gets or sets the project identifier.
        /// </summary>
        public string? ProjectId { get; set; }
    
        /// <summary>
        /// Gets or sets the column name.
        /// </summary>
        public string Name { get; set; } = string.Empty;
    
        /// <summary>
        /// Gets or sets the order value.
        /// </summary>
        public long? SortOrder { get; set; }
    }
}