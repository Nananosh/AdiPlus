using System.Collections.Generic;
using MoreHealth.Models;

namespace AdiPlus.Models
{
    public class Specialization
    {
        public int Id { get; set; }
        public string SpecializationName { get; set; }
        public List<Doctor> Doctors { get; set; }
    }
}