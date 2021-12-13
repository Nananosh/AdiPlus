using MoreHealth.Models;

namespace AdiPlus.Models
{
    public class MedicalCard
    {
        public int Id { get; set; }
        public Client Client { get; set; }
        public Appointment Appointment { get; set; }
        public string Recommendation { get; set; }
    }
}