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
        void RemoveDoctor(Doctor doctor);
        void RemoveCabinet(Cabinet cabinet);
        Cabinet CreateCabinet(Cabinet cabinet);
        Specialization CreateSpecialization(Specialization specialization);
        Material CreateMaterial(Material material);
        void RemoveSpecialization(Specialization doctor);
        void RemoveMaterial(Material material);
        Doctor UpdateDoctor(Doctor doctor);
        Specialization UpdateSpecialization(Specialization doctor);
        Cabinet UpdateCabinet(Cabinet cabinet);
        Material UpdateMaterial(Material material);
        IEnumerable GetAllMaterials();
        Doctor AddDoctorAdminGrid(Doctor doctor);
        IEnumerable<Specialization> GetAllSpecializations();
        IEnumerable GetAllSpecialization();
        IEnumerable GetAllCabinet();
    }
}