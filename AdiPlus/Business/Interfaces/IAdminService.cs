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
        void RemoveDoctor(Doctor doctor);
        void RemoveCabinet(Cabinet cabinet);
        void RemoveSpecialization(Specialization doctor);
        void RemoveService(Service model);
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
        Service CreateService(Service service);
        IEnumerable GetAllMaterials();
        IEnumerable<Specialization> GetAllSpecializations();
        IEnumerable GetAllService();
        IEnumerable GetAllSpecialization();
        IEnumerable GetAllCabinet();
    }
}