using Bumbo.Domain.Models;
using Bumbo.Domain.Services.Branches;
using Bumbo.Domain.Services.Employees;
using Bumbo.Domain.Services.OpeningDays;
using Bumbo.Domain.Services.Standards;
using Bumbo.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Bumbo.Web.Controllers
{
    [Authorize(Roles = "Manager, Systeembeheerder")]
    public class BranchController : Controller
    {
        private readonly IBranch _serviceBranch;
        private readonly IOpeningDay _serviceOpeningDay;
        private readonly IEmployee _serviceEmployee;
        private readonly IStandard _serviceStandard;

        public BranchController(IBranch serviceBranch, IOpeningDay serviceOpeningDay, IEmployee serviceEmployee, IStandard serviceStandard)
        {
            _serviceBranch = serviceBranch;
            _serviceOpeningDay = serviceOpeningDay;
            _serviceEmployee = serviceEmployee;
            _serviceStandard = serviceStandard;
        }

        public ActionResult Index()
        {
            if (User.IsInRole("Systeembeheerder"))
                return View(_serviceBranch.GetAll());
            
            return View(_serviceBranch.GetAll(_serviceEmployee.getEmployeeById(this.User).BranchId));
        }

        public ActionResult Details(int id)
        {
            BranchViewModel viewModel = new BranchViewModel();
            FillViewModelData(id, viewModel);
            return View(viewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BranchViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                viewModel.AddOpeningDays();
                AssignWeekdayNames(viewModel);
                Branch branchModel = _serviceBranch.Create(viewModel.Branch);
                _serviceOpeningDay.Create(branchModel.BranchId, viewModel.OpeningDays);
                foreach (Standard standard in _serviceStandard.GetDefaultStandards())
                {
                    standard.BranchId = branchModel.BranchId;
                    _serviceStandard.Create(standard);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            BranchViewModel viewModel = new BranchViewModel();
            FillViewModelData(id, viewModel);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BranchViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    AssignWeekdayNames(viewModel);
                    _serviceOpeningDay.Update(_serviceBranch.Update(viewModel.Branch).BranchId, new List<OpeningDay>()
                    {
                        viewModel.Monday, viewModel.Tuesday, viewModel.Wednesday, viewModel.Thursday, viewModel.Friday, viewModel.Saturday, viewModel.Sunday
                    });
                    return RedirectToAction(nameof(Index));
                }
                catch {}
            }
            return View(viewModel);
        }

        private void AssignWeekdayNames(BranchViewModel viewModel)
        {
            viewModel.Monday.DayOfWeek = DayOfWeek.Monday;
            viewModel.Tuesday.DayOfWeek = DayOfWeek.Tuesday;
            viewModel.Wednesday.DayOfWeek = DayOfWeek.Wednesday;
            viewModel.Thursday.DayOfWeek = DayOfWeek.Thursday;
            viewModel.Friday.DayOfWeek = DayOfWeek.Friday;
            viewModel.Saturday.DayOfWeek = DayOfWeek.Saturday;
            viewModel.Sunday.DayOfWeek = DayOfWeek.Sunday;
        }

        private void FillViewModelData(int branchId, BranchViewModel viewModel)
        {
            viewModel.Branch = _serviceBranch.GetBranch(branchId);
            viewModel.Monday = _serviceOpeningDay.GetOpeningDay(branchId, DayOfWeek.Monday);
            viewModel.Tuesday = _serviceOpeningDay.GetOpeningDay(branchId, DayOfWeek.Tuesday);
            viewModel.Wednesday = _serviceOpeningDay.GetOpeningDay(branchId, DayOfWeek.Wednesday);
            viewModel.Thursday = _serviceOpeningDay.GetOpeningDay(branchId, DayOfWeek.Thursday);
            viewModel.Friday = _serviceOpeningDay.GetOpeningDay(branchId, DayOfWeek.Friday);
            viewModel.Saturday = _serviceOpeningDay.GetOpeningDay(branchId, DayOfWeek.Saturday);
            viewModel.Sunday = _serviceOpeningDay.GetOpeningDay(branchId, DayOfWeek.Sunday);
        }
    }
}
