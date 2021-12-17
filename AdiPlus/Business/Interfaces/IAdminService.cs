using System.Collections;
using System.Threading.Tasks;
using AdiPlus.Migrations;
using AdiPlus.Models;
using AdiPlus.ViewModels.Admin;
using Microsoft.AspNetCore.Mvc;

namespace AdiPlus.Business.Interfaces
{
    public interface IAdminService
    {
        public void AddMaterial(Material material);
        public void AddService(Service service);
        public void AddSpecialization(Specialization specialization);
        public Task<IActionResult> AddDoctor(RegisterDoctorViewModel model);
        public void AddCabinet(Cabinet cabinet);
        public IEnumerable GetAllMaterials();
        public IEnumerable GetAllSpecialization();
        public IEnumerable GetAllCabinet();
    }
}