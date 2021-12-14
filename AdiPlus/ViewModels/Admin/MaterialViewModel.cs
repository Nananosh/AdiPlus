using System;

namespace AdiPlus.ViewModels.Admin
{
    public class MaterialViewModel
    {
        public int Id { get; set; }
        public string MaterialName { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}