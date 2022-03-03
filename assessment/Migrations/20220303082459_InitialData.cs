using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace assessment.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Onboarding",
                columns: new[] { "CustomerId", "Email", "LGA", "Password", "PhoneNumber", "StateofResidence" },
                values: new object[] { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "damolaajayi@gmail.com", "Saki-West", "damolaajayi", "07039121201", "OYO" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Onboarding",
                keyColumn: "CustomerId",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"));
        }
    }
}
