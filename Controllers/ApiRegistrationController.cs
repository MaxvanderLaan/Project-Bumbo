using Bumbo.Domain.Models;
using Bumbo.Domain.Services.Employees;
using Bumbo.Domain.Services.Registrations;
using Bumbo.Domain.Services.Remunerations;
using Microsoft.AspNetCore.Mvc;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bumbo.Web.Controllers
{
    [Route("api/registration")]
    [ApiController]
    public class ApiRegistrationController : ControllerBase
    {
        private readonly IRegistration _serviceRegistration;
        private readonly IRemuneration _serviceRemuneration;

        public ApiRegistrationController(IRegistration serviceRegistration, IRemuneration serviceRemuneration)
        {
            _serviceRegistration = serviceRegistration;
            _serviceRemuneration = serviceRemuneration;
        }

        // POST: /api/registration/nfcregistration?tagId=value&dateTime=val
        // Example: /api/registration/nfcregistration?tagId=1&dateTime=2021-12-29T20:00
        [Route("nfcregistration")]
        [HttpPost]
        public string nfcRegistration(int tagId, DateTime dateTime)
        {
            Registration result = _serviceRegistration.nfcRegistration(tagId, dateTime);
            if (result != null)
            {
                _serviceRemuneration.Create(result.StartDate, result.EndDate.Value, result.Employee, false);
            }
            return result != null ? "Succes" : "unKnownUser";
        }

        // POST: /api/registration/settagid?employeeId=value
        // Example: /api/registration/settagid?employeeId=2
        [Route("settagid")]
        [HttpPost]
        public int SetTagIdWithEmployeeId(int employeeId)
        {
            return _serviceRegistration.SetTagIdWithEmployeeId(employeeId);
        }

        // GET: api/registration/checkclocking
        // Example: /api/registration/checkclocking
        [Route("checkclocking")]
        [HttpPost]
        public void checkClocking()
        {
            _serviceRegistration.checkClocking();
        }
    }
}
