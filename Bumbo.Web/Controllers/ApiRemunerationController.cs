using Bumbo.Domain.Models;
using Bumbo.Domain.Services.Remunerations;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Bumbo.Web.Models.Remuneration;

namespace Bumbo.Web.Controllers
{
    [Route("api/remuneration")]
    [ApiController]
    public class ApiRemunerationController : ControllerBase
    {
        private readonly IRemuneration _serviceRemuneration;

        public ApiRemunerationController(IRemuneration serviceRemuneration)
        {
            _serviceRemuneration = serviceRemuneration;
        }

        // GET: /api/remuneration?year=value&month=value&day=value
        [HttpGet]
        public string Get(int year, int month, int day)
        {
            List<RemunerationModel> jsonData = new List<RemunerationModel>();
            List<List<Remuneration>> RemunerationsListGroupByEmployeeId = _serviceRemuneration.GetRemunerations(year, month, day).Where(rem => rem.IsApproved == true).GroupBy(r => r.EmployeeId).Select(s => s.ToList()).ToList();
            foreach (List<Remuneration> currentEmployee in RemunerationsListGroupByEmployeeId)
            {
                Employee employee = currentEmployee[0].Employee;
                RemunerationModel dataRemuneration = new RemunerationModel();
                dataRemuneration.EmployeeId = employee.EmployeeId;
                dataRemuneration.BranchId = employee.BranchId;
                dataRemuneration.Iban = employee.Iban;
                dataRemuneration.Period = employee.Period;
                dataRemuneration.FirstName = employee.FirstName;
                dataRemuneration.MiddleName = employee.MiddleName;
                dataRemuneration.LastName = employee.LastName;
                dataRemuneration.BirthDate = employee.BirthDate;
                dataRemuneration.ZipCode = employee.ZipCode;
                dataRemuneration.HouseNumber = employee.HouseNumber;
                dataRemuneration.StreetName = employee.StreetName;
                dataRemuneration.City = employee.City;
                dataRemuneration.State = employee.State;
                dataRemuneration.Country = employee.Country;
                dataRemuneration.Remunerations = new List<ApiRenumeration>();

                foreach (Remuneration remuneration in currentEmployee)
                {
                    ApiRenumeration renumeration = new ApiRenumeration();
                    renumeration.RenumerationId = remuneration.RenumerationId;
                    renumeration.Date = remuneration.Date;
                    renumeration.Hours = remuneration.Hours.Value;
                    renumeration.SurtaxRate = remuneration.SurtaxRate;
                    dataRemuneration.Remunerations.Add(renumeration);
                }

                jsonData.Add(dataRemuneration);
            }
            return JsonConvert.SerializeObject(jsonData);
        }
    }
}
