using Bumbo.Domain.Models;
using Bumbo.Domain.Services.Branches;
using Bumbo.Domain.Services.Remunerations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Bumbo.Web.Models.Remuneration;
using OfficeOpenXml.Table;
using Bumbo.Domain.Services.Employees;

namespace Bumbo.Web.Controllers
{
    [Authorize(Roles = "Manager, Systeembeheerder")]
    public class RemunerationController : Controller
    {
        private readonly IRemuneration _serviceRemuneration;
        private readonly IBranch _serviceBranch;
        private readonly IEmployee _serviceEmployee;

        public RemunerationController(IRemuneration serviceRemuneration, IBranch serviceBranch, IEmployee serviceEmployee)
        {
            _serviceRemuneration = serviceRemuneration;
            _serviceBranch = serviceBranch;
            _serviceEmployee = serviceEmployee;
        }

        public ActionResult Index()
        {
            RemunerationViewModel viewModel = new RemunerationViewModel();
            if (this.User.IsInRole("Systeembeheerder"))
            {
                viewModel.Remunerations = _serviceRemuneration.GetAll();
            } else
            {
                viewModel.Remunerations = _serviceRemuneration.GetAll(_serviceEmployee.getEmployeeById(this.User).BranchId);
            }
            PrepViewbagBranches();
            return View(viewModel);
        }

        public ActionResult Edit(int remunerationId)
        {
            return View(_serviceRemuneration.GetRemuneration(remunerationId));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Remuneration data)
        {
            if (ModelState.IsValid)
            {
                Remuneration model = _serviceRemuneration.GetRemuneration(data.RenumerationId);
                model.Hours = data.Hours;
                _serviceRemuneration.Edit(model);
                return RedirectToAction(nameof(Index));
            }
            data = _serviceRemuneration.GetRemuneration(data.RenumerationId);
            return View(data);
        }

        public ActionResult Filter(RemunerationViewModel remuneration)
        {
            RemunerationViewModel viewModel = new RemunerationViewModel();
            viewModel.Remunerations = _serviceRemuneration.Filter(remuneration.Model, remuneration.BranchId, remuneration.Year, remuneration.Weeknr);
            if (viewModel.Remunerations != null)
            {
                PrepViewbagBranches();
                return View("Index", viewModel);
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Approve(int id)
        {
            Remuneration model = _serviceRemuneration.FindRemuneration(id);
            model.IsApproved = true;
            _serviceRemuneration.Approve(model);
            return RedirectToAction("Index");
        }

        public void PrepViewbagBranches()
        {
            ViewBag.Branches = new List<SelectListItem>();
            if (this.User.IsInRole("Systeembeheerder"))
            {
                ViewBag.Branches.Add(new SelectListItem() { Text = "...", Value = "0" });
                ViewBag.Branches.AddRange(_serviceBranch.GetAll().Select(b => new SelectListItem() { Value = b.BranchId.ToString(), Text = b.Name }).ToList());
            }
            else
            {
                ViewBag.Branches.Add(new SelectListItem() { Text = "...", Value = _serviceEmployee.getEmployeeById(this.User).BranchId.ToString() });
                ViewBag.Branches.AddRange(_serviceBranch.GetAll(_serviceEmployee.getEmployeeById(this.User).BranchId).Select(b => new SelectListItem() { Value = b.BranchId.ToString(), Text = b.Name }).ToList());
            }
        }

        public IActionResult Download(RemunerationViewModel remunerationview)
        {
            List<Remuneration> remunerations = _serviceRemuneration.Filter(remunerationview.Model, remunerationview.BranchId, remunerationview.Year, remunerationview.Weeknr); //.GroupBy(r => r.EmployeeId).Select(s => s.ToList()).ToList();

            List<RemunerationDownloadModel> remunerationsExcel = new List<RemunerationDownloadModel>();
            foreach (Remuneration remuneration in remunerations)
            {
                RemunerationDownloadModel remunerationExcel = new RemunerationDownloadModel();
                remunerationExcel.RenumerationId = remuneration.RenumerationId;
                remunerationExcel.EmployeeId = remuneration.EmployeeId;
                remunerationExcel.Date = remuneration.Date.ToString("dd/MM/yyyy");
                remunerationExcel.Hours = remuneration.Hours.Value.TotalMinutes;
                remunerationExcel.SurtaxRate = remuneration.SurtaxRate;
                if (remuneration.IsApproved)
                {
                    remunerationExcel.IsApproved = "Ja";
                }
                else
                {
                    remunerationExcel.IsApproved = "Nee";
                }
                remunerationsExcel.Add(remunerationExcel);
            }
            remunerationsExcel.OrderBy(r => r.RenumerationId);

            List<Employee> employees = new List<Employee>();
            foreach (Remuneration remuneration in remunerations)
            {
                if (!employees.Contains(remuneration.Employee))
                {
                    employees.Add(remuneration.Employee);
                }
            }

            List<RemunerationDownloadEmployeeModel> employeesExcel = new List<RemunerationDownloadEmployeeModel>();
            foreach (Employee employee in employees)
            {
                RemunerationDownloadEmployeeModel employeeExcel = new RemunerationDownloadEmployeeModel();
                employeeExcel.EmployeeId = employee.EmployeeId;
                employeeExcel.BranchId = employee.BranchId;
                employeeExcel.Iban = employee.Iban;
                employeeExcel.Period = Enum.GetName(typeof(Period), employee.Period);
                employeeExcel.FirstName = employee.FirstName;
                employeeExcel.MiddleName = employee.MiddleName;
                employeeExcel.LastName = employee.LastName;
                employeeExcel.BirthDate = employee.BirthDate.ToString("dd/MM/yyyy");
                employeeExcel.ZipCode = employee.ZipCode;
                employeeExcel.HouseNumber = employee.HouseNumber;
                employeeExcel.StreetName = employee.StreetName;
                employeeExcel.City = employee.City;
                employeeExcel.State = employee.State;
                employeeExcel.Country = employee.Country;
                employeesExcel.Add(employeeExcel);
            }

            MemoryStream stream = new MemoryStream();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage package = new ExcelPackage(stream))
            {
                ExcelWorksheet workSheet = package.Workbook.Worksheets.Add("Vergoedingen");
                workSheet.Cells.LoadFromCollection(remunerationsExcel, true, TableStyles.Medium5);
                ExcelWorksheet workSheet2 = package.Workbook.Worksheets.Add("Werknemers");
                workSheet2.Cells.LoadFromCollection(employeesExcel, true, TableStyles.Medium5);
                package.Save();
            }
            stream.Position = 0;
            string excelName = $"Remunerations-{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.xlsx";
            return File(stream, "application/octet-stream", excelName);
        }
    }
}
