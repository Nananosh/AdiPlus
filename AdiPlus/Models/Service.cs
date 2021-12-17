﻿using System.Collections.Generic;

namespace AdiPlus.Models
{
    public class Service
    {
        public int Id { get; set; }
        public Doctor Doctor { get; set; }
        public int DoctorId { get; set; }
        public List<Appointment> Appointments { get; set; } 
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public List<ServiceMeterialStandart> Material { get; set; }
    }
}