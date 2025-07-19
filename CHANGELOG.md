# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.1.0] - 2025-07-20

### Added
- **TaskPriority Enum**: Strongly-typed priority field with enum values (None, Low, Medium, High)
- Type safety for task priorities preventing invalid priority values
- Proper mapping between TaskPriority.None and null API values

### Changed
- Task.Priority field changed from `int?` to `TaskPriority` with default value `TaskPriority.None`
- Updated test cases to use new TaskPriority enum values

## [1.0.0] - 2025-01-XX

### Added
- Initial release of TickTickSharp
- Full support for TickTick Open API
- Strongly-typed models with `TimeZoneInfo`, `RecurrencePattern`, and `Trigger` support
- Complete CRUD operations for tasks and projects
- Recurrence pattern support (daily, weekly, monthly, yearly)
- Smart reminder system with natural time expressions
- Subtask (checklist item) support
- Clean DTO/Mapper architecture
- Comprehensive integration tests
- XML documentation for all public APIs

### Features
- **Task Management**: Create, read, update, delete, and complete tasks
- **Project Management**: Full project lifecycle management
- **Recurrence Support**: Industry-standard RRULE format support
- **Timezone Handling**: Automatic conversion between `TimeZoneInfo` and API format
- **Reminders**: Multiple reminder types with flexible timing
- **Subtasks**: Checklist item management within tasks
- **Error Handling**: Comprehensive HTTP error handling
- **Async Support**: Full async/await pattern implementation