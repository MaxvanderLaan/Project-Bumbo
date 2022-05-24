using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bumbo.Domain.Migrations
{
    public partial class changeseeddata2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1,
                columns: new[] { "BirthDate", "TagId" },
                values: new object[] { new DateTime(1974, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2,
                columns: new[] { "City", "Country", "State", "StreetName", "TagId" },
                values: new object[] { "Deurne", "Nederland", "Noord-Brabant", "Lambiekweg", 1 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 3,
                column: "TagId",
                value: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1,
                columns: new[] { "BirthDate", "TagId" },
                values: new object[] { new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2,
                columns: new[] { "City", "Country", "State", "StreetName", "TagId" },
                values: new object[] { "Somewhere", "Jaman", "Nogsteedsniks", "WEetikNogSteedsNietStraat", 2 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 3,
                column: "TagId",
                value: 3);
        }
    }
}
