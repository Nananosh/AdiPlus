using System.Collections.Generic;
using MoreHealth.Models;

namespace AdiPlus.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Specialization? Specialization { get; set; }
        public int? SpecializationId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string LastName { get; set; }
        public Cabinet? Cabinet { get; set; }
        public int? CabinetId { get; set; }
        public List<WorkSchedule> WorkSchedules { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}