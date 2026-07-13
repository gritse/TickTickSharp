namespace TickTickSharp.Models
{
    /// <summary>
    /// Represents the status of a task.
    /// </summary>
    public enum TaskStatus
    {
        /// <summary>
        /// The task is active.
        /// </summary>
        Active = 0,

        /// <summary>
        /// The task is completed.
        /// </summary>
        Completed = 2,

        /// <summary>
        /// The task is abandoned ("Won't Do").
        /// </summary>
        WontDo = -1
    }
}
