using AdiPlus.Models;

namespace AdiPlus.ViewModels
{
    public class MedicalCardViewModel
    {
        public int Id { get; set; }
        public Appointment Appointment { get; set; }
        public int AppointmentId { get; set; }
        public string Recommendation { get; set; }
    }
}
