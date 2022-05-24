using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bumbo.Domain.Migrations
{
    public partial class changeseeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmployeeHasDepartments",
                keyColumns: new[] { "DepartmentId", "EmployeeId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "EmployeeHasDepartments",
                keyColumns: new[] { "DepartmentId", "EmployeeId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.UpdateData(
                table: "Availability",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EmployeeId", "End", "Start" },
                values: new object[] { 3, new DateTime(2022, 2, 9, 7, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 9, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Availability",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EmployeeId", "End", "Start" },
                values: new object[] { 3, new DateTime(2022, 2, 10, 7, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 7, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "BranchId",
                keyValue: 1,
                columns: new[] { "City", "Country", "Email", "Name", "PhoneNumber", "State", "StreetName" },
                values: new object[] { "Deurne", "Nederland", "bumbodeurne@bumbo.site", "Bumbo Deurne", "0689398732", "Noord-Brabant", "Kerkstraat" });

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "BranchId",
                keyValue: 2,
                columns: new[] { "Email", "PhoneNumber", "StreetName" },
                values: new object[] { "bumbodenbosch@bumbo.site", "0689425732", "BoulevardLaantje" });

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "BranchId",
                keyValue: 3,
                columns: new[] { "Email", "PhoneNumber", "StreetName" },
                values: new object[] { "bumboveghel@bumbo.nl", "0683445732", "Industrieterrein" });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 1,
                columns: new[] { "EmployeeId", "StartDate" },
                values: new object[] { 3, new DateTime(2022, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 2,
                column: "StartDate",
                value: new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "EmployeeHasDepartments",
                columns: new[] { "DepartmentId", "EmployeeId" },
                values: new object[,]
                {
                    { 3, 3 },
                    { 2, 3 }
                });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1,
                columns: new[] { "City", "Country", "FirstName", "HouseNumber", "LastName", "State", "StreetName" },
                values: new object[] { "Eindhoven", "Nederland", "Systeem", "12A", "Beheerder", "Noord-Brabant", "Bloemenlaantje" });

            migrationBuilder.UpdateData(
                table: "Forecasts",
                keyColumn: "ForecastId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Forecasts",
                keyColumn: "ForecastId",
                keyValue: 2,
                columns: new[] { "Date", "Description" },
                values: new object[] { new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Het wordt nog drukker jongens. Harder werken jullie!" });

            migrationBuilder.UpdateData(
                table: "Forecasts",
                keyColumn: "ForecastId",
                keyValue: 3,
                columns: new[] { "Date", "Description" },
                values: new object[] { new DateTime(2022, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nou ga maar lekker in je eentje werken, want het wordt rustig" });

            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumn: "RegistrationId",
                keyValue: 1,
                columns: new[] { "EmployeeId", "EndDate", "StartDate" },
                values: new object[] { 3, new DateTime(2022, 1, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 12, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumn: "RegistrationId",
                keyValue: 2,
                columns: new[] { "EmployeeId", "EndDate", "StartDate" },
                values: new object[] { 3, new DateTime(2022, 1, 11, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 11, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumn: "RegistrationId",
                keyValue: 3,
                columns: new[] { "EmployeeId", "EndDate", "StartDate" },
                values: new object[] { 3, new DateTime(2022, 1, 10, 2, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 10, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Remunerations",
                keyColumn: "RenumerationId",
                keyValue: 1,
                columns: new[] { "Date", "EmployeeId" },
                values: new object[] { new DateTime(2022, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 });

            migrationBuilder.UpdateData(
                table: "Remunerations",
                keyColumn: "RenumerationId",
                keyValue: 2,
                columns: new[] { "Date", "EmployeeId" },
                values: new object[] { new DateTime(2022, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 });

            migrationBuilder.UpdateData(
                table: "Remunerations",
                keyColumn: "RenumerationId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2022, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Remunerations",
                keyColumn: "RenumerationId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2022, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Remunerations",
                keyColumn: "RenumerationId",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2022, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Remunerations",
                keyColumn: "RenumerationId",
                keyValue: 6,
                column: "Date",
                value: new DateTime(2022, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 1,
                columns: new[] { "EmployeeId", "EndDate", "StartDate" },
                values: new object[] { 3, new DateTime(2022, 1, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 8, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 2,
                columns: new[] { "EmployeeId", "EndDate", "StartDate" },
                values: new object[] { 3, new DateTime(2022, 1, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 9, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 1, 8, 17, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 8, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 1, 9, 17, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 9, 12, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmployeeHasDepartments",
                keyColumns: new[] { "DepartmentId", "EmployeeId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "EmployeeHasDepartments",
                keyColumns: new[] { "DepartmentId", "EmployeeId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.UpdateData(
                table: "Availability",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EmployeeId", "End", "Start" },
                values: new object[] { 1, new DateTime(2021, 12, 9, 7, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 9, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Availability",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EmployeeId", "End", "Start" },
                values: new object[] { 1, new DateTime(2021, 12, 10, 7, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 7, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "BranchId",
                keyValue: 1,
                columns: new[] { "City", "Country", "Email", "Name", "PhoneNumber", "State", "StreetName" },
                values: new object[] { "BANANA", "BananaCountry", "JumboBanana@banana.nl", "Jumbo Banana", "089398732", "Bananana", "BAnananStreet" });

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "BranchId",
                keyValue: 2,
                columns: new[] { "Email", "PhoneNumber", "StreetName" },
                values: new object[] { "JumboDB@bumbo.nl", "0693128732", "Bumbo Boulevard" });

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "BranchId",
                keyValue: 3,
                columns: new[] { "Email", "PhoneNumber", "StreetName" },
                values: new object[] { "JumboVeghel@bumbo.nl", "0693121732", "Veghel Industrieterrein" });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 1,
                columns: new[] { "EmployeeId", "StartDate" },
                values: new object[] { 1, new DateTime(2021, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 2,
                column: "StartDate",
                value: new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "EmployeeHasDepartments",
                columns: new[] { "DepartmentId", "EmployeeId" },
                values: new object[,]
                {
                    { 3, 1 },
                    { 2, 1 }
                });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1,
                columns: new[] { "City", "Country", "FirstName", "HouseNumber", "LastName", "State", "StreetName" },
                values: new object[] { "BananaCity", "BananaCOUNTRY", "Tim", "5A", "Rietveld", "BANANA", "Bananastreet" });

            migrationBuilder.UpdateData(
                table: "Forecasts",
                keyColumn: "ForecastId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2021, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Forecasts",
                keyColumn: "ForecastId",
                keyValue: 2,
                columns: new[] { "Date", "Description" },
                values: new object[] { new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Het wordt nog drukker jongens. Harder werken jullie!@%^%^#$@&*#&!*(@*(" });

            migrationBuilder.UpdateData(
                table: "Forecasts",
                keyColumn: "ForecastId",
                keyValue: 3,
                columns: new[] { "Date", "Description" },
                values: new object[] { new DateTime(2021, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nou ga maar lekker in je eentje werken, want het wordt kapot rustig" });

            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumn: "RegistrationId",
                keyValue: 1,
                columns: new[] { "EmployeeId", "EndDate", "StartDate" },
                values: new object[] { 1, new DateTime(2021, 11, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 9, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumn: "RegistrationId",
                keyValue: 2,
                columns: new[] { "EmployeeId", "EndDate", "StartDate" },
                values: new object[] { 1, new DateTime(2021, 11, 9, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 9, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Registrations",
                keyColumn: "RegistrationId",
                keyValue: 3,
                columns: new[] { "EmployeeId", "EndDate", "StartDate" },
                values: new object[] { 1, new DateTime(2021, 11, 10, 2, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 9, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Remunerations",
                keyColumn: "RenumerationId",
                keyValue: 1,
                columns: new[] { "Date", "EmployeeId" },
                values: new object[] { new DateTime(2021, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.UpdateData(
                table: "Remunerations",
                keyColumn: "RenumerationId",
                keyValue: 2,
                columns: new[] { "Date", "EmployeeId" },
                values: new object[] { new DateTime(2021, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.UpdateData(
                table: "Remunerations",
                keyColumn: "RenumerationId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2021, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Remunerations",
                keyColumn: "RenumerationId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2021, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Remunerations",
                keyColumn: "RenumerationId",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2020, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Remunerations",
                keyColumn: "RenumerationId",
                keyValue: 6,
                column: "Date",
                value: new DateTime(2020, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 1,
                columns: new[] { "EmployeeId", "EndDate", "StartDate" },
                values: new object[] { 1, new DateTime(2021, 11, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 8, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 2,
                columns: new[] { "EmployeeId", "EndDate", "StartDate" },
                values: new object[] { 1, new DateTime(2021, 11, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 9, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 11, 8, 17, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 8, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "ScheduleId",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 11, 9, 17, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 9, 12, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
