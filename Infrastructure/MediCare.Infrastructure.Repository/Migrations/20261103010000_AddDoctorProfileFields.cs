using MediCare.Infrastructure.Repository.Context;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediCare.Infrastructure.Repository.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20261103010000_AddDoctorProfileFields")]
    public partial class AddDoctorProfileFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GraduationCertificate",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfileImage",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "Description", table: "Doctors");
            migrationBuilder.DropColumn(name: "GraduationCertificate", table: "Doctors");
            migrationBuilder.DropColumn(name: "ProfileImage", table: "Doctors");
        }
    }
}
