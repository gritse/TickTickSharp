# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [2.0.0] - 2025-01-27

### Breaking Changes
- **Project.ViewMode**: Changed from `string?` to `ProjectViewMode?` enum
- **Project.Permission**: Changed from `string?` to `ProjectPermission?` enum
- **Project.Kind**: Changed from `string?` to `ProjectKind?` enum
- Migration required for any code using these properties with string literals

### Added
- **ProjectViewMode Enum**: Strongly-typed view mode with values: `List`, `Kanban`, `Timeline`
- **ProjectPermission Enum**: Strongly-typed permission with values: `Read`, `Write`, `Comment`
- **ProjectKind Enum**: Strongly-typed project kind with values: `Task`, `Note`
- **Project.InboxProjectId Constant**: Added `"inbox"` constant for the Inbox project identifier
- Proper enum parsing and serialization in ProjectMapper

### Changed
- README: Removed emojis from section headers for better accessibility
- README: Updated all examples to use new strongly-typed enums
- Test cases updated to use new enum values

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