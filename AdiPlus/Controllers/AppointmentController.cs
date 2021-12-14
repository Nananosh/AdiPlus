using AdiPlus.Business.Interfaces;
using AdiPlus.Migrations;
using AdiPlus.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AdiPlus.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IMapper mapper;
        private readonly IAppointmentService appointmentService;

        public AppointmentController(
            IMapper mapper,
            IAppointmentService appointmentService)
        {
            this.mapper = mapper;
            this.appointmentService = appointmentService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllDoctors()
        {
            var doctors = appointmentService.GetAllDoctors();

            return Json(mapper.Map<IEnumerable<DoctorViewModel>>(doctors));
        }
        public JsonResult GetServices()
        {
            var services = appointmentService.GetServices();

            return Json(mapper.Map<IEnumerable<ServiceViewModel>>(services));
        }

        public JsonResult GetTalonsByDoctorDate(int? doctor, string talon1)
        {
            DateTime talon = DateTime.Parse(talon1);

            if (!doctor.HasValue)
            {
                return Json(null);
            }

            var talons = appointmentService.GetTalonsByDoctorDate(doctor.Value, talon);
            var t = mapper.Map<IEnumerable<AppointmentViewModel>>(talons);

            return Json(t);
        }
    }
}
