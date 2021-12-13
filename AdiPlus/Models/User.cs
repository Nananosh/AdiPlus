using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using MoreHealth.Models;

namespace AdiPlus.Models
{
    public class User : IdentityUser
    {
        public string UserImage { get; set; }
        public List<Doctor> Doctors { get; set; }
        public List<Client> Patients { get; set; }
    }
}