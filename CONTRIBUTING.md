# Contributing to TickTickSharp

Thank you for your interest in contributing to TickTickSharp! This document provides guidelines and information for contributors.

## 🚀 Getting Started

### Prerequisites
- .NET 8 SDK or later
- A TickTick developer account and access token for testing
- Git

### Setup
1. Fork the repository
2. Clone your fork:
   ```bash
   git clone https://github.com/your-username/TickTickSharp.git
   cd TickTickSharp
   ```
3. Build the solution:
   ```bash
   dotnet build src/TickTickSharp.sln
   ```
4. Set up your test token:
   ```bash
   dotnet user-secrets set "TickTick:AccessToken" "your-token" --project src/TickTickSharp.Tests
   ```
5. Run tests to ensure everything works:
   ```bash
   dotnet test src/TickTickSharp.Tests
   ```

## 🏗️ Project Structure

```
TickTickSharp/
├── src/
│   ├── TickTickSharp/              # Main library
│   │   ├── Client/                 # HTTP client and interfaces
│   │   ├── Models/                 # Public API models
│   │   │   └── Dto/               # Internal DTOs for JSON serialization
│   │   └── Mappers/               # Convert between models and DTOs
│   └── TickTickSharp.Tests/        # Integration tests
│       └── TestHelpers/           # Test utilities
├── README.md
├── LICENSE
└── CHANGELOG.md
```

## 🛠️ Development Guidelines

### Code Style
- Follow standard C# conventions
- Use meaningful variable and method names
- Add XML documentation for all public APIs
- Keep classes focused and follow single responsibility principle

### Architecture Principles
- **Clean Separation**: Public models should be clean and strongly-typed
- **Internal DTOs**: Use DTOs for JSON serialization to maintain API compatibility
- **Mappers**: Handle conversion between public models and DTOs
- **Async Patterns**: Use async/await throughout
- **Error Handling**: Provide clear, actionable error messages

### Adding New Features

#### 1. New API Endpoints
1. Add method to `ITickTickClient` interface
2. Implement in `TickTickClient` using DTO/Mapper pattern
3. Create DTOs if needed in `Models/Dto/`
4. Create mappers in `Mappers/`
5. Add integration tests

#### 2. New Models
1. Create clean public model in `Models/`
2. Create corresponding DTO in `Models/Dto/`
3. Create mapper in `Mappers/`
4. Add XML documentation
5. Add tests

### Testing
- **Integration Tests**: Test against real TickTick API
- **Test Helpers**: Use helper classes for creating test data
- **Clean Tests**: Each test should be independent and clean up after itself
- **Meaningful Names**: Test names should describe what they're testing

### Commit Guidelines
- Use clear, descriptive commit messages
- Follow conventional commit format when possible:
  - `feat: add support for task attachments`
  - `fix: handle null timezone values correctly`
  - `docs: update README with new examples`
  - `test: add integration tests for recurring tasks`

## 🐛 Bug Reports

When reporting bugs, please include:
- .NET version
- TickTickSharp version
- Clear steps to reproduce
- Expected vs actual behavior
- Relevant code samples
- Error messages (if any)

Use the bug report template when creating issues.

## 💡 Feature Requests

We welcome feature requests! Please:
- Check if the feature already exists or is planned
- Provide clear use cases and benefits
- Consider if it fits the library's scope and goals
- Be willing to help implement if possible

## 📝 Documentation

- Update README.md for new features
- Add XML documentation for all public APIs
- Update CHANGELOG.md
- Add code examples for complex features

## 🔄 Pull Request Process

1. **Fork & Branch**: Create a feature branch from `main`
2. **Implement**: Make your changes following the guidelines above
3. **Test**: Ensure all tests pass and add new tests for your changes
4. **Document**: Update documentation as needed
5. **PR**: Submit a pull request with:
   - Clear description of changes
   - Reference to related issues
   - Screenshots (if UI changes)
   - Test results

### PR Checklist
- [ ] Tests pass locally
- [ ] New tests added for new functionality
- [ ] Documentation updated
- [ ] CHANGELOG.md updated
- [ ] Code follows project conventions
- [ ] XML documentation added for public APIs

## 🏷️ Release Process

1. Update version in `TickTickSharp.csproj`
2. Update `CHANGELOG.md`
3. Create release tag
4. Publish to NuGet

## ❓ Questions?

Feel free to:
- Open a discussion for questions
- Reach out to maintainers
- Check existing issues and documentation

Thank you for contributing to TickTickSharp! 🎉