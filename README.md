## 1. Project Name
**MediCare — Clinic Management & Appointment System**

## 2. Project Idea

MediCare is a clinic management and appointment booking system that connects patients, doctors, and clinic operations through one platform.

The system enables patients to find doctors by specialization, view available appointment slots, and book appointments.
The backend calculates available slots based on working hours,schedule exceptions, and existing appointments.
Once a patient successfully books an available slot, the appointment is confirmed automatically without requiring doctor approval.
Doctors can manage their schedules and appointments and maintain medical records and prescriptions.
Administrators can manage users, specializations, doctor approvals, and system settings.

### Main Objectives
- Simplify the appointment booking process for patients.
- Help doctors manage their schedules and appointments.
- Prevent double booking and scheduling conflicts.
- Organize patient medical records and prescriptions.
- Provide administration tools for managing the platform.

## 3. Team Members

1. **Ahmed Abdelnaser Mohamed Mohamed** — Team Leader
2. Islam Mahmoud Hussein Shaarawy
3. Ahmed Waleed Mohamed Elharouny
4. Khaled Waleed Mohamed Elharouny
5. Yomna Mohammed Ahmed Mokhtar Sayed
6. Nourhan Fouad Mohammed Abu sreaa

## 4. Work Plan

The project will be implemented in phases. Specific deadlines and task owners will be agreed upon by the team.

| Phase | Activities | Expected Deliverables |
|---|---|---|
| 1. Requirements Analysis | Review requirements, identify users, and define business rules. | Requirements and Business Rules |
| 2. System Design | Design the ERD, entities, relationships, and architecture. | ERD and system design |
| 3. Database & Identity | Configure EF Core, database relationships, migrations, authentication, and authorization. | Database and Identity foundation |
| 4. Core Backend | Implement clinics, doctors, specializations, working hours, schedule exceptions, and availability calculation. | Core APIs and Available Slots API |
| 5. Appointment Management | Implement booking, cancellation, rescheduling, and conflict validation. | Appointment APIs |
| 6. Medical Records | Implement medical records and prescriptions. | Medical Records and Prescription APIs |
| 7. Frontend Integration | Connect the user interface with backend APIs. | Integrated application |
| 8. Testing | Test business rules, permissions, validation, and booking conflicts. | Test results and bug fixes |
| 9. Documentation & Delivery | Complete documentation and prepare the final demonstration. | Final documentation and delivery |

## 5. Roles & Responsibilities

The following responsibilities are proposed and should be assigned to individual team members by agreement.

| Role | Responsibilities |
|---|---|
| Team Leader | Coordinate the team, track progress, review technical decisions, and monitor integration. |
| Requirements & Documentation | Document requirements, business rules, workflows, and project decisions. |
| Backend Development | Implement ASP.NET Core APIs, business logic, availability calculation, and appointment workflows. |
| Database & Identity | Design database relationships, configure EF Core, manage migrations, and implement authentication and authorization. |
| Frontend Development | Develop user interfaces and integrate them with backend APIs. |
| Testing & Quality Assurance | Prepare test cases, verify expected behavior, check permissions, and report defects. |
| Integration & Delivery | Coordinate integration, maintain project documentation, and prepare the final demonstration. |

Team members may share responsibilities. Individual assignments will be documented once agreed upon.

## 6. KPIs (Key Performance Indicators)

The following indicators will be used to monitor project progress and quality. Numerical targets will be agreed upon by the team and instructor.

- **Milestone Completion:** Percentage of planned milestones completed on schedule.
- **Task Completion:** Percentage of assigned tasks completed and reviewed.
- **API Completion:** Percentage of required API endpoints implemented and tested.
- **Test Pass Rate:** Percentage of executed test cases that pass.
- **Booking Integrity:** No duplicate active bookings for overlapping time slots in tested scenarios.
- **Authorization:** Protected endpoints enforce the required permissions.
- **Defect Resolution:** Number of high-priority defects remaining before delivery.
- **Documentation Completion:** All required project documentation sections are completed.
- **Integration Readiness:** Core patient, doctor, and administrator workflows function end-to-end.

## 7. Instructor

**Mohammed Amr**

## 8. Project Files

The repository is expected to include the following files and artifacts as they are completed:

| File / Artifact | Description |
|---|---|
| `README.md` | Project overview, team information, work plan, responsibilities, KPIs, and project files. |
| Project Requirements | Original project brief and requirements. |
| Business Rules | Documented business rules and workflows. |
| ERD | Entity Relationship Diagram. |
| Source Code | Application projects and source files. |
| Database & Migrations | EF Core configuration and database migrations. |
| API Documentation | Swagger/OpenAPI documentation. |
| Tests | Unit and integration tests, when implemented. |
| Final Report & Presentation | Final project documentation and presentation, when prepared. |

Update this section with the actual repository paths and filenames as the project files are added.

## Technology Stack

- **Backend:** C#, ASP.NET Core
- **ORM & Database:** Entity Framework Core, SQL Server
- **Authentication & Authorization:** ASP.NET Core Identity
- **API Documentation:** Swagger / OpenAPI
- **Frontend:** According to the approved project implementation
- **Version Control:** Git and GitHub
