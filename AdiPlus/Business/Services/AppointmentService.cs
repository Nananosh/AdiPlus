using AdiPlus.Business.Interfaces;
using AdiPlus.Migrations;
using AdiPlus.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        
        public IEnumerable<Service> GetServices()
        {
            IEnumerable<Service> services = db.Services;

            return services;
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
    }
}
