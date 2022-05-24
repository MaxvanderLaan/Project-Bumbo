using Bumbo.Domain.Services.Employees;
using Microsoft.AspNetCore.Mvc;
using Bumbo.Web.Models;
using Microsoft.AspNetCore.Authorization;

namespace Bumbo.Web.Controllers
{
    [Authorize(Roles = "Medewerker, Manager, Systeembeheerder")]
    public class ProfileController : Controller
    {
        private readonly IEmployee _employee;

        public ProfileController(IEmployee serviceEmployee)
        {
            _employee = serviceEmployee;
        }

        // GET: ProfileController
        public ActionResult Index()
        {
            ProfileModel data = new ProfileModel();
            data.Employee = _employee.getEmployeeById(this.User);
            data.Colleagues = _employee.getColleagues(this.User);
            return View(data);
        }
    }
}