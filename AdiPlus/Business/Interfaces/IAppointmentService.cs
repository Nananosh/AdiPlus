using AdiPlus.Models;
using AdiPlus.ViewModels;
using AdiPlus.ViewModels.Admin;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdiPlus.Business.Interfaces
{
    public interface IAppointmentService
    {
        IEnumerable<Doctor> GetAllDoctors();

        IEnumerable<Service> GetServicesBySpecializationId(int id);
        IEnumerable<Service> GetAllServices();
        IEnumerable<Doctor> GetDoctorsBySpecializationId(int id);
        IEnumerable<Appointment> GetTalonsByDoctorDate(int id, DateTime talon);
        string AddAppointment(int clientId, int ticketId, int[] serviceIds);
        MedicalCard GetMedicalCardByAppointmentId(int appointmentId);
        void AddMedicalCard(MedicalCard model);
        void AddUsedMaterial(AppintmentResultViewModel model);
        Appointment GetAppointmentById(int id);
        IEnumerable<Appointment> GetTalonsByDoctorId(int id);
        Task<List<AppointmentViewModel>> GetMedicalHistoryByClientId(int id);
        Appointment AddDoctorTalon(Appointment appointment);
        Appointment EditDoctorTalon(Appointment appointment);
        void DeleteDoctorTalon(Appointment appointment);
        IEnumerable<Appointment> GetTalonsDoctorByDoctorId(int id);
        List<DoctorViewModel> GetAllDoctorsBySpecializationFilter(int? id);
    }
}
