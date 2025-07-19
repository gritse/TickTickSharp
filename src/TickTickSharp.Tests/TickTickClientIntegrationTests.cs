using TickTickSharp.Models;
using Xunit.Abstractions;
using Task = System.Threading.Tasks.Task;
using Ical.Net.DataTypes;
using TickTickSharp.Tests.TestHelpers;

namespace TickTickSharp.Tests
{
    public class TickTickClientIntegrationTests : TestBase
    {
        private readonly ITestOutputHelper _output;
        private static Project? _testProject;

        public TickTickClientIntegrationTests(ITestOutputHelper output)
        {
            _output = output;
        }

        private async Task<Project> GetTestProjectAsync()
        {
            if (_testProject == null)
            {
                _testProject = new Project
                {
                    Name = $"Test Project {DateTime.UtcNow:yyyyMMdd_HHmmss}",
                    Color = "#FF5722",
                    ViewMode = "list",
                    Kind = "TASK"
                };

                _testProject = await Client.CreateProjectAsync(_testProject);
                _output.WriteLine($"Created test project: {_testProject?.Name} (ID: {_testProject?.Id})");
            }

            return _testProject!;
        }

        [Fact]
        public async Task CreateBasicTask_ShouldWork()
        {
            var project = await GetTestProjectAsync();

            var task = new TickTickSharp.Models.Task
            {
                Title = $"Basic Task {DateTime.UtcNow:HHmmss}",
                Content = "Simple task without dates",
                ProjectId = project.Id,
                Priority = 1
            };

            var created = await Client.CreateTaskAsync(task);

            Assert.NotNull(created);
            Assert.NotNull(created.Id);
            Assert.Equal(task.Title, created.Title);
            _output.WriteLine($"Created basic task: {created.Title} (ID: {created.Id})");
        }

        [Fact]
        public async Task CreateTaskWithDates_ShouldWork()
        {
            var project = await GetTestProjectAsync();

            var task = new TickTickSharp.Models.Task
            {
                Title = $"Task with Dates {DateTime.UtcNow:HHmmss}",
                Content = "Task with start and due dates",
                ProjectId = project.Id,
                StartDate = DateTime.UtcNow.AddDays(1),
                DueDate = DateTime.UtcNow.AddDays(7),
                TimeZone = TimeZoneInfo.Utc,
                Priority = 2
            };

            var created = await Client.CreateTaskAsync(task);

            Assert.NotNull(created);
            Assert.NotNull(created.Id);
            Assert.Equal(task.Title, created.Title);
            _output.WriteLine($"Created task with dates: {created.Title} (ID: {created.Id})");
        }

        [Fact]
        public async Task CreateTaskWithSubtasks_ShouldWork()
        {
            var project = await GetTestProjectAsync();

            var task = new TickTickSharp.Models.Task
            {
                Title = $"Task with Subtasks {DateTime.UtcNow:HHmmss}",
                Content = "Task with checklist items",
                ProjectId = project.Id,
                Priority = 2,
                Items = new List<ChecklistItem>
                {
                    new() { Title = "First subtask", IsCompleted = false, SortOrder = 1 },
                    new() { Title = "Second subtask", IsCompleted = false, SortOrder = 2 },
                    new() { Title = "Third subtask", IsCompleted = true, SortOrder = 2 }
                }
            };

            var created = await Client.CreateTaskAsync(task);

            Assert.NotNull(created);
            Assert.NotNull(created.Id);
            Assert.Equal(task.Title, created.Title);
            _output.WriteLine($"Created task with subtasks: {created.Title} (ID: {created.Id})");
        }

        [Fact]
        public async Task CreateDailyRecurringTask_ShouldWork()
        {
            var project = await GetTestProjectAsync();

            var task = new TickTickSharp.Models.Task
            {
                Title = $"Daily Task {DateTime.UtcNow:HHmmss}",
                Content = "Repeats every day",
                ProjectId = project.Id,
                StartDate = DateTime.UtcNow.AddDays(1).Date.AddHours(9),
                DueDate = DateTime.UtcNow.AddDays(1).Date.AddHours(10),
                Recurrence = RecurrenceTestHelper.CreateDaily(),
                Reminders = new List<Trigger> { TriggerTestHelper.CreateAtDueTime() },
                TimeZone = TimeZoneInfo.Utc
            };

            var created = await Client.CreateTaskAsync(task);

            Assert.NotNull(created);
            Assert.NotNull(created.Id);
            Assert.Equal(task.Title, created.Title);
            _output.WriteLine($"Created daily recurring task: {created.Title} (ID: {created.Id})");
        }

        [Fact]
        public async Task CreateWeeklyRecurringTask_ShouldWork()
        {
            var project = await GetTestProjectAsync();

            var task = new TickTickSharp.Models.Task
            {
                Title = $"Weekly Task {DateTime.UtcNow:HHmmss}",
                Content = "Repeats every week on Monday and Friday",
                ProjectId = project.Id,
                StartDate = DateTime.UtcNow.AddDays(1).Date.AddHours(14),
                Recurrence = RecurrenceTestHelper.CreateWeekly(1, DayOfWeek.Monday, DayOfWeek.Friday),
                TimeZone = TimeZoneInfo.Utc
            };

            var created = await Client.CreateTaskAsync(task);

            Assert.NotNull(created);
            Assert.NotNull(created.Id);
            _output.WriteLine($"Created weekly recurring task: {created.Title} (ID: {created.Id})");
        }

        [Fact]
        public async Task CreateTaskWithReminders_ShouldWork()
        {
            var project = await GetTestProjectAsync();

            var task = new TickTickSharp.Models.Task
            {
                Title = $"Task with Reminders {DateTime.UtcNow:HHmmss}",
                Content = "Task with notification reminders",
                ProjectId = project.Id,
                DueDate = DateTime.UtcNow.AddDays(2).Date.AddHours(15),
                Reminders = new List<Trigger>
                {
                    TriggerTestHelper.CreateAtDueTime(),
                    TriggerTestHelper.CreateMinutesBefore(15),
                    TriggerTestHelper.CreateDaysBefore(1)
                },
                TimeZone = TimeZoneInfo.Utc
            };

            var created = await Client.CreateTaskAsync(task);

            Assert.NotNull(created);
            Assert.NotNull(created.Id);
            _output.WriteLine($"Created task with reminders: {created.Title} (ID: {created.Id})");
        }

        [Fact]
        public async Task CreateMonthlyRecurringTask_ShouldWork()
        {
            var project = await GetTestProjectAsync();

            var task = new TickTickSharp.Models.Task
            {
                Title = $"Monthly Task {DateTime.UtcNow:HHmmss}",
                Content = "Repeats monthly on the 15th",
                ProjectId = project.Id,
                StartDate = DateTime.UtcNow.AddDays(1).Date.AddHours(10),
                Recurrence = RecurrenceTestHelper.CreateMonthly(1, 15),
                Reminders = new List<Trigger>
                {
                    TriggerTestHelper.CreateHoursBefore(2),
                    TriggerTestHelper.CreateDaysBefore(1)
                },
                TimeZone = TimeZoneInfo.Utc
            };

            var created = await Client.CreateTaskAsync(task);

            Assert.NotNull(created);
            Assert.NotNull(created.Id);
            _output.WriteLine($"Created monthly recurring task: {created.Title} (ID: {created.Id})");
        }

        [Fact]
        public async Task CreateTaskAndComplete_ShouldWork()
        {
            var project = await GetTestProjectAsync();

            var task = new TickTickSharp.Models.Task
            {
                Title = $"Task to Complete {DateTime.UtcNow:HHmmss}",
                Content = "This task will be completed",
                ProjectId = project.Id,
                Priority = 1,
                IsCompleted = false
            };

            var created = await Client.CreateTaskAsync(task);

            Assert.NotNull(created);
            Assert.NotNull(created.Id);
            Assert.Equal(task.Title, created.Title);
            Assert.False(created.IsCompleted);
            _output.WriteLine($"Created task: {created.Title} (ID: {created.Id})");

            await Client.CompleteTaskAsync(project.Id!, created.Id!);
            _output.WriteLine($"Completed task: {created.Title} (ID: {created.Id})");

            var completedTask = await Client.GetTaskAsync(project.Id!, created.Id!);
            Assert.NotNull(completedTask);
            Assert.True(completedTask.IsCompleted);
            _output.WriteLine($"Verified task completion: {completedTask.Title} (Completed: {completedTask.IsCompleted})");
        }

    }
}