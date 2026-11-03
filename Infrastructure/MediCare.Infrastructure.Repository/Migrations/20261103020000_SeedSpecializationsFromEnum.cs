using System.Text.RegularExpressions;
using MediCare.Common.Enum;
using MediCare.Infrastructure.Repository.Context;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediCare.Infrastructure.Repository.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20261103020000_SeedSpecializationsFromEnum")]
    public partial class SeedSpecializationsFromEnum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("SET IDENTITY_INSERT [Specializations] ON;");

            foreach (var specialization in Enum.GetValues<SpecializationEnum>())
            {
                var name = Regex.Replace(specialization.ToString(), "([a-z0-9])([A-Z])", "$1 $2").Replace("'", "''");
                var id = (int)specialization;
                migrationBuilder.Sql($@"
IF EXISTS (SELECT 1 FROM [Specializations] WHERE [SpecializationId] = {id})
BEGIN
    UPDATE [Specializations]
    SET [EnName] = N'{name}', [ArName] = N'{name}',
        [EnDescription] = N'{name}', [ArDescription] = N'{name}',
        [DeleteStatusId] = 1
    WHERE [SpecializationId] = {id};
END
ELSE
BEGIN
    INSERT INTO [Specializations]
        ([SpecializationId], [DeleteStatusId], [CreationTime], [LastModificationTime], [CreatorUserId], [LastModifierUserId], [EnName], [ArName], [EnDescription], [ArDescription])
    VALUES
        ({id}, 1, SYSUTCDATETIME(), SYSUTCDATETIME(), NULL, NULL, N'{name}', N'{name}', N'{name}', N'{name}');
END");
            }

            migrationBuilder.Sql("SET IDENTITY_INSERT [Specializations] OFF;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var ids = string.Join(",", Enum.GetValues<SpecializationEnum>().Select(value => (int)value));
            migrationBuilder.Sql($@"
DELETE FROM [Specializations]
WHERE [SpecializationId] IN ({ids})
  AND NOT EXISTS (
      SELECT 1 FROM [Doctors]
      WHERE [Doctors].[SpecializationId] = [Specializations].[SpecializationId]);");
        }
    }
}
