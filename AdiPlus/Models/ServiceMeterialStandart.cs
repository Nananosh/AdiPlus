namespace AdiPlus.Models
{
    public class ServiceMeterialStandart
    {
        public int Id { get; set; }
        public Service Service { get; set; }
        public Material Material { get; set; }
        public int Quantity { get; set; }
    }
}