using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediCare.Infrastructure.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddDoctorColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "DoctorDegree",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: true);

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

            migrationBuilder.AddColumn<string>(
                name: "ProfileImage",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: true);
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
                name: "DoctorDegree",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "EnDescription",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "EnName",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "ProfileImage",
                table: "Doctors");
        }
    }
}
