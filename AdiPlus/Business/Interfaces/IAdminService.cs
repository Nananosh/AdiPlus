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
        void RemoveSpecialization(Specialization doctor);
        void RemoveMaterial(Material material);
        Cabinet CreateCabinet(Cabinet cabinet);
        Cabinet UpdateCabinet(Cabinet cabinet);
        Specialization CreateSpecialization(Specialization specialization);
        Specialization UpdateSpecialization(Specialization doctor);
        Doctor UpdateDoctor(Doctor doctor);
        Service UpdateService(ServiceViewModel service);
        Doctor AddDoctorAdminGrid(Doctor doctor);
        Material UpdateMaterial(Material material);
        Material CreateMaterial(Material material);
        IEnumerable GetAllMaterials();
        IEnumerable<Specialization> GetAllSpecializations();
        IEnumerable GetAllService();
        IEnumerable GetAllSpecialization();
        IEnumerable GetAllCabinet();
    }
}