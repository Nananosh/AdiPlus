﻿using AdiPlus.Business.Interfaces;
using AdiPlus.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<IActionResult> MedCard()
        {
            var userId = User.Claims.ElementAt(0).Value;
            if (string.IsNullOrEmpty(userId)) RedirectToAction("Index","Home");

            var clientId = doctorOrClientService.GetClientByUserId(userId);
            var appointments = await appointmentService.GetMedicalHistoryByClientId(clientId);
            
            return View(appointments);
        }

        public IActionResult AppointmentInfo(int appointmentId)
        {
            var appointmentInfo = appointmentService.GetAppointmentById(appointmentId);
            
            return View(appointmentInfo);
        }
        
        public IActionResult CancelAppointment(int appointmentId)
        {
            appointmentService.CancelAppointment(appointmentId);
            
            return RedirectToAction("MedCard", "Appointment");
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
            var appointmentModel = appointmentService.GetAppointmentById(appointmentId.Value);

            return View(new AppintmentResultViewModel
            {
                Appointment = appointmentModel
            });
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult AppointmentResult(AppintmentResultViewModel model)
        {
            if (ModelState.IsValid)
            {
                appointmentService.AddMedicalCard(mapper.Map<MedicalCard>(model));
                appointmentService.AddUsedMaterial(model);
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }
        
        public IActionResult AddAppointmentByDoctor(int id)
        {
            ViewBag.Id = id;
            return View();
        }
        
        public IActionResult AppointmentByDoctor(string id)
        {
            var doctorId = doctorOrClientService.GetDoctorByUserId(id);
            ViewBag.Id = doctorId;
            return View();
        }
        
        public IActionResult GetTalonsByDoctorId(int id)
        {
            var talons = appointmentService.GetTalonsByDoctorId(id);
            
            return Json(mapper.Map<IEnumerable<AppointmentViewModel>>(talons));
        }
        
        [HttpPost]
        public JsonResult AddDoctorTalon(AppointmentViewModel model)
        {
            var talon = appointmentService.AddDoctorTalon(mapper.Map<Appointment>(model));

            return Json(mapper.Map<AppointmentViewModel>(talon));
        }
        
        [HttpPost]
        public JsonResult EditDoctorTalon(AppointmentViewModel model)
        {
            var talon = appointmentService.EditDoctorTalon(mapper.Map<Appointment>(model));

            return Json(mapper.Map<AppointmentViewModel>(talon));
        }
        
        [HttpDelete]
        public void DeleteDoctorTalon(AppointmentViewModel model)
        {
            appointmentService.DeleteDoctorTalon(mapper.Map<Appointment>(model)); ;
        }
        
        public IActionResult GetTalonsDoctorByDoctorId(int id)
        {
            var talons = appointmentService.GetTalonsDoctorByDoctorId(id);
            
            return Json(mapper.Map<IEnumerable<AppointmentViewModel>>(talons));
        }
    }
}