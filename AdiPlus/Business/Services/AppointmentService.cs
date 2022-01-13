using AdiPlus.Business.Interfaces;
using AdiPlus.Constants.UserMessagesConstants;
using AdiPlus.Migrations;
using AdiPlus.Models;
using AdiPlus.ViewModels;
using AdiPlus.ViewModels.Admin;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdiPlus.Business.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly ApplicationContext db;
        private readonly IMapper mapper;

        public AppointmentService(
            ApplicationContext context,
            IMapper mapper)
        {
            this.mapper = mapper;
            this.db = context;
        }

        public IEnumerable<Doctor> GetAllDoctors()
        {
            var doctors = db.Doctors.Include(d => d.Specialization).Include(d => d.Cabinet);

            return doctors;
        }

        public IEnumerable<Doctor> GetDoctorsBySpecializationId(int id)
        {
            var doctors = db.Doctors.Where(d => d.SpecializationId == id);

            return doctors;
        }

        public IEnumerable<Service> GetServicesBySpecializationId(int id)
        {
            var services = db.Services.Where(s => s.SpecializationId == id);

            return services;
        }

        public IEnumerable<Service> GetAllServices()
        {
            IEnumerable<Service> services = db.Services;

            return services;
        }

        public string AddAppointment(int clientId, int ticketId, int[] serviceIds)
        {
            var services = GetServices(serviceIds);
            SaveAppointmentServices(services, ticketId, clientId);

            return UserMessagesConstants.TicketToDoctorSuccessfullyOrdered;
        }

        public IEnumerable<Appointment> GetTalonsByDoctorDate(int id, DateTime talon)
        {
            var appointments = db.Appointments.Include(d => d.Doctor).Include(p => p.Client).AsQueryable();
            appointments = appointments.Where(
                x => x.DateStart.Date == talon.Date
                     && x.DateStart.Month == talon.Month
                     && x.DateStart.Year == talon.Year);

            appointments = appointments.Where(x => x.Doctor.Id == id);
            appointments = appointments.Where(x => x.Client == null);

            return appointments;
        }

        public MedicalCard GetMedicalCardByAppointmentId(int appointmentId)
        {
            var medicalCard = db.MedicalCards.Where(x => x.Appointment.Id == appointmentId).FirstOrDefault();

            return medicalCard;
        }

        public void AddMedicalCard(MedicalCard model)
        {
            db.MedicalCards.Add(model);

            db.SaveChanges();
        }

        public Appointment GetAppointmentById(int id)
        {
            var appointment = db.Appointments.Where(x => x.Id == id).Include(a => a.Service)
                .ThenInclude(a => a.Materials).First();

            return appointment;
        }

        public void AddUsedMaterial(AppintmentResultViewModel model)
        {
            List<AppointmentMaterialUsed> useds = new List<AppointmentMaterialUsed>();
            foreach (var item in model.medicalCardViewModels)
            {
                useds.Add(new AppointmentMaterialUsed
                    {AppointmentId = model.AppointmentId, MaterialId = item.Id, Quantity = item.Quantity});
            }

            db.AppointmentMaterialUseds.AddRange(useds);

            db.SaveChanges();
        }

        private IEnumerable<Service> GetServices(int[] serviceIds)
        {
            List<Service> services = new List<Service>();

            foreach (var item in serviceIds)
            {
                var service = db.Services.Find(item);
                services.Add(service);
            }

            return services;
        }

        private void SaveAppointmentServices(IEnumerable<Service> services, int appointmentId, int clientId)
        {
            var appointment = db.Appointments.Include(x => x.Service).FirstOrDefault(a => a.Id == appointmentId);

            if (appointment != null)
            {
                appointment.Service.AddRange(services);
                appointment.ClientId = clientId;
            }

            db.SaveChanges();
        }

        public IEnumerable<Appointment> GetTalonsByDoctorId(int id)
        {
            var appointments = db.Appointments.Include(x => x.Client).Where(x => x.Doctor.Id == id);

            return appointments;
        }

        public Appointment AddDoctorTalon(Appointment appointment)
        {
            var addAppointment = new Appointment
            {
                DoctorId = appointment.DoctorId,
                DateStart = appointment.DateStart,
                DateEnd = appointment.DateEnd
            };
            db.Appointments.Add(addAppointment);
            db.SaveChanges();

            var addedAppointment =
                db.Appointments
                    .Include(x => x.Doctor)
                    .FirstOrDefault(x => x.Id == addAppointment.Id);

            return addAppointment;
        }

        public Appointment EditDoctorTalon(Appointment appointment)
        {
            var editAppointment = db.Appointments
                .FirstOrDefault(x => x.Id == appointment.Id);

            if (editAppointment != null)
            {
                editAppointment.DateEnd = appointment.DateEnd;
                editAppointment.DateStart = appointment.DateStart;
                db.SaveChanges();
            }

            var editedAppointment = db.Appointments
                .Include(x => x.Client)
                .FirstOrDefault(x => x.Id == editAppointment.Id);

            return editedAppointment;
        }

        public void DeleteDoctorTalon(Appointment appointment)
        {
            var deleteAppointment = db.Appointments.FirstOrDefault(x => x.Id == appointment.Id);
            if (deleteAppointment != null) db.Appointments.Remove(deleteAppointment);
            db.SaveChanges();
        }

        public IEnumerable<Appointment> GetTalonsDoctorByDoctorId(int id)
        {
            var appointments = db.Appointments.Include(x => x.Client)
                .Where(x => x.Doctor.Id == id && x.Client.Id != null);

            return appointments;
        }
    }
}