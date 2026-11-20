using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediCare.Infrastructure.Repository.Migrations
{
    /// <inheritdoc />
    public partial class ProtectUniqueScheduleSlots : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("IF EXISTS (SELECT 1 FROM [Slots] GROUP BY [ClinicDoctorId], [SlotDateTime] HAVING COUNT(*) > 1) THROW 51000, 'Duplicate doctor time slots exist. Resolve associated appointments before applying this migration.', 1;");

            migrationBuilder.DropIndex(
                name: "IX_Slots_ClinicDoctorId",
                table: "Slots");

            migrationBuilder.CreateIndex(
                name: "IX_Slots_ClinicDoctorId_SlotDateTime",
                table: "Slots",
                columns: new[] { "ClinicDoctorId", "SlotDateTime" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Slots_ClinicDoctorId_SlotDateTime",
                table: "Slots");

            migrationBuilder.CreateIndex(
                name: "IX_Slots_ClinicDoctorId",
                table: "Slots",
                column: "ClinicDoctorId");
        }
    }
}
