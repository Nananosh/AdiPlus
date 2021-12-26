using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AdiPlus.Models
{
    public class Material
    {
        public int Id { get; set; }
        public string MaterialName { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        [JsonIgnore]
        public List<Service> Services { get; set; }
        [JsonIgnore]
        public List<AppointmentMaterialUsed> Appointment { get; set; }
    }
}