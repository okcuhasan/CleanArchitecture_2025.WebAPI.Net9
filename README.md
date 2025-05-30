🧱 CleanArchitecture_2025

A scalable and maintainable .NET 9 Web API project designed with Clean Architecture principles. This solution applies modern design patterns and advanced libraries such as CQRS, MediatR, Mapster, OData, Soft Delete, Generic Repository, FluentValidation, Repository Pattern, Unit of Work, .NET Aspire, Minimal API, Scalar OpenAPI, and Exception Handling Middleware, offering a solid foundation for enterprise-level APIs.

🔧 Technologies Used

.NET 9.0 (Preview)

Clean Architecture

CQRS with MediatR

Mapster (Lightweight Mapping)

OData Support for IQueryable Queries

Entity Framework Core 9 + Fluent Configuration

TS.Result (Result Handling Pattern)

FluentValidation + Validation Behavior Pipeline

Soft Delete + Audit Tracking

Minimal API + Endpoint Route Grouping

Repository Pattern

Unit of Work Pattern

Scrutor (Automatic Dependency Injection)

.NET Aspire Integration

Scalar UI (OpenAPI Documentation instead of Swagger)

🧠 Architecture Overview

✅ Clean Architecture Layers

Domain: Business models and contracts (no external dependencies).

Application: CQRS commands/queries + use case orchestration.

Infrastructure: EF Core database access, repository implementations.

WebAPI: Presentation layer, endpoint mappings, exception handling.

⚙️ Features and Highlights

✨ CQRS Pattern with MediatR

EmployeeCreateCommand and EmployeeGetAllQuery demonstrate Command/Query segregation.

Handlers encapsulate business logic and repository operations.

🛡️ Validation Pipeline (FluentValidation)

Custom ValidationBehavior<TRequest, TResponse> integrated into MediatR pipeline.

Handles request validation before reaching handlers.

Validation failures are captured and returned with structured error messages.

🔀 Mapster for DTO Mapping

Lightweight and performant mapper to convert between command/query objects and entities.

📁 OData Integration

Enables filtering, sorting, pagination directly from the API with IQueryable support.

AppODataController provides GET endpoint with full OData capabilities.

🗃️ Entity Framework Core 9

ApplicationDbContext with overridden SaveChangesAsync to support:

Automatic CreatedAt, UpdatedAt, DeletedAt tracking.

Enforced Soft Delete — throws exception on hard deletes.

📅 Repository Pattern

IEmployeeRepository abstraction and EF Core-based implementation via GenericRepository.

Uses TS.EntityFrameworkCore.GenericRepository NuGet for boilerplate-free repositories.

🔒 Unit of Work Pattern

All repository operations wrapped in a UnitOfWork.

Ensures atomic database operations and consistent transaction boundaries.

🚦 Exception Middleware

Custom ExceptionHandler class captures all exceptions globally.

Handles FluentValidation.ValidationException distinctly.

Returns errors via TS.Result.Failure(...).

⚡ Minimal APIs & Route Grouping

Modular route definitions using EndpointRouteBuilder.MapGroup.

Example: EmployeeModule adds POST endpoint for employee creation.

📓 Scalar UI for OpenAPI

No Swagger used.

Scalar provides elegant and interactive OpenAPI documentation.

Launches from /scalar/v1.

🪜 .NET Aspire Integration

Supports hosting, diagnostics, and observability in microservices architecture.

Prepares services for distributed cloud-native environments.

🧪 Strong Coding Practices

.editorconfig, warnings treated as errors (<TreatWarningsAsErrors>true</TreatWarningsAsErrors>).

All layers use Nullable Reference Types for enhanced null-safety.

