using System.Runtime.Serialization;

namespace TickTickSharp.Models
{
    /// <summary>
    /// Represents the permission level for a project.
    /// </summary>
    public enum ProjectPermission
    {
        /// <summary>
        /// Read-only permission.
        /// </summary>
        [EnumMember(Value = "read")]
        Read = 0,

        /// <summary>
        /// Write permission.
        /// </summary>
        [EnumMember(Value = "write")]
        Write = 1,

        /// <summary>
        /// Comment permission.
        /// </summary>
        [EnumMember(Value = "comment")]
        Comment = 2
    }
}
