using MediCare.Infrastructure.Repository.Context;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediCare.Infrastructure.Repository.Migrations;

[DbContext(typeof(ApplicationDbContext))]
[Migration("20261123220000_AddClinicDoctorConsultationFee")]
public partial class AddClinicDoctorConsultationFee : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<decimal>(
            name: "ConsultationFee",
            table: "ClinicDoctors",
            type: "decimal(18,2)",
            nullable: false,
            defaultValue: 0m);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "ConsultationFee",
            table: "ClinicDoctors");
    }
}
