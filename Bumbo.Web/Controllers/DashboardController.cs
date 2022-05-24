using Bumbo.Domain.Services.Dashboard;
using Bumbo.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bumbo.Web.Controllers
{
    [Authorize(Roles = "Medewerker, Manager, Systeembeheerder")]
    public class DashboardController : Controller
    {
        private readonly IDashboard _serviceDashboard;

        public DashboardController(IDashboard serviceDashboard)
        {
            _serviceDashboard = serviceDashboard;
        }
        // GET
        [Route("")]
        [Route("Dashboard")]
        public IActionResult Index()
        {
            _serviceDashboard.matchUserWithEmployee();
            DashboardModel dashboard = new DashboardModel();
            dashboard.managerRegistrations = _serviceDashboard.getManagerRegistrations(this.User);
            dashboard.managerAvailability = _serviceDashboard.getManagerAvailability(this.User);
            dashboard.medewerkerRegistrations = _serviceDashboard.getMedewerkerRegistrations(this.User);
            dashboard.medewerkerAvailability = _serviceDashboard.getMedewerkerAvailability(this.User);
            return View(dashboard);
        }
    }
}