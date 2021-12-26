using System.Collections.Generic;
using AdiPlus.Models;

namespace AdiPlus.ViewModels.Admin
{
    public class ServiceViewModel
    {
        public int Id { get; set; }
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public Specialization Specialization { get; set; }
        public int SpecializationId { get; set; }
        public List<Material> Materials { get; set; }
        public int[] MaterialsIds { get; set; }
        public string GetService { get => ServiceName + " - " + Price.ToString(); }
    }
}
