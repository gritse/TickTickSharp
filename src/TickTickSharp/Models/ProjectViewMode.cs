using System.Runtime.Serialization;

namespace TickTickSharp.Models
{
    /// <summary>
    /// Represents the view mode of a project.
    /// </summary>
    public enum ProjectViewMode
    {
        /// <summary>
        /// List view mode.
        /// </summary>
        [EnumMember(Value = "list")]
        List = 0,

        /// <summary>
        /// Kanban board view mode.
        /// </summary>
        [EnumMember(Value = "kanban")]
        Kanban = 1,

        /// <summary>
        /// Timeline view mode.
        /// </summary>
        [EnumMember(Value = "timeline")]
        Timeline = 2
    }
}
