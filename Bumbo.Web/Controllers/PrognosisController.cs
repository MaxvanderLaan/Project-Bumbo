using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Bumbo.Domain.Services.Forecasts;
using Bumbo.Domain;
using Bumbo.Domain.Models;
using Microsoft.AspNetCore.Authorization;

namespace Bumbo.Web.Controllers
{
    [Authorize(Roles = "Manager, Systeembeheerder")]
    public class PrognosisController : Controller
    {
        private readonly BumboContext ctx;
        private readonly IForecast _serviceForcast;

        public PrognosisController(BumboContext bumboContext, IForecast serviceForcast)
        {
            ctx = bumboContext;
            _serviceForcast = serviceForcast;
        }

        public ActionResult Index()
        {
            ViewBag.Branches = ctx.Branches.ToList();
            return View(_serviceForcast.GetAll());
        }
        
        public JsonResult GetOneForecast(int id)
        {
            return Json(_serviceForcast.GetOne(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Forecast forecast)
        {
            _serviceForcast.Create(forecast);
            return RedirectToAction(nameof(Index));
        }

        // POST: PrognosisController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Forecast forecast)
        {
            _serviceForcast.Update(forecast);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Recalculate(Forecast forecast)
        {
            _serviceForcast.Recalculate(forecast);
            return RedirectToAction(nameof(Index));
        }
    }
}
