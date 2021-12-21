using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdiPlus.Migrations;
using AdiPlus.Models;
using AdiPlus.ViewModels.Admin;
using Microsoft.AspNetCore.Mvc;

namespace AdiPlus.Business.Interfaces
{
    public interface IAdminService
    {
        void AddMaterial(Material material);
        void AddService(Service service);
        void AddSpecialization(Specialization specialization);
        Task<IActionResult> AddDoctor(RegisterDoctorViewModel model);
        void AddCabinet(Cabinet cabinet);
        IEnumerable GetAllMaterials();
        IEnumerable<Specialization> GetAllSpecializations();
        IEnumerable GetAllSpecialization();
        IEnumerable GetAllCabinet();
    }
}