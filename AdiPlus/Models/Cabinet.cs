using System.Collections.Generic;

namespace AdiPlus.Models
{
    public class Cabinet
    {
        public int Id { get; set; }
        public int CabinetNumber { get; set; }
        public List<Doctor> Doctors { get; set; }
    }
}