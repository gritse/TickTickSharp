using System.Collections.Generic;
using TickTickSharp.Models;

namespace TickTickSharp.Client
{
    public interface ITickTickClient
    {
        // Task operations
        System.Threading.Tasks.Task<Models.Task?> GetTaskAsync(string projectId, string taskId);
        System.Threading.Tasks.Task<Models.Task?> CreateTaskAsync(Models.Task task);
        System.Threading.Tasks.Task<Models.Task?> UpdateTaskAsync(string taskId, Models.Task task);
        System.Threading.Tasks.Task CompleteTaskAsync(string projectId, string taskId);
        System.Threading.Tasks.Task DeleteTaskAsync(string projectId, string taskId);

        // Project operations
        System.Threading.Tasks.Task<List<Project>?> GetProjectsAsync();
        System.Threading.Tasks.Task<Project?> GetProjectAsync(string projectId);
        System.Threading.Tasks.Task<ProjectData?> GetProjectWithDataAsync(string projectId);
        System.Threading.Tasks.Task<Project?> CreateProjectAsync(Project project);
        System.Threading.Tasks.Task<Project?> UpdateProjectAsync(string projectId, Project project);
        System.Threading.Tasks.Task DeleteProjectAsync(string projectId);
    }
}