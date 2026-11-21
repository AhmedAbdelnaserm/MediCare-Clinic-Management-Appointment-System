using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MediCare.Infrastructure.Repository.Migrations
{
    /// <inheritdoc />
    public partial class SeedSpecializations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Specializations",
                columns: new[] { "SpecializationId", "ArDescription", "ArName", "CreationTime", "CreatorUserId", "DeleteStatusId", "EnDescription", "EnName", "LastModificationTime", "LastModifierUserId" },
                values: new object[,]
                {
                    { 1, "", "الباطنة", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Internal Medicine", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, "", "القلب", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Cardiology", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, "", "المخ والأعصاب", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Neurology", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 4, "", "طب الأطفال", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Pediatrics", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 5, "", "الأمراض الجلدية", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Dermatology", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 6, "", "جراحة العظام", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Orthopedics", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 7, "", "الجراحة العامة", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "General Surgery", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 8, "", "النساء والتوليد", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Obstetrics and Gynecology", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 9, "", "طب وجراحة العيون", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Ophthalmology", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 10, "", "الأنف والأذن والحنجرة", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "ENT", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 11, "", "المسالك البولية", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Urology", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 12, "", "أمراض الكلى", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Nephrology", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 13, "", "أمراض الصدر", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Chest Diseases", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 14, "", "الجهاز الهضمي والكبد", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Gastroenterology and Hepatology", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 15, "", "الغدد الصماء والسكر", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Endocrinology and Diabetes", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 16, "", "الطب النفسي", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Psychiatry", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 17, "", "الأورام", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Oncology", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 18, "", "أمراض الروماتيزم", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Rheumatology", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 19, "", "أمراض الدم", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Hematology", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 20, "", "طب الأسرة", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Family Medicine", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 21, "", "طب الطوارئ", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Emergency Medicine", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 22, "", "التخدير", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Anesthesiology", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 23, "", "طب الحالات الحرجة", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Critical Care Medicine", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 24, "", "الأشعة التشخيصية", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Diagnostic Radiology", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 25, "", "الباثولوجيا الإكلينيكية", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Clinical Pathology", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 26, "", "الطب الطبيعي والتأهيل", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Physical Medicine and Rehabilitation", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 27, "", "جراحة المخ والأعصاب", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Neurosurgery", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 28, "", "جراحة القلب والصدر", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Cardiothoracic Surgery", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 29, "", "جراحة الأوعية الدموية", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Vascular Surgery", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 30, "", "جراحة التجميل", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Plastic Surgery", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 31, "", "جراحة الأطفال", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Pediatric Surgery", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 32, "", "أمراض الذكورة", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Andrology", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 33, "", "الطب الاستوائي", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Tropical Medicine", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 34, "", "طب المسنين", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Geriatrics", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 35, "", "طب الأسنان", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Dentistry", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 36, "", "العلاج الطبيعي", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Physiotherapy", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 37, "", "التغذية العلاجية", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Nutrition", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 38, "", "القسطرة التداخلية للقلب", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Interventional Cardiology", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 39, "", "قلب الأطفال", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Pediatric Cardiology", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 40, "", "الفسيولوجيا العصبية", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Neurophysiology", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 41, "", "أمراض الكبد", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Hepatology", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 42, "", "حديثو الولادة", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Neonatology", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 43, "", "جراحة الأورام", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Surgical Oncology", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 44, "", "الأشعة التداخلية", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Interventional Radiology", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 45, "", "العقم وأطفال الأنابيب", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Infertility and IVF", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 46, "", "الجلدية والتجميل", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Cosmetic Dermatology", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 47, "", "جراحة العمود الفقري", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Spine Surgery", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 48, "", "مسالك بولية الأطفال", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Pediatric Urology", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 49, "", "جراحات السمنة", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Bariatric Surgery", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 50, "", "علاج الألم", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Pain Management", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 51, "", "طب نقل الدم", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Blood Transfusion Medicine", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 52, "", "الحساسية والمناعة", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Allergy and Immunology", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 53, "", "الأمراض المعدية", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Infectious Diseases", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 54, "", "الوراثة الطبية", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Medical Genetics", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 55, "", "الطب المهني", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Occupational Medicine", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 56, "", "الطب النووي", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Nuclear Medicine", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 57, "", "السمعيات", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Audiology", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 58, "", "التخاطب وعلاج النطق", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Speech and Language Therapy", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 59, "", "جراحة الفم والوجه والفكين", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Oral and Maxillofacial Surgery", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 60, "", "تقويم الأسنان", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Orthodontics", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 61, "", "طب أسنان الأطفال", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Pediatric Dentistry", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 62, "", "علاج جذور الأسنان", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Endodontics", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 63, "", "أمراض وجراحة اللثة", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Periodontology", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 64, "", "تركيبات الأسنان", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Prosthodontics", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 65, "", "جراحة اليد", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Hand Surgery", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 66, "", "جراحة القولون والمستقيم", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Colorectal Surgery", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 67, "", "جراحة الثدي", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Breast Surgery", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 68, "", "طب النوم", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Sleep Medicine", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 68);
        }
    }
}
