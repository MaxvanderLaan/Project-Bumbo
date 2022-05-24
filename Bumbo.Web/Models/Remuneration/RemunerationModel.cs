using Bumbo.Domain.Models;
using System;
using System.Collections.Generic;

namespace Bumbo.Web.Models.Remuneration
{
    public class RemunerationModel
    {
        public int EmployeeId { get; set; }
        public int BranchId { get; set; }
        public string Iban { get; set; }
        public Period Period { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string ZipCode { get; set; }
        public string HouseNumber { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public List<ApiRenumeration> Remunerations { get; set; }
    }

    public class ApiRenumeration
    {
        public int RenumerationId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Hours { get; set; }
        public double SurtaxRate { get; set; }
    }
}