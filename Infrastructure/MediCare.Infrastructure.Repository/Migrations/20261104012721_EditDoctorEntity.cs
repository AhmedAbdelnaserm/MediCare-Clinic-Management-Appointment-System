using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediCare.Infrastructure.Repository.Migrations
{
    /// <inheritdoc />
    public partial class EditDoctorEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Doctors");

            migrationBuilder.RenameColumn(
                name: "GraduationCertificate",
                table: "Doctors",
                newName: "DoctorDegree");

            migrationBuilder.AddColumn<string>(
                name: "ArDescription",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ArName",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EnDescription",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EnName",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArDescription",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "ArName",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "EnDescription",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "EnName",
                table: "Doctors");

            migrationBuilder.RenameColumn(
                name: "DoctorDegree",
                table: "Doctors",
                newName: "GraduationCertificate");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
