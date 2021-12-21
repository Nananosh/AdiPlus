using AdiPlus.Business.Interfaces;
using AdiPlus.Constants.UserMessagesConstants;
using AdiPlus.Migrations;
using AdiPlus.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdiPlus.Business.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly ApplicationContext db;
        public AppointmentService(ApplicationContext context)
        {
            this.db = context;
        }

        public IEnumerable<Doctor> GetAllDoctors()
        {
            IEnumerable<Doctor> doctors = db.Doctors;

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

            appointment.Service.AddRange(services);
            appointment.ClientId = clientId;
            db.SaveChanges();
        }
    }
}
