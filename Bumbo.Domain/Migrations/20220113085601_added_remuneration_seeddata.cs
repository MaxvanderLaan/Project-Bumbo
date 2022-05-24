using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bumbo.Domain.Migrations
{
    public partial class added_remuneration_seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1,
                column: "BranchId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 3,
                column: "BranchId",
                value: 2);

            migrationBuilder.InsertData(
                table: "Remunerations",
                columns: new[] { "RenumerationId", "Date", "EmployeeId", "Hours", "IsApproved", "SurtaxRate" },
                values: new object[,]
                {
                    { 7, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new TimeSpan(0, 11, 34, 0, 0), false, 38.100000000000001 },
                    { 8, new DateTime(2022, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new TimeSpan(0, 3, 59, 0, 0), false, 13.9 },
                    { 9, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new TimeSpan(0, 9, 6, 0, 0), false, 48.299999999999997 },
                    { 10, new DateTime(2022, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new TimeSpan(0, 10, 0, 0, 0), false, 9.1999999999999993 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Remunerations",
                keyColumn: "RenumerationId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Remunerations",
                keyColumn: "RenumerationId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Remunerations",
                keyColumn: "RenumerationId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Remunerations",
                keyColumn: "RenumerationId",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1,
                column: "BranchId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 3,
                column: "BranchId",
                value: 1);
        }
    }
}
