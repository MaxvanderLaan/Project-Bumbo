using Bumbo.Domain.Models;
using Bumbo.Domain.Services.Branches;
using Bumbo.Domain.Services.Employees;
using Bumbo.Domain.Services.Forecasts;
using Bumbo.Domain.Services.Standards;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Bumbo.Web.Controllers
{
    [Authorize(Roles = "Manager, Systeembeheerder")]
    public class StandardController : Controller
    {
        private readonly IStandard _serviceStandard;
        private readonly IBranch _serviceBranch;
        private readonly IForecast _serviceForecast;
        private readonly IEmployee _serviceEmployee;

        public StandardController(IStandard serviceStandard, IBranch serviceBranch, IForecast serviceForecast, IEmployee serviceEmployee)
        {
            _serviceStandard = serviceStandard;
            _serviceBranch = serviceBranch;
            _serviceForecast = serviceForecast;
            _serviceEmployee = serviceEmployee;
        }

        public ActionResult Index()
        {
            List<Standard> _standards;
            if (this.User.IsInRole("Systeembeheerder"))
            {
                _standards = _serviceStandard.GetAll();
            } else
            {
                _standards = _serviceStandard.GetAll(_serviceEmployee.getEmployeeById(this.User).BranchId);
            }
            return View(_standards);
        }

        public ActionResult Create()
        {
            PrepBranchViewBag();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Standard model)
        {
            if (model.BranchId != 0)
            {
                model.Branch = _serviceBranch.GetBranch(model.BranchId);
                ModelState.Clear();
            }
            if (ModelState.IsValid)
            {
                _serviceStandard.Create(model);
                return RedirectToAction(nameof(Index));
            }
            PrepBranchViewBag();
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            Standard model = _serviceStandard.GetStandard(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Standard model)
        {
            if (ModelState.IsValid)
            {
                _serviceStandard.Update(model);
                return RedirectToAction(nameof(Index));
            }
            model.Branch = _serviceBranch.GetBranch(model.BranchId);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Standard model)
        {
            _serviceStandard.Delete(_serviceStandard.GetStandard(model.StandardId));
            return RedirectToAction(nameof(Index));
        }

        private void PrepBranchViewBag()
        {
            ViewBag.Branches = _serviceBranch.GetAll();
        }
    }
}
