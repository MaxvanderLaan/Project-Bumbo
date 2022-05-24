using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using Bumbo.Domain.Models;
using Bumbo.Domain.Services.Forecasts;
using Bumbo.Domain.Services.Schedules;
using Bumbo.Web.Models;
using Bumbo.Web.Models.Agenda;
using Microsoft.AspNetCore.Mvc.Rendering;
using static Bumbo.Domain.Models.Availability;
using Bumbo.Domain.Services.Remunerations;

namespace Bumbo.Web.Controllers
{
    public class AgendaController : Controller
    {
        private readonly ISchedule _serviceSchedule;
        private readonly IRemuneration _serviceRemuneration;
        private readonly IForecast _serviceForecast;

        public AgendaController(ISchedule service, IRemuneration serviceRemuneration, IForecast forecast)
        {
            _serviceSchedule = service;
            _serviceRemuneration = serviceRemuneration;
            _serviceForecast = forecast;
        }

        [Authorize(Roles = "Manager, Systeembeheerder")]
        public ActionResult Index()
        {
            fillScheduleViewBag();

            return View(new ScheduleViewModel() { Availabilities = _serviceSchedule.GetSickLeave() });
        }

        [Authorize(Roles = "Manager, Systeembeheerder")]
        [HttpPost]
        public ActionResult Index(ScheduleViewModel svm)
        {
            fillScheduleViewBag();

            if (ModelState.IsValid)
            {
                _serviceSchedule.AddSchedule(svm.Schedule);
                ModelState.Clear();
                return Index();
            }

            svm.Availabilities = _serviceSchedule.GetSickLeave();
            return View(svm);
        }

        [Authorize(Roles = "Manager, Medewerker, Systeembeheerder")]
        public ActionResult EmployeeSchedule()
        {
            ViewBag.Availabilities = _serviceSchedule.GetEmployeeFutureAvailability(_serviceSchedule.GetEmployeeByUserId(this.User).EmployeeId);
            return View();
        }

        [Authorize(Roles = "Manager, Systeembeheerder")]
        public ActionResult Approval()
        {
            return View(_serviceSchedule.GetUnapprovedAvailabilities());
        }

        [Authorize(Roles = "Manager, Medewerker, Systeembeheerder")]
        public JsonResult GetSchedule(int id)
        {
            return Json(_serviceSchedule.GetSchedule(id));
        }

        [Authorize(Roles = "Manager, Systeembeheerder")]
        public ActionResult EditSchedule(int id)
        {
            fillScheduleViewBag();

            return View(new ScheduleViewModel()
            {
                Schedule = _serviceSchedule.GetSchedule(id)
            });
        }

        [Authorize(Roles = "Manager, Systeembeheerder")]
        [HttpPost]
        public ActionResult EditSchedule(ScheduleViewModel svm)
        {
            fillScheduleViewBag();

            if (ModelState.IsValid)
            {
                _serviceSchedule.UpdateSchedule(svm.Schedule);
                return RedirectToAction(nameof(Index));
            }
            return View(svm);
        }

        private void fillScheduleViewBag()
        {
            ViewBag.AvailableEmployees = _serviceSchedule
                .GetSchedulableEmployees(_serviceSchedule
                .GetEmployeeByUserId(this.User).BranchId)
                .Select(sli => new SelectListItem()
                {
                    Value = sli.EmployeeId.ToString(), 
                    Text = sli.FirstName + " " + sli.LastName
                } );
            
            ViewBag.Departments = _serviceSchedule
                .GetDepartments()
                .Select(sli => new SelectListItem()
                {
                    Value = sli.Id.ToString(), 
                    Text = sli.Name.ToString()
                })
                .ToList();
            
            ViewBag.Prognoses = _serviceForecast
                .GetFuturePrognoses(_serviceSchedule
                    .GetEmployeeByUserId(this.User).BranchId)
                .Select(sli => new SelectListItem()
                {
                    Value = sli.ForecastId.ToString(),
                    Text = sli.Date.ToString("dd-MM-yyyy")
                })
                .ToList();
        }

        [Authorize(Roles = "Manager, Systeembeheerder")]
        public ActionResult DeleteSchedule(int scheduleId)
        {
            _serviceSchedule.DeleteSchedule(scheduleId);
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Manager, Medewerker, Systeembeheerder")]
        public ActionResult Availability()
        {
            int employeeId = _serviceSchedule.GetEmployeeByUserId(this.User).EmployeeId;
            return View(new AvailabilityViewModel()
            {
                Availability = new Availability()
                {
                    EmployeeId = employeeId,
                    Start = DateTime.Today.AddDays(1),
                    End = DateTime.Today.AddDays(1)
                },
                Availabilities = _serviceSchedule.GetEmployeeFutureAvailability(employeeId)
            });
        }

        [Authorize(Roles = "Manager, Medewerker, Systeembeheerder")]
        [HttpPost]
        public ActionResult Availability(AvailabilityViewModel avm)
        {
            if (ModelState.IsValid)
            {
                Availability model = _serviceSchedule.AddAvailability(avm.Availability);
                if (model.Type == AvailabilityType.Ziek)
                {
                    remunerateSickEmployee(avm, model);
                }
                ModelState.Clear();
                return View(new AvailabilityViewModel()
                {
                    Availability = new Availability()
                    {
                        EmployeeId = avm.Availability.EmployeeId,
                        Start = DateTime.Today.AddDays(1), 
                        End = DateTime.Today.AddDays(1) },
                    Availabilities = _serviceSchedule.GetEmployeeFutureAvailability(avm.Availability.EmployeeId)
                });
            }

            avm.Availabilities = _serviceSchedule.GetEmployeeFutureAvailability(avm.Availability.EmployeeId);
            return View(avm);
        }

        [Authorize(Roles = "Manager, Medewerker, Systeembeheerder")]
        public Availability GetAvailability(int id)
        {
            return _serviceSchedule.GetAvailability(id);
        }

        [Authorize(Roles = "Manager, Medewerker, Systeembeheerder")]
        public ActionResult EditAvailability(int availabilityId)
        {
            return View(new AvailabilityViewModel()
            {
                Availability = _serviceSchedule.GetAvailability(availabilityId)
            });
        }

        [Authorize(Roles = "Manager, Medewerker, Systeembeheerder")]
        [HttpPost]
        public ActionResult EditAvailability(AvailabilityViewModel avm)
        {
            if (ModelState.IsValid)
            {
                Availability newAvailability = _serviceSchedule.UpdateAvailability(avm.Availability);
                if (newAvailability.Type == AvailabilityType.Ziek)
                {
                    if (_serviceSchedule.GetEmployeeSchedule(newAvailability.EmployeeId).Any(s => s.StartDate >= newAvailability.Start && s.EndDate <= newAvailability.End && s.Finalised))
                    {
                        remunerateSickEmployee(avm, newAvailability);
                    }
                }
                ModelState.Clear();
                return View("Availability", new AvailabilityViewModel()
                {
                    Availability = new Availability()
                    {
                        EmployeeId = avm.Availability.EmployeeId,
                        Start = DateTime.Today.AddDays(1), 
                        End = DateTime.Today.AddDays(1) },
                    Availabilities = _serviceSchedule.GetEmployeeFutureAvailability(avm.Availability.EmployeeId)
                });
            }
            return View(avm);
        }

        [Authorize(Roles = "Manager, Medewerker, Systeembeheerder")]
        [HttpPost]
        public ActionResult DeleteAvailability(int employeeId, int availabilityId)
        {
            Availability model = _serviceSchedule.DeleteAvailability(availabilityId);
            removeSickEmployeeRemuneration(model);
            return View("Availability", new AvailabilityViewModel()
            {
                Availability = new Availability()
                {
                    EmployeeId = employeeId,
                    Start = DateTime.Today.AddDays(1), 
                    End = DateTime.Today.AddDays(1) },
                Availabilities = _serviceSchedule.GetEmployeeFutureAvailability(employeeId)
            });
        }

        [Authorize(Roles = "Manager, Systeembeheerder")]
        public ActionResult AddSchedule(Schedule schedule)
        {
            _serviceSchedule.AddSchedule(schedule);
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Manager, Systeembeheerder")]
        public JsonResult GetEvents()
        {
            List<EventViewModel> events = new();
            foreach (Schedule schedule in _serviceSchedule.GetAllSchedules())
            {
                EventViewModel e = new EventViewModel()
                {
                    id = schedule.ScheduleId,
                    title = schedule.Department.Code + " - " + schedule.Employee.FirstName + " " + schedule.Employee.LastName,
                    start = schedule.StartDate.ToString("yyyy-MM-ddTHH:mm:ss.sssZ"),
                    end = schedule.EndDate.ToString("yyyy-MM-ddTHH:mm:ss.sssZ"),
                    allDay = false
                };

                if (_serviceSchedule.CalculateOverlap(schedule))
                    e.color = "#198754";
                else
                {
                    if (schedule.Finalised) e.color = "#0d6efd";
                    else e.color = "#6c757d";
                }
                events.Add(e);
            }
            return Json(events);
        }

        [Authorize(Roles = "Manager, Medewerker, Systeembeheerder")]
        public JsonResult GetEmployeeEvents()
        {
            List<EventViewModel> events = new();
            foreach (Schedule schedule in _serviceSchedule.GetEmployeeSchedule(_serviceSchedule.GetEmployeeByUserId(this.User).EmployeeId))
            {
                EventViewModel e = new EventViewModel()
                {
                    id = schedule.ScheduleId,
                    title = "Afdeling: " + schedule.Department.Code,
                    start = schedule.StartDate.ToString("yyyy-MM-ddTHH:mm:ss.sssZ"),
                    end = schedule.EndDate.ToString("yyyy-MM-ddTHH:mm:ss.sssZ"),
                    allDay = false,
                    color = "#0d6efd"
                };
                if (schedule.Finalised)
                {
                    events.Add(e);
                }
            }
            return Json(events);
        }
        
        [Authorize(Roles = "Manager, Systeembeheerder")]
        public JsonResult GetRequiredHoursRemaining(int id)
        {
            int[] hours = new int[3];
            hours[0] = _serviceForecast.GetStockHoursRemaining(id, Department.DepartmentCode.VAK);
            hours[1] = _serviceForecast.GetStockHoursRemaining(id, Department.DepartmentCode.KAS);
            hours[2] = _serviceForecast.GetStockHoursRemaining(id, Department.DepartmentCode.VER);
            return Json(hours);
        }

        [Authorize(Roles = "Manager, Systeembeheerder")]
        public ActionResult Approve(int id)
        {
            _serviceSchedule.Approve(id);
            return RedirectToAction(nameof(Approval));
        }

        [Authorize(Roles = "Manager, Systeembeheerder")]
        public ActionResult Disapprove(int id)
        {
            _serviceSchedule.Disapprove(id);
            return RedirectToAction(nameof(Approval));
        }

        [Authorize(Roles = "Manager, Systeembeheerder")]
        public ActionResult PublishSchedule()
        {
            return View();
        }

        [Authorize(Roles = "Manager, Systeembeheerder")]
        [HttpPost]
        public ActionResult PublishSchedule(PublishViewModel pvm)
        {
            if (ModelState.IsValid)
            {
                _serviceSchedule.PublishSchedule(pvm.StartDate, pvm.EndDate);
                return RedirectToAction(nameof(Index));
            }
            return View(pvm);
        }

        private void remunerateSickEmployee(AvailabilityViewModel avm, Availability availability)
        {
            List<Schedule> schedules = _serviceSchedule.GetEmployeeSchedule(avm.Availability.EmployeeId).Where(s => availability.Start <= s.StartDate && availability.End >= s.EndDate && s.Finalised).ToList();
            if (schedules.Count > 0)
            {
                foreach (Schedule schedule in schedules)
                {
                    if (!_serviceRemuneration.GetAll().Any(r => r.Date == schedule.StartDate))
                        _serviceRemuneration.Create(schedule.StartDate, schedule.EndDate, availability.Employee, true);
                }
            }
        }

        private void removeSickEmployeeRemuneration(Availability availability)
        {
            foreach (Remuneration remuneration in _serviceRemuneration.GetAll().Where(r => r.Date >= availability.Start && r.Date <= availability.End))
            {
                _serviceRemuneration.Delete(remuneration);
            }
        }
    }
}
