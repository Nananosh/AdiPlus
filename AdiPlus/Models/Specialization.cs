using System.Collections.Generic;
using Newtonsoft.Json;

namespace AdiPlus.Models
{
    public class Specialization
    {
        public int Id { get; set; }
        public string SpecializationName { get; set; }
        [JsonIgnore]
        public List<Doctor> Doctors { get; set; }
    }
}