using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TickTickSharp.Models;
using TickTickSharp.Models.Dto;
using TickTickSharp.Mappers;

namespace TickTickSharp.Client
{
    public class TickTickClient : ITickTickClient, IDisposable
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;
        private const string BaseUrl = "https://api.ticktick.com";

        public TickTickClient(string accessToken, HttpClient? httpClient = null)
        {
            _httpClient = httpClient ?? new HttpClient();
            _httpClient.BaseAddress = new Uri(BaseUrl);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = false,
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
            };
        }

        // Task operations
        public async Task<Models.Task?> GetTaskAsync(string projectId, string taskId)
        {
            var response = await _httpClient.GetAsync($"/open/v1/project/{projectId}/task/{taskId}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var dto = JsonSerializer.Deserialize<TaskDto>(json, _jsonOptions);
                return dto != null ? TaskMapper.FromDto(dto) : null;
            }

            await HandleErrorResponse(response);
            return null;
        }

        public async Task<Models.Task?> CreateTaskAsync(Models.Task task)
        {
            var dto = TaskMapper.ToDto(task);
            var json = JsonSerializer.Serialize(dto, _jsonOptions);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("/open/v1/task", content);

            if (response.IsSuccessStatusCode)
            {
                var responseJson = await response.Content.ReadAsStringAsync();
                var responseDto = JsonSerializer.Deserialize<TaskDto>(responseJson, _jsonOptions);
                return responseDto != null ? TaskMapper.FromDto(responseDto) : null;
            }

            await HandleErrorResponse(response);
            return null;
        }

        public async Task<Models.Task?> UpdateTaskAsync(string taskId, Models.Task task)
        {
            var dto = TaskMapper.ToDto(task);
            var json = JsonSerializer.Serialize(dto, _jsonOptions);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"/open/v1/task/{taskId}", content);

            if (response.IsSuccessStatusCode)
            {
                var responseJson = await response.Content.ReadAsStringAsync();
                var responseDto = JsonSerializer.Deserialize<TaskDto>(responseJson, _jsonOptions);
                return responseDto != null ? TaskMapper.FromDto(responseDto) : null;
            }

            await HandleErrorResponse(response);
            return null;
        }

        public async System.Threading.Tasks.Task CompleteTaskAsync(string projectId, string taskId)
        {
            var response = await _httpClient.PostAsync($"/open/v1/project/{projectId}/task/{taskId}/complete", null);

            if (!response.IsSuccessStatusCode)
            {
                await HandleErrorResponse(response);
            }
        }

        public async System.Threading.Tasks.Task DeleteTaskAsync(string projectId, string taskId)
        {
            var response = await _httpClient.DeleteAsync($"/open/v1/project/{projectId}/task/{taskId}");

            if (!response.IsSuccessStatusCode)
            {
                await HandleErrorResponse(response);
            }
        }

        // Project operations
        public async Task<List<Project>?> GetProjectsAsync()
        {
            var response = await _httpClient.GetAsync("/open/v1/project");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var dtos = JsonSerializer.Deserialize<List<ProjectDto>>(json, _jsonOptions);
                return dtos?.Select(ProjectMapper.FromDto).ToList();
            }

            await HandleErrorResponse(response);
            return null;
        }

        public async Task<Project?> GetProjectAsync(string projectId)
        {
            var response = await _httpClient.GetAsync($"/open/v1/project/{projectId}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var dto = JsonSerializer.Deserialize<ProjectDto>(json, _jsonOptions);
                return dto != null ? ProjectMapper.FromDto(dto) : null;
            }

            await HandleErrorResponse(response);
            return null;
        }

        public async Task<ProjectData?> GetProjectWithDataAsync(string projectId)
        {
            var response = await _httpClient.GetAsync($"/open/v1/project/{projectId}/data");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var dto = JsonSerializer.Deserialize<ProjectDataDto>(json, _jsonOptions);
                return dto != null ? ProjectDataMapper.FromDto(dto) : null;
            }

            await HandleErrorResponse(response);
            return null;
        }

        public async Task<Project?> CreateProjectAsync(Project project)
        {
            var dto = ProjectMapper.ToDto(project);
            var json = JsonSerializer.Serialize(dto, _jsonOptions);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("/open/v1/project", content);

            if (response.IsSuccessStatusCode)
            {
                var responseJson = await response.Content.ReadAsStringAsync();
                var responseDto = JsonSerializer.Deserialize<ProjectDto>(responseJson, _jsonOptions);
                return responseDto != null ? ProjectMapper.FromDto(responseDto) : null;
            }

            await HandleErrorResponse(response);
            return null;
        }

        public async Task<Project?> UpdateProjectAsync(string projectId, Project project)
        {
            var dto = ProjectMapper.ToDto(project);
            var json = JsonSerializer.Serialize(dto, _jsonOptions);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"/open/v1/project/{projectId}", content);

            if (response.IsSuccessStatusCode)
            {
                var responseJson = await response.Content.ReadAsStringAsync();
                var responseDto = JsonSerializer.Deserialize<ProjectDto>(responseJson, _jsonOptions);
                return responseDto != null ? ProjectMapper.FromDto(responseDto) : null;
            }

            await HandleErrorResponse(response);
            return null;
        }

        public async System.Threading.Tasks.Task DeleteProjectAsync(string projectId)
        {
            var response = await _httpClient.DeleteAsync($"/open/v1/project/{projectId}");

            if (!response.IsSuccessStatusCode)
            {
                await HandleErrorResponse(response);
            }
        }

        private static async System.Threading.Tasks.Task HandleErrorResponse(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();
            throw new HttpRequestException(
                $"TickTick API request failed with status {response.StatusCode}: {content}");
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}