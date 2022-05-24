using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bumbo.Domain.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    BranchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShelvesLength = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.BranchId);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TagId = table.Column<int>(type: "int", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    Bsn = table.Column<int>(type: "int", nullable: false),
                    Iban = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Period = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    HouseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Forecasts",
                columns: table => new
                {
                    ForecastId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    AmountOfCustomers = table.Column<int>(type: "int", nullable: false),
                    RollContainers = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmountOfCashiers = table.Column<int>(type: "int", nullable: true),
                    AmountOfStockClerks = table.Column<int>(type: "int", nullable: true),
                    AmountOfFresh = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forecasts", x => x.ForecastId);
                    table.ForeignKey(
                        name: "FK_Forecasts_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OpeningDays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    OpenTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    CloseTime = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpeningDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpeningDays_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Standards",
                columns: table => new
                {
                    StandardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Activity = table.Column<int>(type: "int", nullable: false),
                    Norm = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Standards", x => x.StandardId);
                    table.ForeignKey(
                        name: "FK_Standards_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Functions",
                columns: table => new
                {
                    FunctionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Functions", x => x.FunctionId);
                    table.ForeignKey(
                        name: "FK_Functions_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Availability",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    ApprovalStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Availability", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Availability_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeHasDepartments",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeHasDepartments", x => new { x.EmployeeId, x.DepartmentId });
                    table.ForeignKey(
                        name: "FK_EmployeeHasDepartments_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeHasDepartments_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Registrations",
                columns: table => new
                {
                    RegistrationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CorrectClocking = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registrations", x => x.RegistrationId);
                    table.ForeignKey(
                        name: "FK_Registrations_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Remunerations",
                columns: table => new
                {
                    RenumerationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hours = table.Column<TimeSpan>(type: "time", nullable: false),
                    SurtaxRate = table.Column<double>(type: "float", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Remunerations", x => x.RenumerationId);
                    table.ForeignKey(
                        name: "FK_Remunerations_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    ScheduleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Finalised = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.ScheduleId);
                    table.ForeignKey(
                        name: "FK_Schedules_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Schedules_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    ContractId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    FunctionId = table.Column<int>(type: "int", nullable: false),
                    Scale = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MinimalHours = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.ContractId);
                    table.ForeignKey(
                        name: "FK_Contracts_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contracts_Functions_FunctionId",
                        column: x => x.FunctionId,
                        principalTable: "Functions",
                        principalColumn: "FunctionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "BranchId", "City", "Country", "Email", "HouseNumber", "Name", "PhoneNumber", "ShelvesLength", "State", "StreetName", "ZipCode" },
                values: new object[,]
                {
                    { 1, "BANANA", "BananaCountry", "JumboBanana@banana.nl", "52B", "Jumbo Banana", "089398732", 10, "Bananana", "BAnananStreet", "6473HD" },
                    { 2, "Den Bosch", "Nederland", "JumboDB@bumbo.nl", "2A", "Bumbo Den Bosch", "0693128732", 20, "Noord-Brabant", "Bumbo Boulevard", "6173HD" },
                    { 3, "Veghel", "Nederland", "JumboVeghel@bumbo.nl", "104", "Bumbo Veghel", "0693121732", 150, "Noord-Brabant", "Veghel Industrieterrein", "9054BZ" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 1, 2, 0 },
                    { 2, 1, 2 },
                    { 3, 0, 1 }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "BirthDate", "BranchId", "Bsn", "City", "Country", "FirstName", "HouseNumber", "Iban", "LastName", "MiddleName", "Period", "State", "StreetName", "TagId", "ZipCode", "userId" },
                values: new object[,]
                {
                    { 1, new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 123456789, "BananaCity", "BananaCOUNTRY", "Tim", "5A", "NL20INGB0001234567", "Rietveld", null, 1, "BANANA", "Bananastreet", 1, "1234GG", null },
                    { 2, new DateTime(1999, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 90747843, "Somewhere", "Jaman", "Job", "25", "NL20INGB0007654321", "Koeveringe", "van", 5, "Nogsteedsniks", "WEetikNogSteedsNietStraat", 2, "5463HD", null },
                    { 3, new DateTime(1997, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 90747843, "Pijndorp", "Nederland", "Laser", "12", "NL20INGB1231231233", "Yesil", null, 2, "Noord-Brabant", "Seamastraart", 3, "2342HD", null }
                });

            migrationBuilder.InsertData(
                table: "Forecasts",
                columns: new[] { "ForecastId", "AmountOfCashiers", "AmountOfCustomers", "AmountOfFresh", "AmountOfStockClerks", "BranchId", "Date", "Description", "RollContainers" },
                values: new object[,]
                {
                    { 1, 10, 200, 10, 10, 1, new DateTime(2021, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Het wordt een drukke dag!!", 21 },
                    { 2, 20, 273, 5, 10, 1, new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Het wordt nog drukker jongens. Harder werken jullie!@%^%^#$@&*#&!*(@*(", 32 },
                    { 3, 10, 163, 10, 30, 1, new DateTime(2021, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nou ga maar lekker in je eentje werken, want het wordt kapot rustig", 11 }
                });

            migrationBuilder.InsertData(
                table: "Functions",
                columns: new[] { "FunctionId", "DepartmentId", "Name" },
                values: new object[,]
                {
                    { 1, 3, "Afdelingshoofd" },
                    { 3, 2, "Vakkenvuller" },
                    { 5, 1, "Kassa Medewerker" },
                    { 2, 3, "Slager" },
                    { 4, 3, "Vers Medewerker" }
                });

            migrationBuilder.InsertData(
                table: "OpeningDays",
                columns: new[] { "Id", "BranchId", "CloseTime", "DayOfWeek", "OpenTime" },
                values: new object[,]
                {
                    { 6, 1, new TimeSpan(0, 22, 0, 0, 0), 6, new TimeSpan(0, 7, 0, 0, 0) },
                    { 1, 1, new TimeSpan(0, 22, 0, 0, 0), 1, new TimeSpan(0, 7, 0, 0, 0) },
                    { 2, 1, new TimeSpan(0, 22, 0, 0, 0), 2, new TimeSpan(0, 7, 0, 0, 0) },
                    { 3, 1, new TimeSpan(0, 22, 0, 0, 0), 3, new TimeSpan(0, 7, 0, 0, 0) },
                    { 21, 3, new TimeSpan(0, 22, 0, 0, 0), 0, new TimeSpan(0, 7, 0, 0, 0) },
                    { 20, 3, new TimeSpan(0, 22, 0, 0, 0), 6, new TimeSpan(0, 7, 0, 0, 0) },
                    { 19, 3, new TimeSpan(0, 22, 0, 0, 0), 5, new TimeSpan(0, 7, 0, 0, 0) },
                    { 18, 3, new TimeSpan(0, 22, 0, 0, 0), 4, new TimeSpan(0, 7, 0, 0, 0) },
                    { 17, 3, new TimeSpan(0, 22, 0, 0, 0), 3, new TimeSpan(0, 7, 0, 0, 0) },
                    { 16, 3, new TimeSpan(0, 22, 0, 0, 0), 2, new TimeSpan(0, 7, 0, 0, 0) },
                    { 15, 3, new TimeSpan(0, 22, 0, 0, 0), 1, new TimeSpan(0, 7, 0, 0, 0) },
                    { 5, 1, new TimeSpan(0, 22, 0, 0, 0), 5, new TimeSpan(0, 7, 0, 0, 0) },
                    { 14, 2, new TimeSpan(0, 22, 0, 0, 0), 0, new TimeSpan(0, 7, 0, 0, 0) },
                    { 13, 2, new TimeSpan(0, 22, 0, 0, 0), 6, new TimeSpan(0, 7, 0, 0, 0) },
                    { 7, 1, new TimeSpan(0, 22, 0, 0, 0), 0, new TimeSpan(0, 7, 0, 0, 0) },
                    { 12, 2, new TimeSpan(0, 22, 0, 0, 0), 5, new TimeSpan(0, 7, 0, 0, 0) },
                    { 11, 2, new TimeSpan(0, 22, 0, 0, 0), 4, new TimeSpan(0, 7, 0, 0, 0) },
                    { 10, 2, new TimeSpan(0, 22, 0, 0, 0), 3, new TimeSpan(0, 7, 0, 0, 0) },
                    { 9, 2, new TimeSpan(0, 22, 0, 0, 0), 2, new TimeSpan(0, 7, 0, 0, 0) },
                    { 8, 2, new TimeSpan(0, 22, 0, 0, 0), 1, new TimeSpan(0, 7, 0, 0, 0) },
                    { 4, 1, new TimeSpan(0, 22, 0, 0, 0), 4, new TimeSpan(0, 7, 0, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "Standards",
                columns: new[] { "StandardId", "Activity", "BranchId", "Description", "Norm" },
                values: new object[,]
                {
                    { 6, 0, 2, "Het aantal minuten wat nodig is om een coli uit te laden.", 5 },
                    { 1, 0, 1, "Het aantal minuten wat nodig is om een coli uit te laden.", 5 },
                    { 2, 1, 1, "Het aantal minuten wat nodig is om een coli bij te vullen bij de vakken.", 30 },
                    { 15, 4, 3, "De tijd die nodig is in secondes om een meter aan spiegels schoon te poetsen.", 30 },
                    { 14, 3, 3, "Het aantal klanten wat een medewerker af kan handelen per uur bij de verse afdeling.", 100 },
                    { 13, 2, 3, "Het aantal klanten wat één Kassière af kan handelen per uur aan de kassa.", 30 },
                    { 4, 3, 1, "Het aantal klanten wat een medewerker af kan handelen per uur bij de verse afdeling.", 100 },
                    { 11, 0, 3, "Het aantal minuten wat nodig is om een coli uit te laden.", 5 },
                    { 3, 2, 1, "Het aantal klanten wat één Kassière af kan handelen per uur aan de kassa.", 30 },
                    { 5, 4, 1, "De tijd die nodig is in secondes om een meter aan spiegels schoon te poetsen.", 30 }
                });

            migrationBuilder.InsertData(
                table: "Standards",
                columns: new[] { "StandardId", "Activity", "BranchId", "Description", "Norm" },
                values: new object[,]
                {
                    { 10, 4, 2, "De tijd die nodig is in secondes om een meter aan spiegels schoon te poetsen.", 30 },
                    { 8, 2, 2, "Het aantal klanten wat één Kassière af kan handelen per uur aan de kassa.", 30 },
                    { 7, 1, 2, "Het aantal minuten wat nodig is om een coli bij te vullen bij de vakken.", 30 },
                    { 12, 1, 3, "Het aantal minuten wat nodig is om een coli bij te vullen bij de vakken.", 30 },
                    { 9, 3, 2, "Het aantal klanten wat een medewerker af kan handelen per uur bij de verse afdeling.", 100 }
                });

            migrationBuilder.InsertData(
                table: "Availability",
                columns: new[] { "Id", "ApprovalStatus", "EmployeeId", "End", "Start", "Type" },
                values: new object[,]
                {
                    { 1, 0, 1, new DateTime(2021, 12, 9, 7, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 9, 7, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 2, 1, new DateTime(2021, 12, 10, 7, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 7, 7, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.InsertData(
                table: "Contracts",
                columns: new[] { "ContractId", "EmployeeId", "EndDate", "FunctionId", "MinimalHours", "Scale", "StartDate" },
                values: new object[,]
                {
                    { 1, 1, null, 1, 4, 1, new DateTime(2021, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, null, 2, 12, 2, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "EmployeeHasDepartments",
                columns: new[] { "DepartmentId", "EmployeeId" },
                values: new object[,]
                {
                    { 2, 2 },
                    { 2, 1 },
                    { 3, 2 },
                    { 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "Registrations",
                columns: new[] { "RegistrationId", "CorrectClocking", "EmployeeId", "EndDate", "StartDate" },
                values: new object[,]
                {
                    { 1, true, 1, new DateTime(2021, 11, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 9, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, false, 1, new DateTime(2021, 11, 10, 2, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 9, 17, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, true, 1, new DateTime(2021, 11, 9, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 9, 7, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Remunerations",
                columns: new[] { "RenumerationId", "Date", "EmployeeId", "Hours", "IsApproved", "SurtaxRate" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new TimeSpan(0, 8, 0, 0, 0), false, 50.0 },
                    { 3, new DateTime(2021, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new TimeSpan(0, 6, 0, 0, 0), false, 50.0 },
                    { 4, new DateTime(2021, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new TimeSpan(0, 10, 0, 0, 0), true, 50.0 },
                    { 5, new DateTime(2020, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new TimeSpan(0, 10, 0, 0, 0), false, 50.0 },
                    { 6, new DateTime(2020, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new TimeSpan(0, 10, 0, 0, 0), false, 50.0 },
                    { 2, new DateTime(2021, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new TimeSpan(0, 5, 0, 0, 0), false, 50.0 }
                });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "ScheduleId", "DepartmentId", "EmployeeId", "EndDate", "Finalised", "StartDate" },
                values: new object[,]
                {
                    { 1, 3, 1, new DateTime(2021, 11, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2021, 11, 8, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, 2, new DateTime(2021, 11, 8, 17, 30, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2021, 11, 8, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 2, 2, new DateTime(2021, 11, 9, 17, 30, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2021, 11, 9, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, 1, new DateTime(2021, 11, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2021, 11, 9, 9, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Availability_EmployeeId",
                table: "Availability",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_EmployeeId",
                table: "Contracts",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_FunctionId",
                table: "Contracts",
                column: "FunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_Code",
                table: "Departments",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeHasDepartments_DepartmentId",
                table: "EmployeeHasDepartments",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_BranchId",
                table: "Employees",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Forecasts_BranchId",
                table: "Forecasts",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Functions_DepartmentId",
                table: "Functions",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_OpeningDays_BranchId",
                table: "OpeningDays",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_EmployeeId",
                table: "Registrations",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Remunerations_EmployeeId",
                table: "Remunerations",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_DepartmentId",
                table: "Schedules",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_EmployeeId",
                table: "Schedules",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Standards_BranchId",
                table: "Standards",
                column: "BranchId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Availability");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "EmployeeHasDepartments");

            migrationBuilder.DropTable(
                name: "Forecasts");

            migrationBuilder.DropTable(
                name: "OpeningDays");

            migrationBuilder.DropTable(
                name: "Registrations");

            migrationBuilder.DropTable(
                name: "Remunerations");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Standards");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Functions");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Branches");
        }
    }
}
