namespace AdiPlus.Models
{
    public class AppointmentMaterialUsed
    {
        public int Id { get; set; }
        public Material Material { get; set; }
        public int? MaterialId { get; set; }
        public Appointment Appointment { get; set; }
        public int? AppointmentId { get; set; }
        public int Quantity { get; set; }
    }
}