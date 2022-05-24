using Bumbo.Domain.Models;
using Bumbo.Domain.Services.Contracts;
using Bumbo.Domain.Services.Departments;
using Bumbo.Domain.Services.Employees;
using Bumbo.Domain.Services.Functions;
using Bumbo.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Bumbo.Web.Controllers
{
    [Authorize(Roles = "Manager, Systeembeheerder")]
    public class FunctionDepartmentController : Controller
    {
        private readonly IFunction _serviceFunction;
        private readonly IDepartment _serviceDepartment;
        private readonly IEmployee _serviceEmployee;
        private readonly IContract _serviceContract;

        public FunctionDepartmentController(IFunction serviceFunction, IDepartment serviceDepartment, IEmployee serviceEmployee, IContract serviceContract)
        {
            _serviceFunction = serviceFunction;
            _serviceDepartment = serviceDepartment;
            _serviceEmployee = serviceEmployee;
            _serviceContract = serviceContract;
        }

        public ActionResult Index()
        {
            FunctionDepartmentViewModel model = new FunctionDepartmentViewModel();
            model.Functions = _serviceFunction.GetAll();
            model.Departments = _serviceDepartment.GetAll();
            PrepViewbagDepartments();
            return View(model);
        }

        public ActionResult CreateFunction()
        {
            PrepViewbagDepartments();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateFunction(Function model)
        {
            if (ModelState.IsValid)
            {
                _serviceFunction.Create(model);
                return RedirectToAction(nameof(Index));
            }
            PrepViewbagDepartments();
            return View(model);
        }

        public ActionResult CreateDepartment()
        {
            return View();
        }

        public ActionResult EditFunction(int functionId)
        {
            PrepViewbagDepartments();
            return View(_serviceFunction.GetFunction(functionId));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditFunction(Function model)
        {
            if (model.DepartmentId != 0 && model.Name != null)
                ModelState.Clear();
            if (ModelState.IsValid)
            {
                _serviceFunction.Update(model);
                return RedirectToAction(nameof(Index));
            }
            PrepViewbagDepartments();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteFunction(Function model)
        {
            if (model.DepartmentId != 0 && model.Name != null)
                ModelState.Clear();
            if (!_serviceContract.GetAll().Any(c => c.Function.FunctionId == model.FunctionId))
            {
                _serviceFunction.Delete(model);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError("DeleteError", "Deze functie is nog actief in gebruik.");
                PrepViewbagDepartments();
                return View("EditFunction", model);
            }
        }

        private void PrepViewbagDepartments()
        {
            ViewBag.Departments = _serviceDepartment.GetAll();
        }
    }
}
