using Microsoft.AspNetCore.Mvc;
using Bumbo.Domain.Models;
using Bumbo.Domain.Services.Employees;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Threading.Tasks;
using Bumbo.Web.Models.Employee;

namespace Bumbo.Web.Controllers
{
    [Authorize(Roles = "Manager, Systeembeheerder")]
    public class EmployeeController : Controller
    {
        private readonly IEmployee _serviceEmployee;

        public EmployeeController(IEmployee serviceEmployee)
        {
            _serviceEmployee = serviceEmployee;
        }

        public ActionResult Index()
        {
            ViewBag.Departments = _serviceEmployee.getDepartments();
            return View(_serviceEmployee.getEmloyeesWithDepartmens());
        }

        public ActionResult Create()
        {
            FillCreateViewBag();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateEmployeeModel model)
        {
            int bsn = 0;
            if (_serviceEmployee.CheckEmailExistAlready(model.Email))
            {
                ModelState.AddModelError("Email", "Email bestaat al");
            }
            if (model.Bsn == null)
            {
                ModelState.AddModelError("Bsn", "Dit veld moet ingevuld zijn");
            }
            if (Int32.TryParse(model.Bsn, out bsn))
            {
                if (bsn.ToString().Length != 8 && bsn.ToString().Length != 9)
                {
                    ModelState.AddModelError("Bsn", "Geen geldig BSN nummer");
                }
                else
                {
                    if (_serviceEmployee.checkIfBsnAlreadyExist(bsn))
                    {
                        ModelState.AddModelError("Bsn", "BSN nummer bestaat al");
                    }
                }
            }
            else
            {
                ModelState.AddModelError("Bsn", "Geen geldig BSN nummer");
            }

            if (ModelState.IsValid)
            {
                string username = _serviceEmployee.findUserName(model.FirstName, model.MiddleName, model.LastName);
                string userId = _serviceEmployee.createUser(model.Url, model.FirstName, username, model.Email, model.PhoneNumber, model.BirthDate.Month.ToString());
                if (userId != null)
                {
                    _serviceEmployee.setEmployee(CastEmployee(model, userId));
                    Employee employee = _serviceEmployee.getEmployeeWithBSN(bsn);
                    _serviceEmployee.addEmployeeDepartments(employee.EmployeeId, model.Departments);
                    return RedirectToAction(nameof(Index));
                }
            }
            FillCreateViewBag();
            return View(model);
        }

        private void FillCreateViewBag()
        {
            ViewBag.Branches = _serviceEmployee.getBranch().Select(bra => new SelectListItem() { Value = bra.BranchId.ToString(), Text = bra.Name }).ToList();
            ViewBag.Departments = _serviceEmployee.getDepartments().Select(dep => new SelectListItem() { Value = dep.Id.ToString(), Text = dep.Name.ToString() }).ToList();
            ViewBag.Period = Enum.GetValues(typeof(Period)).Cast<Period>().Select(per => new SelectListItem { Text = per.ToString(), Value = ((int)per).ToString() }).ToList();
        }

        public ActionResult Edit(int id)
        {
            List<Department> allDepartments = _serviceEmployee.getDepartments();
            List<Department> employeeDepartments = _serviceEmployee.getDepartmentsByEmployeeId(id);
            List<SelectListItem> itemList = new List<SelectListItem>();
            foreach (Department department in allDepartments)
            {
                SelectListItem item = new SelectListItem();
                item.Text = department.Name.ToString();
                item.Value = department.Id.ToString();
                if (employeeDepartments.Contains(department))
                {
                    item.Selected = true;
                }
                itemList.Add(item);
            }

            ViewBag.Departments = itemList;
            ViewBag.Contracts = _serviceEmployee.getContractsByEmployeeId(id); ;
            ViewBag.Period = Enum.GetValues(typeof(Period)).Cast<Period>().Select(per => new SelectListItem { Text = per.ToString(), Value = ((int)per).ToString() }).ToList();
            ViewBag.Rolls = _serviceEmployee.getRolls().Select(roll => new SelectListItem { Value = roll.Name.ToString(), Text = roll.Name, Selected = true }).ToList();
            ViewBag.Branches = _serviceEmployee.getBranch().Select(bra => new SelectListItem() { Value = bra.BranchId.ToString(), Text = bra.Name, Selected = true }).ToList();

            EditEmployeeModel data = new EditEmployeeModel();
            data.Employee = _serviceEmployee.getEmployee(id);
            data.Email = _serviceEmployee.getEmailByUserId(data.Employee.userId);
            data.PhoneNumber = _serviceEmployee.getPhoneNumberByUserId(data.Employee.userId);
            data.Roll = _serviceEmployee.getRollByUserId(data.Employee.userId).Result;
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditEmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                if (_serviceEmployee.CheckRollChange(model.Roll, model.Employee.userId))
                {
                    if (_serviceEmployee.checkEditSelf(model.Employee, _serviceEmployee.getEmployeeById(this.User).userId) && _serviceEmployee.getRollByUserId(_serviceEmployee.getEmployeeById(this.User).userId).Result != "Manager")
                    {
                        await _serviceEmployee.editEmployeeRoll(model.Roll, model.Email);
                    }
                    else
                    {
                        ModelState.AddModelError("Roll", "U mag de rol van deze medewerker niet veranderen, zet de rol weer terug waar het op stond als u door wilt gaan met deze wijziging");
                    }
                } 
            }
            if (ModelState.IsValid)
            {
                _serviceEmployee.editEmployeeDepartments(model.Employee, model.Departments);
                _serviceEmployee.editEmployee(model.Employee);
                await _serviceEmployee.editEmail(model.Url, model.Employee.userId, model.Email);
                await _serviceEmployee.editPhoneNumber(model.Employee.userId, model.PhoneNumber);
                return RedirectToAction(nameof(Index));
            }
            return Edit(model.Employee.EmployeeId);
        }

        public ActionResult CreateContract(int id)
        {
            Contract contract = new Contract();
            contract.EmployeeId = id;
            ViewBag.Functions = _serviceEmployee.getFunctions().Select(func => new SelectListItem() { Value = func.FunctionId.ToString(), Text = func.Name }).ToList();
            return View(contract);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateContract(Contract model)
        {
            if (ModelState.IsValid)
            {
                _serviceEmployee.createContract(model);
                return RedirectToAction("Edit", new { id = model.EmployeeId });
            }
            ViewBag.Functions = _serviceEmployee.getFunctions().Select(func => new SelectListItem() { Value = func.FunctionId.ToString(), Text = func.Name }).ToList();
            return View(model);
        }

        public ActionResult EndContract(int contractId)
        {
            _serviceEmployee.endContract(contractId);
            return RedirectToAction("Edit", new { id = _serviceEmployee.getEmployeeIdFromContractId(contractId) });
        }

        private Employee CastEmployee(CreateEmployeeModel model, string userId)
        {
            Employee employee = new Employee();

            employee.FirstName = model.FirstName;
            employee.MiddleName = model.MiddleName;
            employee.LastName = model.LastName;
            employee.BirthDate = model.BirthDate;
            employee.Iban = model.Iban;
            employee.Bsn = Int32.Parse(model.Bsn);  //value already checked by input
            employee.ZipCode = model.ZipCode;
            employee.HouseNumber = model.HouseNumber;
            employee.StreetName = model.StreetName;
            employee.City = model.City;
            employee.State = model.State;
            employee.Country = model.Country;
            employee.Branch = model.Branch;
            employee.BranchId = model.BranchId;
            employee.Period = model.Period;

            employee.userId = userId;

            return employee;
        }
    }
}