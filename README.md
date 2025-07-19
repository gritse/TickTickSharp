# TickTickSharp

[![NuGet Version](https://img.shields.io/nuget/v/TickTickSharp.svg)](https://www.nuget.org/packages/TickTickSharp/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/TickTickSharp.svg)](https://www.nuget.org/packages/TickTickSharp/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

A modern, strongly-typed .NET client library for the [TickTick Open API](https://developer.ticktick.com/). Built with .NET 8 and designed for productivity applications that need to integrate with TickTick's task management platform.

## ✨ Features

- **🔒 Strongly Typed** - Work with `TimeZoneInfo`, `RecurrencePattern`, and `Trigger` objects instead of raw strings
- **🔄 Recurrence Support** - Full support for daily, weekly, monthly, and yearly recurring tasks using industry-standard RRULE format
- **⏰ Smart Reminders** - Easy creation of reminders with natural time expressions (15 minutes before, 1 day before, etc.)
- **🌍 Timezone Aware** - Built-in support for `TimeZoneInfo` with automatic conversion to TickTick's format
- **📋 Complete CRUD** - Full support for tasks, projects, and subtasks
- **🎯 Clean Architecture** - Internal DTO/Mapper pattern keeps the public API clean while handling TickTick's JSON format
- **⚡ Async/Await** - Modern async patterns throughout
- **🧪 Well Tested** - Comprehensive integration tests

## 🚀 Quick Start

### Installation

```bash
dotnet add package TickTickSharp
```

### Authentication Setup

**Note:** This library does not handle OAuth authentication flows. You need to implement the OAuth flow yourself to obtain an access token.

1. **Create a TickTick Application**
   - Go to the [TickTick Developer Console](https://developer.ticktick.com/)
   - Create a new application
   - Note your `client_id` and `client_secret`

2. **Implement OAuth Flow**
   - Implement the OAuth 2.0 authorization code flow
   - Redirect users to: `https://ticktick.com/oauth/authorize?client_id=YOUR_CLIENT_ID&scope=tasks:write&response_type=code&redirect_uri=YOUR_REDIRECT_URI`
   - Exchange the authorization code for an access token using your `client_secret`
   - See [TickTick OAuth Documentation](https://developer.ticktick.com/api#/openapi?id=oauth) for detailed steps

3. **Initialize the Client**
   Once you have an access token, initialize the client:

```csharp
using TickTickSharp.Client;

var client = new TickTickClient("your-access-token");
```

> **Important:** Access tokens expire and need to be refreshed. Implement token refresh logic in your application as this library only handles API calls with valid tokens.

### Basic Usage

```csharp
// Create a simple task
var task = new TickTickSharp.Models.Task
{
    Title = "Review quarterly reports",
    Content = "Go through Q3 financial reports and sales data",
    ProjectId = "project-id",
    DueDate = DateTime.Now.AddDays(3),
    TimeZone = TimeZoneInfo.Local,
    Priority = 2
};

var createdTask = await client.CreateTaskAsync(task);
```

## 📖 Examples

### Working with Projects

```csharp
// Get all projects
var projects = await client.GetProjectsAsync();

// Create a new project
var project = new Project
{
    Name = "Marketing Campaign",
    Color = "#FF5722",
    ViewMode = "list",
    Kind = "TASK"
};

var newProject = await client.CreateProjectAsync(project);
```

### Recurring Tasks

Create recurring tasks using strongly-typed recurrence patterns:

```csharp
using Ical.Net.DataTypes;

// Daily standup meeting
var dailyTask = new TickTickSharp.Models.Task
{
    Title = "Daily Standup",
    ProjectId = projectId,
    StartDate = DateTime.Today.AddHours(9), // 9 AM
    DueDate = DateTime.Today.AddHours(9.5), // 9:30 AM
    Recurrence = new RecurrencePattern(FrequencyType.Daily, 1),
    TimeZone = TimeZoneInfo.Local
};

// Weekly team meeting (every Monday and Friday)
var weeklyTask = new TickTickSharp.Models.Task
{
    Title = "Team Sync",
    ProjectId = projectId,
    Recurrence = new RecurrencePattern(FrequencyType.Weekly, 1)
    {
        ByDay = new List<WeekDay> 
        { 
            new WeekDay(DayOfWeek.Monday), 
            new WeekDay(DayOfWeek.Friday) 
        }
    },
    TimeZone = TimeZoneInfo.Local
};

// Monthly report (15th of every month)
var monthlyTask = new TickTickSharp.Models.Task
{
    Title = "Monthly Report",
    ProjectId = projectId,
    Recurrence = new RecurrencePattern(FrequencyType.Monthly, 1)
    {
        ByMonthDay = new List<int> { 15 }
    },
    TimeZone = TimeZoneInfo.Local
};
```

### Smart Reminders

Add reminders using natural time expressions:

```csharp
using Ical.Net.DataTypes;

var taskWithReminders = new TickTickSharp.Models.Task
{
    Title = "Important Meeting",
    ProjectId = projectId,
    DueDate = DateTime.Now.AddDays(1).Date.AddHours(14), // Tomorrow at 2 PM
    Reminders = new List<Trigger>
    {
        new Trigger(new Duration(seconds: 0)),           // At due time
        new Trigger(new Duration(minutes: -15)),         // 15 minutes before
        new Trigger(new Duration(hours: -2)),            // 2 hours before
        new Trigger(new Duration(days: -1))              // 1 day before
    },
    TimeZone = TimeZoneInfo.Local
};
```

### Tasks with Subtasks

```csharp
var taskWithSubtasks = new TickTickSharp.Models.Task
{
    Title = "Website Redesign",
    Content = "Complete overhaul of company website",
    ProjectId = projectId,
    Items = new List<ChecklistItem>
    {
        new ChecklistItem { Title = "Design mockups", Status = 0, SortOrder = 1 },
        new ChecklistItem { Title = "Frontend development", Status = 0, SortOrder = 2 },
        new ChecklistItem { Title = "Content migration", Status = 0, SortOrder = 3 },
        new ChecklistItem { Title = "Testing & QA", Status = 0, SortOrder = 4 }
    }
};
```

### Task Operations

```csharp
// Get a specific task
var task = await client.GetTaskAsync(projectId, taskId);

// Update a task
task.Title = "Updated title";
task.Priority = 3;
var updatedTask = await client.UpdateTaskAsync(taskId, task);

// Complete a task
await client.CompleteTaskAsync(projectId, taskId);

// Delete a task
await client.DeleteTaskAsync(projectId, taskId);
```

## 🏗️ Architecture

TickTickSharp uses a clean architecture with DTOs and mappers to provide a strongly-typed API while maintaining compatibility with TickTick's JSON format:

```
User Code (Strongly Typed Models)
    ↕ Mappers
Internal DTOs (JSON Serialization)
    ↕ HTTP Client
TickTick API
```

### Key Components

- **Public Models** - Clean, strongly-typed classes (`Task`, `Project`, `ChecklistItem`)
- **Internal DTOs** - JSON serialization models with proper API format
- **Mappers** - Handle conversion between public models and DTOs
- **Client** - HTTP communication layer with proper error handling

## 🔧 Configuration

### Custom HttpClient

```csharp
var httpClient = new HttpClient();
httpClient.Timeout = TimeSpan.FromSeconds(30);

var client = new TickTickClient("your-access-token", httpClient);
```

### Error Handling

```csharp
try 
{
    var task = await client.CreateTaskAsync(newTask);
}
catch (HttpRequestException ex)
{
    // Handle API errors
    Console.WriteLine($"API Error: {ex.Message}");
}
```

## 🧪 Testing

The library includes comprehensive integration tests. To run them:

1. Set up your TickTick access token:
   ```bash
   dotnet user-secrets set "TickTick:AccessToken" "your-token" --project src/TickTickSharp.Tests
   ```

2. Run the tests:
   ```bash
   dotnet test src/TickTickSharp.Tests
   ```

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request. For major changes, please open an issue first to discuss what you would like to change.

### Development Setup

1. Clone the repository
2. Install .NET 8 SDK
3. Set up your TickTick access token for testing
4. Run `dotnet build` to build the solution
5. Run `dotnet test` to execute tests

## 📝 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 🔗 Links

- [TickTick Open API Documentation](https://developer.ticktick.com/)
- [TickTick Developer Console](https://developer.ticktick.com/)
- [NuGet Package](https://www.nuget.org/packages/TickTickSharp/)

## ⚠️ Disclaimer

This is an unofficial library and is not affiliated with, endorsed by, or connected to TickTick or Appest Inc. TickTick is a trademark of Appest Inc.