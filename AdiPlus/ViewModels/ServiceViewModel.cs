using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdiPlus.ViewModels
{
    public class ServiceViewModel
    {
        public int Id { get; set; }
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string GetService { get => ServiceName + " - " + Price.ToString(); }
    }
}
