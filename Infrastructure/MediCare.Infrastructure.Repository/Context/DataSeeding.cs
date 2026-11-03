using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediCare.Core.Entity;
using MediCare.Core.Entity.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;



namespace MediCare.Infrastructure.Repository.Context
{

    public static class DataSeeding
    {
        public static async Task SeedAsync(
            DbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            // 1. Roles
            await SeedRolesAsync(roleManager);

            // 2. Identity Users
            var (doctorUser, patientUser) = await SeedUsersAsync(userManager);

            // 3. Geographic Data (MultiLanguage: EnName / ArName)
            var area = await SeedLocationsAsync(context);

            // 4. Specializations (MultiLanguage)
            var specialization = await SeedSpecializationsAsync(context);

            // 5. Clinic & Doctor
            var (clinic, doctor) = await SeedClinicAndDoctorAsync(context, area, specialization, doctorUser);

            // 6. ClinicDoctor Bridge
            var clinicDoctor = await SeedClinicDoctorAsync(context, clinic, doctor);

            // 7. Working Hours (TimeOnly)
            var workingHour = await SeedWorkingHoursAsync(context, clinicDoctor);

            // 8. Patient Profile (DateOnly)
            var patient = await SeedPatientAsync(context, patientUser);

            // 9. Slot & Appointment
            await SeedSlotAndAppointmentAsync(context, clinicDoctor, workingHour, patient);
        }

        private static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            string[] roles = { "Admin", "Doctor", "Patient" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }

        private static async Task<(ApplicationUser doctorUser, ApplicationUser patientUser)> SeedUsersAsync(
            UserManager<ApplicationUser> userManager)
        {
            // Admin
            var adminEmail = "admin@medicare.com";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                adminUser = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };
                var result = await userManager.CreateAsync(adminUser, "Admin@123456");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }

            // Doctor User
            var docEmail = "doctor@medicare.com";
            var doctorUser = await userManager.FindByEmailAsync(docEmail);
            if (doctorUser == null)
            {
                doctorUser = new ApplicationUser
                {
                    UserName = docEmail,
                    Email = docEmail,
                    EmailConfirmed = true
                };
                var result = await userManager.CreateAsync(doctorUser, "Doctor@123456");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(doctorUser, "Doctor");
                }
            }

            // Patient User
            var patEmail = "patient@medicare.com";
            var patientUser = await userManager.FindByEmailAsync(patEmail);
            if (patientUser == null)
            {
                patientUser = new ApplicationUser
                {
                    UserName = patEmail,
                    Email = patEmail,
                    EmailConfirmed = true
                };
                var result = await userManager.CreateAsync(patientUser, "Patient@123456");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(patientUser, "Patient");
                }
            }

            return (doctorUser, patientUser);
        }

        private static async Task<Area> SeedLocationsAsync(DbContext context)
        {
            var existingArea = await context.Set<Area>().FirstOrDefaultAsync();
            if (existingArea != null) return existingArea;

            var city = new City
            {
                EnName = "Cairo",
                ArName = "القاهرة",
                EnDescription = "Capital of Egypt",
                ArDescription = "عاصمة مصر"
            };

            await context.Set<City>().AddAsync(city);
            await context.SaveChangesAsync();

            var area = new Area
            {
                EnName = "Nasr City",
                ArName = "مدينة نصر",
                EnDescription = "Nasr City District",
                ArDescription = "حي مدينة نصر",
                CityId = city.CityId
            };

            await context.Set<Area>().AddAsync(area);
            await context.SaveChangesAsync();

            return area;
        }

        private static async Task<Specialization> SeedSpecializationsAsync(DbContext context)
        {
            var existingSpec = await context.Set<Specialization>().FirstOrDefaultAsync();
            if (existingSpec != null) return existingSpec;

            var specialization = new Specialization
            {
                EnName = "Cardiology",
                ArName = "أمراض القلب",
                EnDescription = "Heart and blood vessel treatments",
                ArDescription = "علاج أمراض القلب والأوعية الدموية"
            };

            await context.Set<Specialization>().AddAsync(specialization);
            await context.SaveChangesAsync();

            return specialization;
        }

        private static async Task<(Clinic clinic, Doctor doctor)> SeedClinicAndDoctorAsync(
            DbContext context, Area area, Specialization specialization, ApplicationUser doctorUser)
        {
            var clinic = await context.Set<Clinic>().FirstOrDefaultAsync();
            if (clinic == null)
            {
                clinic = new Clinic
                {
                    EnName = "MediCare Main Clinic",
                    ArName = "عيادة ميديكير الرئيسية",
                    EnDescription = "Main medical center",
                    ArDescription = "المركز الطبي الرئيسي",
                    AreaId = area.AreaId
                };
                await context.Set<Clinic>().AddAsync(clinic);
                await context.SaveChangesAsync();
            }

            var doctor = await context.Set<Doctor>().FirstOrDefaultAsync();
            if (doctor == null)
            {
                doctor = new Doctor
                {
                    SpecializationId = specialization.SpecializationId,
                    UserId = doctorUser.Id
                };
                await context.Set<Doctor>().AddAsync(doctor);
                await context.SaveChangesAsync();
            }

            return (clinic, doctor);
        }

        private static async Task<ClinicDoctor> SeedClinicDoctorAsync(DbContext context, Clinic clinic, Doctor doctor)
        {
            var clinicDoctor = await context.Set<ClinicDoctor>()
                .FirstOrDefaultAsync(cd => cd.ClinicId == clinic.ClinicId && cd.DoctorId == doctor.DoctorId);

            if (clinicDoctor == null)
            {
                clinicDoctor = new ClinicDoctor
                {
                    ClinicId = clinic.ClinicId,
                    DoctorId = doctor.DoctorId
                };
                await context.Set<ClinicDoctor>().AddAsync(clinicDoctor);
                await context.SaveChangesAsync();
            }

            return clinicDoctor;
        }

        private static async Task<WorkingHour> SeedWorkingHoursAsync(DbContext context, ClinicDoctor clinicDoctor)
        {
            var workingHour = await context.Set<WorkingHour>()
                .FirstOrDefaultAsync(w => w.ClinicDoctorId == clinicDoctor.ClinicDoctorId);

            if (workingHour == null)
            {
                workingHour = new WorkingHour
                {
                    ClinicDoctorId = clinicDoctor.ClinicDoctorId,
                    DayOfWeek = DayOfWeek.Sunday,
                    // TimeOnly used instead of TimeSpan
                    StartTime = new TimeOnly(9, 0),
                    EndTime = new TimeOnly(17, 0)
                };
                await context.Set<WorkingHour>().AddAsync(workingHour);
                await context.SaveChangesAsync();
            }

            return workingHour;
        }

        private static async Task<Patient> SeedPatientAsync(DbContext context, ApplicationUser patientUser)
        {
            var patient = await context.Set<Patient>().FirstOrDefaultAsync();
            if (patient == null)
            {
                patient = new Patient
                {
                    UserId = patientUser.Id,
                    // DateOnly used instead of DateTime
                    DateOfBirth = new DateOnly(1995, 1, 1)
                };
                await context.Set<Patient>().AddAsync(patient);
                await context.SaveChangesAsync();
            }

            return patient;
        }

        private static async Task SeedSlotAndAppointmentAsync(
DbContext context, ClinicDoctor clinicDoctor, WorkingHour workingHour, Patient patient)
        {
            var slot = await context.Set<Slot>().FirstOrDefaultAsync();
            if (slot == null)
            {
                slot = new Slot
                {
                    ClinicDoctorId = clinicDoctor.ClinicDoctorId,
                    IsAvailable = true
                };
                await context.Set<Slot>().AddAsync(slot);
                await context.SaveChangesAsync();
            }

            var appointment = await context.Set<Appointment>().FirstOrDefaultAsync();
            if (appointment == null)
            {
                appointment = new Appointment
                {
                    PatientId = patient.PatientId,
                    SlotId = slot.SlotId
                };
                await context.Set<Appointment>().AddAsync(appointment);
                await context.SaveChangesAsync();

                // Medical Record & Prescription
                var record = new MedicalRecord
                {
                    AppointmentId = appointment.AppointmentId, // uses AppointmentId, not Id
                    Diagnosis = "Checkup Routine"
                };
                await context.Set<MedicalRecord>().AddAsync(record);
                await context.SaveChangesAsync();

                var prescription = new Prescription
                {
                    MedicalRecordId = record.MedicalRecordId // uses MedicalRecordId, not Id
                };
                await context.Set<Prescription>().AddAsync(prescription);
                await context.SaveChangesAsync();
            }

        }
    }
}