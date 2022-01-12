﻿namespace AdiPlus.Models
{
    public class MedicalCard
    {
        public int Id { get; set; }
        public Appointment Appointment { get; set; }
        public int? AppointmentId { get; set; }
        public string Recommendation { get; set; }
    }
}