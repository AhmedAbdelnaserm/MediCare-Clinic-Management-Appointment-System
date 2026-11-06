using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediCare.Infrastructure.Repository.Migrations
{
    /// <inheritdoc />
    public partial class createDoctor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
IF COL_LENGTH(N'dbo.Doctors', N'ArDescription') IS NULL
    ALTER TABLE [dbo].[Doctors] ADD [ArDescription] nvarchar(max) NOT NULL CONSTRAINT [DF_Doctors_ArDescription] DEFAULT N'';
IF COL_LENGTH(N'dbo.Doctors', N'ArName') IS NULL
    ALTER TABLE [dbo].[Doctors] ADD [ArName] nvarchar(max) NOT NULL CONSTRAINT [DF_Doctors_ArName] DEFAULT N'';
IF COL_LENGTH(N'dbo.Doctors', N'DoctorDegree') IS NULL
    ALTER TABLE [dbo].[Doctors] ADD [DoctorDegree] nvarchar(max) NULL;
IF COL_LENGTH(N'dbo.Doctors', N'EnDescription') IS NULL
    ALTER TABLE [dbo].[Doctors] ADD [EnDescription] nvarchar(max) NOT NULL CONSTRAINT [DF_Doctors_EnDescription] DEFAULT N'';
IF COL_LENGTH(N'dbo.Doctors', N'EnName') IS NULL
    ALTER TABLE [dbo].[Doctors] ADD [EnName] nvarchar(max) NOT NULL CONSTRAINT [DF_Doctors_EnName] DEFAULT N'';
IF COL_LENGTH(N'dbo.Doctors', N'ProfileImage') IS NULL
    ALTER TABLE [dbo].[Doctors] ADD [ProfileImage] nvarchar(max) NULL;
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // These columns may have existed before this migration was applied.
            // Keep Down empty so rollback cannot delete existing data.
        }
    }
}
