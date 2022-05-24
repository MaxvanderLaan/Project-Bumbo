using System;
using Bumbo.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static Bumbo.Domain.Models.Department;

namespace Bumbo.Domain
{
    public class BumboContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public BumboContext(DbContextOptions<BumboContext> options) : base(options)
        {
        }

        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeHasDepartments> EmployeeHasDepartments { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<OpeningDay> OpeningDays { get; set; }
        public DbSet<Forecast> Forecasts { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Remuneration> Remunerations { get; set; }
        public DbSet<Availability> Availability { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Standard> Standards { get; set; }
        public DbSet<Function> Functions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // EmployeeHasDepartments cannot have two of the same keys combined (constraint)
            // (Id = 1, EmployeeId = 1, DepartmentId = 2) and another (Id = 2, EmployeeId = 1, DepartmentId = 2)
            modelBuilder.Entity<EmployeeHasDepartments>().HasKey(ehd => new { ehd.EmployeeId, ehd.DepartmentId });

            // Unique department code for each department
            // (DepartmentId = 1, DepartmentCode = "Agf") and another (DepartmentId = 2, DepartmentCode = "Agf")
            modelBuilder.Entity<Department>().HasIndex(d => d.Code).IsUnique();

            Department kas = new Department()
            {
                Id = 1,
                Name = DepartmentName.Kassa,
                Code = DepartmentCode.KAS
            };
            modelBuilder.Entity<Department>().HasData(kas);

            Department vak = new Department()
            {
                Id = 2,
                Name = DepartmentName.Vakkenvullen,
                Code = DepartmentCode.VAK
            };
            modelBuilder.Entity<Department>().HasData(vak);

            Department ver = new Department()
            {
                Id = 3,
                Name = DepartmentName.Vers,
                Code = DepartmentCode.VER
            };
            modelBuilder.Entity<Department>().HasData(ver);

            Branch BumboDeurne = new Branch()
            {
                BranchId = 1,
                Name = "Bumbo Deurne",
                PhoneNumber = "0689398732",
                Email = "bumbodeurne@bumbo.site",
                ZipCode = "6473HD",
                HouseNumber = "52B",
                StreetName = "Kerkstraat",
                City = "Deurne",
                State = "Noord-Brabant",
                Country = "Nederland",
                ShelvesLength = 10
            };

            modelBuilder.Entity<Branch>().HasData(BumboDeurne);
            
            Branch BumboDenBosch = new Branch()
            {
                BranchId = 2,
                Name = "Bumbo Den Bosch",
                PhoneNumber = "0689425732",
                Email = "bumbodenbosch@bumbo.site",
                ZipCode = "6173HD",
                HouseNumber = "2A",
                StreetName = "BoulevardLaantje",
                City = "Den Bosch",
                State = "Noord-Brabant",
                Country = "Nederland",
                ShelvesLength = 20
            };

            modelBuilder.Entity<Branch>().HasData(BumboDenBosch);

            Branch bumboVeghel = new Branch()
            {
                BranchId = 3,
                Name = "Bumbo Veghel",
                PhoneNumber = "0683445732",
                Email = "bumboveghel@bumbo.nl",
                ZipCode = "9054BZ",
                HouseNumber = "104",
                StreetName = "Industrieterrein",
                City = "Veghel",
                State = "Noord-Brabant",
                Country = "Nederland",
                ShelvesLength = 150
            };

            modelBuilder.Entity<Branch>().HasData(bumboVeghel);

            OpeningDay openingHours1 = new OpeningDay()
            {
                Id = 1,
                DayOfWeek = DayOfWeek.Monday,
                BranchId = BumboDeurne.BranchId,
                OpenTime = new TimeSpan(07, 00, 00),
                CloseTime = new TimeSpan(22, 00, 00),
            };
            modelBuilder.Entity<OpeningDay>().HasData(openingHours1);

            OpeningDay openingHours2 = new OpeningDay()
            {
                Id = 2,
                DayOfWeek = DayOfWeek.Tuesday,
                BranchId = BumboDeurne.BranchId,
                OpenTime = new TimeSpan(07, 00, 00),
                CloseTime = new TimeSpan(22, 00, 00),
            };
            modelBuilder.Entity<OpeningDay>().HasData(openingHours2);

            OpeningDay openingHours3 = new OpeningDay()
            {
                Id = 3,
                DayOfWeek = DayOfWeek.Wednesday,
                BranchId = BumboDeurne.BranchId,
                OpenTime = new TimeSpan(07, 00, 00),
                CloseTime = new TimeSpan(22, 00, 00),
            };
            modelBuilder.Entity<OpeningDay>().HasData(openingHours3);

            OpeningDay openingHours4 = new OpeningDay()
            {
                Id = 4,
                DayOfWeek = DayOfWeek.Thursday,
                BranchId = BumboDeurne.BranchId,
                OpenTime = new TimeSpan(07, 00, 00),
                CloseTime = new TimeSpan(22, 00, 00),
            };
            modelBuilder.Entity<OpeningDay>().HasData(openingHours4);

            OpeningDay openingHours5 = new OpeningDay()
            {
                Id = 5,
                DayOfWeek = DayOfWeek.Friday,
                BranchId = BumboDeurne.BranchId,
                OpenTime = new TimeSpan(07, 00, 00),
                CloseTime = new TimeSpan(22, 00, 00),
            };
            modelBuilder.Entity<OpeningDay>().HasData(openingHours5);

            OpeningDay openingHours6 = new OpeningDay()
            {
                Id = 6,
                DayOfWeek = DayOfWeek.Saturday,
                BranchId = BumboDeurne.BranchId,
                OpenTime = new TimeSpan(07, 00, 00),
                CloseTime = new TimeSpan(22, 00, 00),
            };
            modelBuilder.Entity<OpeningDay>().HasData(openingHours6);

            OpeningDay openingHours7 = new OpeningDay()
            {
                Id = 7,
                DayOfWeek = DayOfWeek.Sunday,
                BranchId = BumboDeurne.BranchId,
                OpenTime = new TimeSpan(07, 00, 00),
                CloseTime = new TimeSpan(22, 00, 00),
            };
            modelBuilder.Entity<OpeningDay>().HasData(openingHours7);

            OpeningDay openingHours8 = new OpeningDay()
            {
                Id = 8,
                DayOfWeek = DayOfWeek.Monday,
                BranchId = BumboDenBosch.BranchId,
                OpenTime = new TimeSpan(07, 00, 00),
                CloseTime = new TimeSpan(22, 00, 00),
            };
            modelBuilder.Entity<OpeningDay>().HasData(openingHours8);

            OpeningDay openingHours9 = new OpeningDay()
            {
                Id = 9,
                DayOfWeek = DayOfWeek.Tuesday,
                BranchId = BumboDenBosch.BranchId,
                OpenTime = new TimeSpan(07, 00, 00),
                CloseTime = new TimeSpan(22, 00, 00),
            };
            modelBuilder.Entity<OpeningDay>().HasData(openingHours9);

            OpeningDay openingHours10 = new OpeningDay()
            {
                Id = 10,
                DayOfWeek = DayOfWeek.Wednesday,
                BranchId = BumboDenBosch.BranchId,
                OpenTime = new TimeSpan(07, 00, 00),
                CloseTime = new TimeSpan(22, 00, 00),
            };
            modelBuilder.Entity<OpeningDay>().HasData(openingHours10);

            OpeningDay openingHours11 = new OpeningDay()
            {
                Id = 11,
                DayOfWeek = DayOfWeek.Thursday,
                BranchId = BumboDenBosch.BranchId,
                OpenTime = new TimeSpan(07, 00, 00),
                CloseTime = new TimeSpan(22, 00, 00),
            };
            modelBuilder.Entity<OpeningDay>().HasData(openingHours11);

            OpeningDay openingHours12 = new OpeningDay()
            {
                Id = 12,
                DayOfWeek = DayOfWeek.Friday,
                BranchId = BumboDenBosch.BranchId,
                OpenTime = new TimeSpan(07, 00, 00),
                CloseTime = new TimeSpan(22, 00, 00),
            };
            modelBuilder.Entity<OpeningDay>().HasData(openingHours12);

            OpeningDay openingHours13 = new OpeningDay()
            {
                Id = 13,
                DayOfWeek = DayOfWeek.Saturday,
                BranchId = BumboDenBosch.BranchId,
                OpenTime = new TimeSpan(07, 00, 00),
                CloseTime = new TimeSpan(22, 00, 00),
            };
            modelBuilder.Entity<OpeningDay>().HasData(openingHours13);

            OpeningDay openingHours14 = new OpeningDay()
            {
                Id = 14,
                DayOfWeek = DayOfWeek.Sunday,
                BranchId = BumboDenBosch.BranchId,
                OpenTime = new TimeSpan(07, 00, 00),
                CloseTime = new TimeSpan(22, 00, 00),
            };
            modelBuilder.Entity<OpeningDay>().HasData(openingHours14);

            OpeningDay openingHours15 = new OpeningDay()
            {
                Id = 15,
                DayOfWeek = DayOfWeek.Monday,
                BranchId = bumboVeghel.BranchId,
                OpenTime = new TimeSpan(07, 00, 00),
                CloseTime = new TimeSpan(22, 00, 00),
            };
            modelBuilder.Entity<OpeningDay>().HasData(openingHours15);

            OpeningDay openingHours16 = new OpeningDay()
            {
                Id = 16,
                DayOfWeek = DayOfWeek.Tuesday,
                BranchId = bumboVeghel.BranchId,
                OpenTime = new TimeSpan(07, 00, 00),
                CloseTime = new TimeSpan(22, 00, 00),
            };
            modelBuilder.Entity<OpeningDay>().HasData(openingHours16);

            OpeningDay openingHours17 = new OpeningDay()
            {
                Id = 17,
                DayOfWeek = DayOfWeek.Wednesday,
                BranchId = bumboVeghel.BranchId,
                OpenTime = new TimeSpan(07, 00, 00),
                CloseTime = new TimeSpan(22, 00, 00),
            };
            modelBuilder.Entity<OpeningDay>().HasData(openingHours17);

            OpeningDay openingHours18 = new OpeningDay()
            {
                Id = 18,
                DayOfWeek = DayOfWeek.Thursday,
                BranchId = bumboVeghel.BranchId,
                OpenTime = new TimeSpan(07, 00, 00),
                CloseTime = new TimeSpan(22, 00, 00),
            };
            modelBuilder.Entity<OpeningDay>().HasData(openingHours18);

            OpeningDay openingHours19 = new OpeningDay()
            {
                Id = 19,
                DayOfWeek = DayOfWeek.Friday,
                BranchId = bumboVeghel.BranchId,
                OpenTime = new TimeSpan(07, 00, 00),
                CloseTime = new TimeSpan(22, 00, 00),
            };
            modelBuilder.Entity<OpeningDay>().HasData(openingHours19);

            OpeningDay openingHours20 = new OpeningDay()
            {
                Id = 20,
                DayOfWeek = DayOfWeek.Saturday,
                BranchId = bumboVeghel.BranchId,
                OpenTime = new TimeSpan(07, 00, 00),
                CloseTime = new TimeSpan(22, 00, 00),
            };
            modelBuilder.Entity<OpeningDay>().HasData(openingHours20);

            OpeningDay openingHours21 = new OpeningDay()
            {
                Id = 21,
                DayOfWeek = DayOfWeek.Sunday,
                BranchId = bumboVeghel.BranchId,
                OpenTime = new TimeSpan(07, 00, 00),
                CloseTime = new TimeSpan(22, 00, 00),
            };
            modelBuilder.Entity<OpeningDay>().HasData(openingHours21);

            Forecast forecast1 = new Forecast()
            {
                ForecastId = 1,
                BranchId = BumboDeurne.BranchId,
                Date = new DateTime(2022, 1, 14),
                AmountOfCustomers = 200,
                RollContainers = 21,
                Description = "Het wordt een drukke dag!!",
                AmountOfStockClerks = 10,
                AmountOfCashiers = 10,
                AmountOfFresh = 10,
            };
            modelBuilder.Entity<Forecast>().HasData(forecast1);

            Forecast forecast2 = new Forecast()
            {
                ForecastId = 2,
                BranchId = BumboDeurne.BranchId,
                Date = new DateTime(2022, 1, 15),
                AmountOfCustomers = 273,
                RollContainers = 32,
                Description = "Het wordt nog drukker jongens. Harder werken jullie!",
                AmountOfStockClerks = 10,
                AmountOfCashiers = 20,
                AmountOfFresh = 5,
            };
            modelBuilder.Entity<Forecast>().HasData(forecast2);

            Forecast forecast3 = new Forecast()
            {
                ForecastId = 3,
                BranchId = BumboDeurne.BranchId,
                Date = new DateTime(2022, 1, 16),
                AmountOfCustomers = 163,
                RollContainers = 11,
                Description = "Nou ga maar lekker in je eentje werken, want het wordt rustig",
                AmountOfStockClerks = 30,
                AmountOfCashiers = 10,
                AmountOfFresh = 10,
            };
            modelBuilder.Entity<Forecast>().HasData(forecast3);

            Employee systeemBeheerder = new Employee()
            {
                EmployeeId = 1,
                TagId = null,
                BranchId = BumboDeurne.BranchId,
                FirstName = "Systeem",
                MiddleName = null,
                LastName = "Beheerder",
                Bsn = 123456789,
                Iban = "NL20INGB0001234567",
                Period = Period.Wekelijks,
                BirthDate = new DateTime(1974, 10, 10),
                ZipCode = "1234GG",
                HouseNumber = "12A",
                StreetName = "Bloemenlaantje",
                City = "Eindhoven",
                State = "Noord-Brabant",
                Country = "Nederland",
            };
            modelBuilder.Entity<Employee>().HasData(systeemBeheerder);

            Employee employeeJob = new Employee()
            {
                EmployeeId = 2,
                TagId = 1,
                BranchId = BumboDeurne.BranchId,
                FirstName = "Job",
                MiddleName = "van",
                LastName = "Koeveringe",
                Bsn = 090747843,
                Iban = "NL20INGB0007654321",
                Period = Period.Maandelijks,
                BirthDate = new DateTime(1999, 10, 10),
                ZipCode = "5463HD",
                HouseNumber = "25",
                StreetName = "Lambiekweg",
                City = "Deurne",
                State = "Noord-Brabant",
                Country = "Nederland",
            };
            modelBuilder.Entity<Employee>().HasData(employeeJob);

            Employee employeeLaser = new Employee()
            {
                EmployeeId = 3,
                TagId = 2,
                BranchId = BumboDeurne.BranchId,
                FirstName = "Laser",
                MiddleName = null,
                LastName = "Yesil",
                Bsn = 090747843,
                Iban = "NL20INGB1231231233",
                Period = Period.ElkeTweeWeken,
                BirthDate = new DateTime(1997, 02, 12),
                ZipCode = "2342HD",
                HouseNumber = "12",
                StreetName = "Seamastraart",
                City = "Pijndorp",
                State = "Noord-Brabant",
                Country = "Nederland",
            };
            modelBuilder.Entity<Employee>().HasData(employeeLaser);

            Registration registration1 = new Registration()
            {
                RegistrationId = 1,
                EmployeeId = employeeLaser.EmployeeId,
                StartDate = new DateTime(2022, 1, 12, 12, 00, 00),
                EndDate = new DateTime(2022, 1, 12, 17, 00, 00),
                CorrectClocking = true
            };
            modelBuilder.Entity<Registration>().HasData(registration1);

            Registration registration2 = new Registration()
            {
                RegistrationId = 2,
                EmployeeId = employeeLaser.EmployeeId,
                StartDate = new DateTime(2022, 1, 11, 07, 00, 00),
                EndDate = new DateTime(2022, 1, 11, 12, 00, 00),
                CorrectClocking = true,
            };
            modelBuilder.Entity<Registration>().HasData(registration2);

            Registration registration3 = new Registration()
            {
                RegistrationId = 3,
                EmployeeId = employeeLaser.EmployeeId,
                StartDate = new DateTime(2022, 1, 10, 17, 00, 00),
                EndDate = new DateTime(2022, 1, 10, 02, 00, 00),
                CorrectClocking = false,
            };
            modelBuilder.Entity<Registration>().HasData(registration3);

            Remuneration remuneration1 = new Remuneration()
            {
                RenumerationId = 1,
                IsApproved = false,
                EmployeeId = employeeLaser.EmployeeId,
                Hours = new TimeSpan(08, 00, 00),
                Date = new DateTime(2022, 1, 12),
                SurtaxRate = 50.0
            };
            modelBuilder.Entity<Remuneration>().HasData(remuneration1);

            Remuneration remuneration2 = new Remuneration()
            {
                RenumerationId = 2,
                IsApproved = false,
                EmployeeId = employeeLaser.EmployeeId,
                Hours = new TimeSpan(05, 00, 00),
                Date = new DateTime(2022, 1, 11),
                SurtaxRate = 50.0
            };
            modelBuilder.Entity<Remuneration>().HasData(remuneration2);

            Remuneration remuneration3 = new Remuneration()
            {
                RenumerationId = 3,
                IsApproved = false,
                EmployeeId = employeeJob.EmployeeId,
                Hours = new TimeSpan(06, 00, 00),
                Date = new DateTime(2022, 1, 10),
                SurtaxRate = 50.0
            };
            modelBuilder.Entity<Remuneration>().HasData(remuneration3);

            Remuneration remuneration4 = new Remuneration()
            {
                RenumerationId = 4,
                IsApproved = true,
                EmployeeId = employeeJob.EmployeeId,
                Hours = new TimeSpan(10, 00, 00),
                Date = new DateTime(2022, 1, 8),
                SurtaxRate = 50.0
            };
            modelBuilder.Entity<Remuneration>().HasData(remuneration4);

            Remuneration remuneration5 = new Remuneration()
            {
                RenumerationId = 5,
                IsApproved = false,
                EmployeeId = employeeJob.EmployeeId,
                Hours = new TimeSpan(10, 00, 00),
                Date = new DateTime(2022, 1, 6),
                SurtaxRate = 50.0
            };
            modelBuilder.Entity<Remuneration>().HasData(remuneration5);

            Remuneration remuneration6 = new Remuneration()
            {
                RenumerationId = 6,
                IsApproved = false,
                EmployeeId = employeeJob.EmployeeId,
                Hours = new TimeSpan(10, 00, 00),
                Date = new DateTime(2022, 1, 8),
                SurtaxRate = 50.0
            };
            modelBuilder.Entity<Remuneration>().HasData(remuneration6);

            Remuneration remuneration7 = new Remuneration()
            {
                RenumerationId = 7,
                IsApproved = false,
                EmployeeId = employeeLaser.EmployeeId,
                Hours = new TimeSpan(11, 34, 00),
                Date = new DateTime(2022, 1, 1),
                SurtaxRate = 38.1
            };
            modelBuilder.Entity<Remuneration>().HasData(remuneration7);

            Remuneration remuneration8 = new Remuneration()
            {
                RenumerationId = 8,
                IsApproved = false,
                EmployeeId = employeeLaser.EmployeeId,
                Hours = new TimeSpan(3, 59, 00),
                Date = new DateTime(2022, 1, 3),
                SurtaxRate = 13.9
            };
            modelBuilder.Entity<Remuneration>().HasData(remuneration8);

            Remuneration remuneration9 = new Remuneration()
            {
                RenumerationId = 9,
                IsApproved = false,
                EmployeeId = systeemBeheerder.EmployeeId,
                Hours = new TimeSpan(9, 06, 00),
                Date = new DateTime(2022, 1, 1),
                SurtaxRate = 48.3
            };
            modelBuilder.Entity<Remuneration>().HasData(remuneration9);

            Remuneration remuneration10 = new Remuneration()
            {
                RenumerationId = 10,
                IsApproved = false,
                EmployeeId = systeemBeheerder.EmployeeId,
                Hours = new TimeSpan(10, 00, 00),
                Date = new DateTime(2022, 1, 8),
                SurtaxRate = 9.2
            };
            modelBuilder.Entity<Remuneration>().HasData(remuneration10);

            EmployeeHasDepartments employeeAndDepartment1 = new EmployeeHasDepartments()
            {
                EmployeeId = employeeLaser.EmployeeId,
                DepartmentId = ver.Id,
            };
            modelBuilder.Entity<EmployeeHasDepartments>().HasData(employeeAndDepartment1);

            EmployeeHasDepartments employeeAndDepartment2 = new EmployeeHasDepartments()
            {
                EmployeeId = employeeLaser.EmployeeId,
                DepartmentId = vak.Id,
            };
            modelBuilder.Entity<EmployeeHasDepartments>().HasData(employeeAndDepartment2);

            EmployeeHasDepartments employeeAndDepartment3 = new EmployeeHasDepartments()
            {
                EmployeeId = employeeJob.EmployeeId,
                DepartmentId = ver.Id,
            };
            modelBuilder.Entity<EmployeeHasDepartments>().HasData(employeeAndDepartment3);

            EmployeeHasDepartments employeeAndDepartment4 = new EmployeeHasDepartments()
            {
                EmployeeId = employeeJob.EmployeeId,
                DepartmentId = vak.Id,
            };
            modelBuilder.Entity<EmployeeHasDepartments>().HasData(employeeAndDepartment4);

            Schedule schedule1 = new Schedule()
            {
                ScheduleId = 1,
                EmployeeId = employeeLaser.EmployeeId,
                DepartmentId = ver.Id,
                StartDate = new DateTime(2022, 1, 8, 9, 0, 0),
                EndDate = new DateTime(2022, 1, 8, 17, 0, 0),
                Finalised = true
            };
            modelBuilder.Entity<Schedule>().HasData(schedule1);

            Schedule schedule2 = new Schedule()
            {
                ScheduleId = 2,
                EmployeeId = employeeLaser.EmployeeId,
                DepartmentId = vak.Id,
                StartDate = new DateTime(2022, 1, 9, 9, 0, 0),
                EndDate = new DateTime(2022, 1, 9, 17, 0, 0),
                Finalised = false
            };
            modelBuilder.Entity<Schedule>().HasData(schedule2);

            Schedule schedule3 = new Schedule()
            {
                ScheduleId = 3,
                EmployeeId = employeeJob.EmployeeId,
                DepartmentId = ver.Id,
                StartDate = new DateTime(2022, 1, 8, 12, 0, 0),
                EndDate = new DateTime(2022, 1, 8, 17, 30, 0),
                Finalised = true
            };
            modelBuilder.Entity<Schedule>().HasData(schedule3);

            Schedule schedule4 = new Schedule()
            {
                ScheduleId = 4,
                EmployeeId = employeeJob.EmployeeId,
                DepartmentId = vak.Id,
                StartDate = new DateTime(2022, 1, 9, 12, 0, 0),
                EndDate = new DateTime(2022, 1, 9, 17, 30, 0),
                Finalised = false
            };
            modelBuilder.Entity<Schedule>().HasData(schedule4);

            Availability schoolAvailabilityTim = new Availability()
            {
                Id = 1,
                EmployeeId = employeeLaser.EmployeeId,
                Start = new DateTime(2022, 1, 09, 07, 00, 00),
                End = new DateTime(2022, 2, 09, 07, 00, 00),
                Type = Models.Availability.AvailabilityType.School,
                ApprovalStatus = Models.Availability.Status.Afwachtend
            };
            modelBuilder.Entity<Availability>().HasData(schoolAvailabilityTim);

            Availability schoolAvailabilityJob = new Availability()
            {
                Id = 2,
                EmployeeId = employeeLaser.EmployeeId,
                Start = new DateTime(2022, 1, 07, 07, 00, 00),
                End = new DateTime(2022, 2, 10, 07, 00, 00),
                Type = Models.Availability.AvailabilityType.School,
                ApprovalStatus = Models.Availability.Status.Goedgekeurd
            };
            modelBuilder.Entity<Availability>().HasData(schoolAvailabilityJob);

            Contract contractTim = new Contract()
            {
                ContractId = 1,
                EmployeeId = employeeLaser.EmployeeId,
                FunctionId = 1,
                Scale = 1,
                StartDate = new DateTime(2022, 6, 9),
                MinimalHours = 4,
            };
            modelBuilder.Entity<Contract>().HasData(contractTim);

            Contract contractJob = new Contract()
            {
                ContractId = 2,
                EmployeeId = employeeJob.EmployeeId,
                FunctionId = 2,
                Scale = 2,
                StartDate = new DateTime(2022, 01, 01),
                MinimalHours = 12,
            };
            modelBuilder.Entity<Contract>().HasData(contractJob);

            Standard normering1 = new Standard()
            {
                StandardId = 1,
                Activity = Activity.Coli,
                Norm = 5,
                Description = "Het aantal minuten wat nodig is om een coli uit te laden.",
                BranchId = BumboDeurne.BranchId
            };
            modelBuilder.Entity<Standard>().HasData(normering1);

            Standard normering2 = new Standard()
            {
                StandardId = 2,
                Activity = Activity.Restock,
                Norm = 30,
                Description = "Het aantal minuten wat nodig is om een coli bij te vullen bij de vakken.",
                BranchId = BumboDeurne.BranchId
            };
            modelBuilder.Entity<Standard>().HasData(normering2);

            Standard normering3 = new Standard()
            {
                StandardId = 3,
                Activity = Activity.Cashout,
                Norm = 30,
                Description = "Het aantal klanten wat één Kassière af kan handelen per uur aan de kassa.",
                BranchId = BumboDeurne.BranchId
            };
            modelBuilder.Entity<Standard>().HasData(normering3);

            Standard normering4 = new Standard()
            {
                StandardId = 4,
                Activity = Activity.Fresh,
                Norm = 100,
                Description = "Het aantal klanten wat een medewerker af kan handelen per uur bij de verse afdeling.",
                BranchId = BumboDeurne.BranchId
            };
            modelBuilder.Entity<Standard>().HasData(normering4);

            Standard normering5 = new Standard()
            {
                StandardId = 5,
                Activity = Activity.Mirror,
                Norm = 30,
                Description = "De tijd die nodig is in secondes om een meter aan spiegels schoon te poetsen.",
                BranchId = BumboDeurne.BranchId
            };
            modelBuilder.Entity<Standard>().HasData(normering5);

            Standard normering6 = new Standard()
            {
                StandardId = 6,
                Activity = Activity.Coli,
                Norm = 5,
                Description = "Het aantal minuten wat nodig is om een coli uit te laden.",
                BranchId = BumboDenBosch.BranchId
            };
            modelBuilder.Entity<Standard>().HasData(normering6);

            Standard normering7 = new Standard()
            {
                StandardId = 7,
                Activity = Activity.Restock,
                Norm = 30,
                Description = "Het aantal minuten wat nodig is om een coli bij te vullen bij de vakken.",
                BranchId = BumboDenBosch.BranchId
            };
            modelBuilder.Entity<Standard>().HasData(normering7);

            Standard normering8 = new Standard()
            {
                StandardId = 8,
                Activity = Activity.Cashout,
                Norm = 30,
                Description = "Het aantal klanten wat één Kassière af kan handelen per uur aan de kassa.",
                BranchId = BumboDenBosch.BranchId
            };
            modelBuilder.Entity<Standard>().HasData(normering8);

            Standard normering9 = new Standard()
            {
                StandardId = 9,
                Activity = Activity.Fresh,
                Norm = 100,
                Description = "Het aantal klanten wat een medewerker af kan handelen per uur bij de verse afdeling.",
                BranchId = BumboDenBosch.BranchId
            };
            modelBuilder.Entity<Standard>().HasData(normering9);

            Standard normering10 = new Standard()
            {
                StandardId = 10,
                Activity = Activity.Mirror,
                Norm = 30,
                Description = "De tijd die nodig is in secondes om een meter aan spiegels schoon te poetsen.",
                BranchId = BumboDenBosch.BranchId
            };
            modelBuilder.Entity<Standard>().HasData(normering10);

            Standard normering11 = new Standard()
            {
                StandardId = 11,
                Activity = Activity.Coli,
                Norm = 5,
                Description = "Het aantal minuten wat nodig is om een coli uit te laden.",
                BranchId = bumboVeghel.BranchId
            };
            modelBuilder.Entity<Standard>().HasData(normering11);

            Standard normering12 = new Standard()
            {
                StandardId = 12,
                Activity = Activity.Restock,
                Norm = 30,
                Description = "Het aantal minuten wat nodig is om een coli bij te vullen bij de vakken.",
                BranchId = bumboVeghel.BranchId
            };
            modelBuilder.Entity<Standard>().HasData(normering12);

            Standard normering13 = new Standard()
            {
                StandardId = 13,
                Activity = Activity.Cashout,
                Norm = 30,
                Description = "Het aantal klanten wat één Kassière af kan handelen per uur aan de kassa.",
                BranchId = bumboVeghel.BranchId
            };
            modelBuilder.Entity<Standard>().HasData(normering13);

            Standard normering14 = new Standard()
            {
                StandardId = 14,
                Activity = Activity.Fresh,
                Norm = 100,
                Description = "Het aantal klanten wat een medewerker af kan handelen per uur bij de verse afdeling.",
                BranchId = bumboVeghel.BranchId
            };
            modelBuilder.Entity<Standard>().HasData(normering14);

            Standard normering15 = new Standard()
            {
                StandardId = 15,
                Activity = Activity.Mirror,
                Norm = 30,
                Description = "De tijd die nodig is in secondes om een meter aan spiegels schoon te poetsen.",
                BranchId = bumboVeghel.BranchId
            };
            modelBuilder.Entity<Standard>().HasData(normering15);

            Function afdelingshoofd = new Function()
            {
                FunctionId = 1,
                Name = "Afdelingshoofd",
                DepartmentId = ver.Id,
            };
            modelBuilder.Entity<Function>().HasData(afdelingshoofd);

            Function slager = new Function()
            {
                FunctionId = 2,
                Name = "Slager",
                DepartmentId = ver.Id,
            };
            modelBuilder.Entity<Function>().HasData(slager);

            Function vakkenvuller = new Function()
            {
                FunctionId = 3,
                Name = "Vakkenvuller",
                DepartmentId = vak.Id,
            };
            modelBuilder.Entity<Function>().HasData(vakkenvuller);

            Function versMedewerker = new Function()
            {
                FunctionId = 4,
                Name = "Vers Medewerker",
                DepartmentId = ver.Id,
            };
            modelBuilder.Entity<Function>().HasData(versMedewerker);

            Function kassamedewerker = new Function()
            {
                FunctionId = 5,
                Name = "Kassa Medewerker",
                DepartmentId = kas.Id,
            };
            modelBuilder.Entity<Function>().HasData(kassamedewerker);
        }
    }
}
