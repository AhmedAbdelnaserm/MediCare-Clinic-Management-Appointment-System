# MediCare architecture

The solution uses ASP.NET Core MVC for the web interface and keeps HTTP concerns at the outer edge of the application. The API hosts use the same application and infrastructure layers.

## Dependency direction

```text
Presentation (MVC / APIs)
        ↓
Application (use cases, app services, contracts, DTOs)
        ↓
Core (entities and repository contracts)

Infrastructure (EF Core, SQL Server, Identity, repositories)
        └──────── implements Core and application ports; registered by each host
```

The MVC controllers render views and map form view models to application DTOs. API controllers accept and return API DTOs. Application services hold workflow logic and call repository contracts or application-owned storage ports. DTO transformations are explicit in the application services, so the solution has no runtime object-mapping package or associated license configuration. Infrastructure contains persistence and private-file implementations and is wired only at each web host's composition root using `AddInfrastructure`.

## Projects

| Layer | Projects / location | Responsibility |
|---|---|---|
| Presentation | `MediCare.Presentation.Web.Frontend.Mvc` | MVC controllers, Areas, Razor views, view models, authentication UI |
| Presentation | `Presentation/Web/Backend` and `Presentation/Web/Identity` | REST API controllers, middleware, OpenAPI, host configuration |
| Application | `Application/Backend` and `Application/Identity` | Use cases, application service contracts, DTOs, mapping, private-storage ports |
| Core | `Core/MediCare.Core.Entity` | Clinic and user domain entities |
| Core | `Core/MediCare.Core.IRepository` | Repository and unit-of-work contracts |
| Infrastructure | `Infrastructure/MediCare.Infrastructure.Repository` | EF Core context, SQL Server mappings, repositories, Identity stores and DI |
| Shared | `Common` and `Presentation/Shared` | Cross-cutting primitives and presentation-only helpers |

## Local configuration

Connection strings and signing keys are intentionally absent from tracked configuration files. Use .NET User Secrets for local development, or environment variables in deployment.

```powershell
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "<your SQL Server connection string>" --project MediCare.Presentation.Web.Frontend.Mvc
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "<your SQL Server connection string>" --project Presentation/Web/Backend/MediCare.Presentation.Web.BackEnd.Api
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "<your SQL Server connection string>" --project Presentation/Web/Identity/MediCare.Presentation.Web.Identity.Api

dotnet user-secrets set "JWT:Key" "<a private key with at least 32 UTF-8 bytes>" --project Presentation/Web/Backend/MediCare.Presentation.Web.BackEnd.Api
dotnet user-secrets set "JWT:Key" "<the same private key>" --project Presentation/Web/Identity/MediCare.Presentation.Web.Identity.Api

dotnet user-secrets set "BootstrapSuperAdmin:Email" "<admin email>" --project Presentation/Web/Identity/MediCare.Presentation.Web.Identity.Api
dotnet user-secrets set "BootstrapSuperAdmin:Password" "<strong unique password>" --project Presentation/Web/Identity/MediCare.Presentation.Web.Identity.Api
dotnet user-secrets set "BootstrapSuperAdmin:FullName" "<admin full name>" --project Presentation/Web/Identity/MediCare.Presentation.Web.Identity.Api
```

The JWT issuer and audience defaults are in each API's `appsettings.json`; override them in the same secret store when needed. Keep private keys and real connection strings out of source control.

For browser clients hosted on a different origin, configure the exact trusted origins with `Cors:AllowedOrigins` (for example `Cors__AllowedOrigins__0=https://localhost:5001`). Cross-origin requests are denied by default when no origins are configured.

For the local SQL Server instance used during development, the connection string can be set with Windows integrated authentication:

```powershell
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=localhost;Database=MediCareProject;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=True" --project Presentation/Web/Identity/MediCare.Presentation.Web.Identity.Api
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=localhost;Database=MediCareProject;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=True" --project Presentation/Web/Backend/MediCare.Presentation.Web.BackEnd.Api
```

The MVC and Identity projects share a User Secrets ID, and the Infrastructure project reads that same store. The Backend API has a separate User Secrets ID. The Identity and Backend APIs must also share the same private `JWT:Key` value.

## Build and run

From the repository root:

```powershell
dotnet restore MediCare.slnx
dotnet build MediCare.slnx --no-restore
dotnet run --project MediCare.Presentation.Web.Frontend.Mvc
```

Run the Backend API and Identity API in separate terminals when those endpoints are needed:

```powershell
dotnet run --project Presentation/Web/Backend/MediCare.Presentation.Web.BackEnd.Api
dotnet run --project Presentation/Web/Identity/MediCare.Presentation.Web.Identity.Api
```

The Identity API seeds roles and the configured initial SuperAdmin during startup. Its database must already have the EF Core migrations applied, and the SuperAdmin credentials should be supplied through its configured secrets.

Apply the existing database migrations from the repository root before starting the APIs:

```powershell
dotnet ef database update --project Infrastructure/MediCare.Infrastructure.Repository --startup-project Presentation/Web/Identity/MediCare.Presentation.Web.Identity.Api
```

The migration design-time factory reads the shared User Secrets ID from the Infrastructure project and environment variables. Configure the connection string on the Identity API as shown above before running this command.

## Current product scope

The MVC sign-in flow, patient registration, doctor directory, booking, cancellation, rescheduling, and medical-record workflows are present. Booking reserves an available slot atomically and prevents two patients from claiming the same slot. SuperAdmins can create doctor accounts, assign doctors to clinics, configure up to two weekly work intervals per day, and generate slots. Clinic admins can manage their clinic's doctors, schedules, date exceptions, and appointments. Schedule times are stored as UTC.

The patient MVC portal exposes appointment history under `/Patient/Appointments`, records under `/Patient/MedicalRecords`, and patient registration from the login page. Doctors can create a medical record after their own completed appointment. Patients can read only their own records and attachments; doctors can read or attach files only to records belonging to their patients. Medical attachments accept PDF, JPEG, or PNG files up to 10 MB each, are signature-checked, and are stored outside `wwwroot` under `PrivateStorage:RootPath` (or the OS local application data directory by default). Keep this directory on private, backed-up storage and restrict its operating-system permissions to the application identity.

Appointments generate in-app notifications for the patient and doctor when booked, cancelled, or rescheduled. A background worker in the Backend API creates a deduplicated in-app reminder approximately 24 hours before a confirmed appointment. The Backend API must remain running for reminders to be created. Notifications are available in MVC at `/Notifications` and through `GET /api/notifications/mine` and `POST /api/notifications/{id}/read`. No email or SMS provider is configured.

Schedule exceptions support a closed date or one custom opening interval, set by clinic admins or SuperAdmins in MVC and by SuperAdmins through the API. After changing an exception, regenerate available times for that date. Existing booked appointments are preserved when working hours or exceptions change; only future unbooked slots are removed. All schedule values are interpreted as UTC.

The Backend API offers `GET /api/appointments/available`, `GET /api/appointments/mine`, `POST /api/appointments`, `POST /api/appointments/{appointmentId}/cancel`, and `POST /api/appointments/{appointmentId}/reschedule`; each requires a Patient JWT role. Medical records are available through `/api/medical-records` routes restricted to the Patient or Doctor role, with protected attachment upload and download endpoints. The SuperAdmin MVC portal and corresponding API routes support doctor and schedule setup. Public doctor-directory responses intentionally omit account email, phone, and identity ID.

For a first booking demonstration, migrate the database and start the Identity API so it seeds roles and the SuperAdmin. Sign in through the Identity API, then use the SuperAdmin token to create a doctor account, create a clinic, link that doctor to the clinic, configure UTC weekly hours, and generate slots. A patient can then register in MVC, sign in, and book, cancel, or reschedule an appointment. The Swagger pages for both APIs are available in Development.

Clinic-admin schedule and appointment screens, date exceptions, private clinical attachments, in-app notifications, and 24-hour reminders are implemented. A unique database index also prevents duplicate slots for the same doctor and time. Its migration stops with an explicit error if legacy duplicate rows exist; inspect their appointments and resolve those conflicts before retrying. A clean build validates compilation but does not validate database connectivity or the workflows against a live SQL Server instance. Apply the new migrations before starting the application; database execution remains dependent on your SQL Server configuration.
