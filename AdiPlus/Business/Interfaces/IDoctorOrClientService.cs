using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdiPlus.Business.Interfaces
{
    public interface IDoctorOrClientService
    {
        public int GetClientByUserId(string userId);
        public int GetDoctorByUserId(string userId);
    }
}
