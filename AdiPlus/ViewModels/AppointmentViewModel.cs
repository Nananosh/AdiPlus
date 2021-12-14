using AdiPlus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdiPlus.ViewModels
{
    public class AppointmentViewModel
    {
        public int Id { get; set; }
        public Client Client { get; set; }
        public int? ClientId { get; set; }
        public Doctor Doctor { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get => DateStart.AddMinutes(30); }

        public string GetDate { get => DateStart.ToShortTimeString(); }
    }
}
