using AdiPlus.Business.Interfaces;
using AdiPlus.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdiPlus.Business.Services
{
    public class DoctorOrClientService : IDoctorOrClientService
    {
        private readonly ApplicationContext db;
        public DoctorOrClientService(ApplicationContext context)
        {
            this.db = context;
        }

        public int GetClientByUserId(string userId)
        {
            var client = db.Clients.FirstOrDefault(p => p.User.Id == userId);

            return client.Id;
        }

        public int GetDoctorByUserId(string userId)
        {
            var doctor = db.Doctors.FirstOrDefault(d => d.User.Id == userId);

            return doctor.Id;
        }
    }
}
