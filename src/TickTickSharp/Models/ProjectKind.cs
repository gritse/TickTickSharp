using System.Runtime.Serialization;

namespace TickTickSharp.Models
{
    /// <summary>
    /// Represents the kind/type of a project.
    /// </summary>
    public enum ProjectKind
    {
        /// <summary>
        /// Task project type.
        /// </summary>
        [EnumMember(Value = "TASK")]
        Task = 0,

        /// <summary>
        /// Note project type.
        /// </summary>
        [EnumMember(Value = "NOTE")]
        Note = 1
    }
}
