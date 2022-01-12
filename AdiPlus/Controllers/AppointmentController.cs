using AdiPlus.Business.Interfaces;
using AdiPlus.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using AdiPlus.ViewModels.Admin;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using AdiPlus.Models;

namespace AdiPlus.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IMapper mapper;
        private readonly IAppointmentService appointmentService;
        private readonly IDoctorOrClientService doctorOrClientService;

        public AppointmentController(
            IMapper mapper,
            IAppointmentService appointmentService,
            IDoctorOrClientService doctorOrClientService)
        {
            this.mapper = mapper;
            this.doctorOrClientService = doctorOrClientService;
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
        public JsonResult GetAllServices()
        {
            var services = appointmentService.GetAllServices();

            return Json(mapper.Map<IEnumerable<ServiceViewModel>>(services));
        }

        public JsonResult GetDoctorsBySpecializationId(int id)
        {
            var doctors = appointmentService.GetDoctorsBySpecializationId(id);

            return Json(mapper.Map<IEnumerable<DoctorViewModel>>(doctors));


        }
        public JsonResult GetServicesBySpecializationId(int id)
        {
            var services = appointmentService.GetServicesBySpecializationId(id);

            return Json(mapper.Map<IEnumerable<ServiceViewModel>>(services));
        }

        public IActionResult AddAppointment(string userId, int ticketId, int[] serviceIds)
        {
            var clientId = doctorOrClientService.GetClientByUserId(userId);

            var messageToUser = appointmentService.AddAppointment(clientId, ticketId, serviceIds);

            return Content(messageToUser);
        }

        public JsonResult GetTalonsByDoctorDate(int? doctor, string talon1)
        {
            DateTime talon = DateTime.Parse(talon1);

            if (!doctor.HasValue)
            {
                return Json(null);
            }

            var talons = appointmentService.GetTalonsByDoctorDate(doctor.Value, talon);
            var talonsbydate = mapper.Map<IEnumerable<AppointmentViewModel>>(talons);

            return Json(talonsbydate);
        }

        public IActionResult AppointmentResult(int? appointmentId)
        {
            if (!appointmentId.HasValue)
            {
                return RedirectToAction("Index", "Home");
            }
            var appointmentModel = appointmentService.GetAppoimentById(appointmentId.Value);

            return View(new AppintmentResultViewModel
            {
                Appointment = appointmentModel
            });
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult AddMedicalCard(AppintmentResultViewModel model)
        {
            if (ModelState.IsValid)
            {
                appointmentService.AddMedicalCard(mapper.Map<MedicalCard>(model));
                appointmentService.AddUsedMaterial(model);
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }
    }
}
