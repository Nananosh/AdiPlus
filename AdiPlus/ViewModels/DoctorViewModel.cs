using AdiPlus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdiPlus.ViewModels
{
    public class DoctorViewModel
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Specialization Specialization { get; set; }
        public int SpecializationId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string LastName { get; set; }
        public Cabinet Cabinet { get; set; }
        public int CabinetId { get; set; }
        public string WorkSchedule { get; set; }
        public string FullName { get => Name + " " + Surname + " " + LastName; }
    }
}
