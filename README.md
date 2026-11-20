# MediCare — Clinic Management & Appointment System

MediCare is a clinic operations and appointment platform built with ASP.NET Core MVC, REST APIs, ASP.NET Core Identity, Entity Framework Core, and SQL Server. It supports patient, doctor, clinic administrator, and platform administrator workflows.

## What it does

- Patients can create an account, browse doctors, view availability, and book, cancel, or reschedule appointments.
- Doctors can manage their appointments and add clinical notes, diagnoses, and prescriptions after eligible visits.
- Clinic administrators can manage clinic schedules, exceptions, and appointments.
- SuperAdmins can create doctor accounts, assign doctors to clinics, and configure schedules.
- Patients and their doctors can access authorized medical records and private PDF, JPEG, or PNG attachments.
- In-app notifications cover appointment updates; the Backend API also creates deduplicated reminders about 24 hours before confirmed appointments.
- Slot booking is protected against competing requests, with a database uniqueness constraint as an additional safeguard.

## Architecture

The solution follows an MVC and Clean Architecture separation:

```text
MediCare.Presentation.Web.Frontend.Mvc    MVC web application
Presentation/Web/{Identity,Backend}       Identity and business REST APIs
Application/{Identity,Backend}            Use cases, services, and DTOs
Core                                      Domain entities and repository contracts
Infrastructure                            EF Core, SQL Server, repositories, and storage
Common, Presentation/Shared               Shared primitives and web configuration
```

The web hosts are composition roots. Application workflows depend on core contracts; infrastructure implements persistence and private file storage. See [docs/architecture.md](docs/architecture.md) for the dependency map, configuration, migrations, API routes, and operational details.

## Requirements

- .NET 10 SDK
- SQL Server
- .NET User Secrets or environment variables for connection strings and JWT signing keys
- `dotnet-ef` CLI tool to apply database migrations:

  ```powershell
  dotnet tool install --global dotnet-ef --version 10.*
  ```

## Run locally

1. Clone the repository and configure the local secrets described in [docs/architecture.md](docs/architecture.md). Do not put real connection strings, JWT keys, or administrator passwords in tracked files.
2. Restore and build the solution:

   ```powershell
   dotnet restore MediCare.slnx
   dotnet build MediCare.slnx --no-restore
   ```

3. Apply the EF Core migrations to the configured database:

   ```powershell
   dotnet ef database update --project Infrastructure/MediCare.Infrastructure.Repository --startup-project Presentation/Web/Identity/MediCare.Presentation.Web.Identity.Api
   ```

4. Start the Identity API, Backend API, and MVC application in separate terminals:

   ```powershell
   dotnet run --project Presentation/Web/Identity/MediCare.Presentation.Web.Identity.Api
   dotnet run --project Presentation/Web/Backend/MediCare.Presentation.Web.BackEnd.Api
   dotnet run --project MediCare.Presentation.Web.Frontend.Mvc
   ```

The Identity API seeds the application roles and creates the initial SuperAdmin when bootstrap credentials are configured. Both APIs must use the same JWT signing key. The Backend API must remain running for scheduled reminders.

## Local addresses

The launch profiles use these local addresses:

| Application | HTTP | HTTPS |
|---|---|---|
| MVC | `http://localhost:5261` | `https://localhost:7072` |
| Identity API | `http://localhost:5232/swagger` | `https://localhost:7252/swagger` |
| Backend API | `http://localhost:5270/swagger` | `https://localhost:7246/swagger` |

Swagger is enabled in the Development environment. Local HTTPS requires a trusted ASP.NET Core development certificate.

## Important behavior

- Schedule dates and times are stored and interpreted as UTC.
- Changing working hours or schedule exceptions preserves booked appointments. Regenerate slots after changing an exception.
- Attachments are stored outside `wwwroot`; configure private, backed-up storage and restrict access to the application identity.
- Notifications are in-app only. No email or SMS provider is configured.
- Automated unit and integration test projects are not currently included. A successful build and local smoke checks do not replace workflow and authorization tests.

## Team

- Ahmed Abdelnaser Mohamed Mohamed — Team Leader
- Islam Mahmoud Hussein Shaarawy
- Ahmed Waleed Mohamed Elharouny
- Khaled Waleed Mohamed Elharouny
- Yomna Mohammed Ahmed Mokhtar Sayed
- Nourhan Fouad Mohammed Abu sreaa

**Instructor:** Mohammed Amr
