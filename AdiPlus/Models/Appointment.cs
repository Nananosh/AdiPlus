using System;
using System.Collections.Generic;

namespace AdiPlus.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public Doctor Doctor { get; set; }
        public int DoctorId { get; set; }
        public Client Client { get; set; }
        public int? ClientId { get; set; }
        public List<Service> Service { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public List<MedicalCard> MedicalCards { get; set; }
        public List<AppointmentMaterialUsed> Material { get; set; }
    }
}