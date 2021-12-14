using AdiPlus.Migrations;
using AdiPlus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdiPlus.Business.Interfaces
{
    public interface IAppointmentService
    {
        IEnumerable<Doctor> GetAllDoctors();
        IEnumerable<Service> GetServices();
        IEnumerable<Appointment> GetTalonsByDoctorDate(int id, DateTime talon);
    }
}
