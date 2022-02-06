using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AdiPlus.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AdiPlus.Models;

namespace AdiPlus.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAppointmentService appointmentService;
        public HomeController(IAppointmentService appointmentService)
        {
            this.appointmentService = appointmentService;
        }

        public IActionResult Index(int? id)
        {
            return View();
        }

        public JsonResult GetDoctorByFilterSpecializationId(int? id)
        {
            var allDoctors = appointmentService.GetAllDoctorsBySpecializationFilter(id);
            
            return Json(allDoctors);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}