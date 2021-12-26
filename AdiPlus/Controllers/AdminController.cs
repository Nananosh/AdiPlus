using System.Collections.Generic;
using System.Threading.Tasks;
using AdiPlus.Business.Interfaces;
using AdiPlus.Migrations;
using AdiPlus.Models;
using AdiPlus.ViewModels;
using AdiPlus.ViewModels.Admin;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AdiPlus.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService adminService;
        private readonly IMapper mapper;

        public AdminController(IAdminService adminService, IMapper mapper)
        {
            this.adminService = adminService;
            this.mapper = mapper;
        }

        public IActionResult AddMaterial()
        {
            return View();
        }

        public JsonResult GetAllSpecializations()
        {
            var specializations = adminService.GetAllSpecializations();

            return Json(specializations);
        }

        [HttpPost]
        public IActionResult AddMaterial(MaterialViewModel model)
        {
            adminService.AddMaterial(mapper.Map<Material>(model));
            return RedirectToAction();
        }

        public IActionResult AddService()
        {
            return View();
        }

        public IActionResult MaterialGrid()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult AddService(ServiceViewModel model)
        {
            adminService.AddService(mapper.Map<Service>(model));
            return RedirectToAction();
        }

        public IActionResult AddSpecialization()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult AddSpecialization(SpecializationViewModel model)
        {
            adminService.AddSpecialization(mapper.Map<Specialization>(model));
            return RedirectToAction();
        }
        
        public IActionResult AddCabinet()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult AddCabinet(CabinetViewModel model)
        {
            adminService.AddCabinet(mapper.Map<Cabinet>(model));
            return RedirectToAction();
        }

        public IActionResult AddDoctor()
        {
            return View();
        }

        public IActionResult DoctorGrid()
        {
            return View();
        }

        public IActionResult CabinetGrid()
        {
            return View();
        }
        
        public IActionResult ServiceGrid()
        {
            return View();
        }

        public IActionResult SpecializationGrid()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> AddDoctor(RegisterDoctorViewModel model)
        {
            await adminService.AddDoctor(model);
            return RedirectToAction();
        }
        
        [HttpPost]
        public IActionResult AddDoctorAdminGrid(DoctorViewModel model)
        {
            var doctor = adminService.AddDoctorAdminGrid(mapper.Map<Doctor>(model));

            return Json(mapper.Map<DoctorViewModel>(doctor));
        }

        [HttpPost]
        public IActionResult UpdateDoctor(DoctorViewModel model)
        {
            var cabinet = adminService.UpdateDoctor(mapper.Map<Doctor>(model));

            return Json(mapper.Map<DoctorViewModel>(cabinet));
        }
        
        [HttpPost]
        public IActionResult UpdateService(ServiceViewModel model)
        {
            
            var service = adminService.UpdateService(model);

            return Json(mapper.Map<ServiceViewModel>(service));
        }

        [HttpDelete]
        public void RemoveDoctor(DoctorViewModel model)
        {
            adminService.RemoveDoctor(mapper.Map<Doctor>(model));
        }

        [HttpDelete]
        public void RemoveCabinet(CabinetViewModel model)
        {
            adminService.RemoveCabinet(mapper.Map<Cabinet>(model));
        }

        [HttpDelete]
        public void RemoveMaterial(MaterialViewModel model)
        {
            adminService.RemoveMaterial(mapper.Map<Material>(model));
        }

        [HttpDelete]
        public void RemoveSpecialization(SpecializationViewModel model)
        {
            adminService.RemoveSpecialization(mapper.Map<Specialization>(model));
        }

        public JsonResult GetAllMaterials()
        {
            var materials = adminService.GetAllMaterials();

            return Json(mapper.Map<IEnumerable<MaterialViewModel>>(materials));
        }

        [HttpPost]
        public IActionResult UpdateMaterial(MaterialViewModel model)
        {
            var material = adminService.UpdateMaterial(mapper.Map<Material>(model));

            return Json(mapper.Map<MaterialViewModel>(material));
        }

        [HttpPost]
        public IActionResult CreateCabinet(Cabinet model)
        {
            var specialization = adminService.CreateCabinet(mapper.Map<Cabinet>(model));

            return Json(mapper.Map<CabinetViewModel>(specialization));
        }

        [HttpPost]
        public IActionResult CreateSpecialization(Specialization model)
        {
            var specialization = adminService.CreateSpecialization(mapper.Map<Specialization>(model));

            return Json(mapper.Map<SpecializationViewModel>(specialization));
        }

        [HttpPost]
        public IActionResult CreateMaterial(Material model)
        {
            var specialization = adminService.CreateMaterial(mapper.Map<Material>(model));

            return Json(mapper.Map<MaterialViewModel>(specialization));
        }

        [HttpPost]
        public IActionResult UpdateCabinet(CabinetViewModel model)
        {
            var cabinet = adminService.UpdateCabinet(mapper.Map<Cabinet>(model));

            return Json(mapper.Map<CabinetViewModel>(cabinet));
        }
        
        [HttpPost]
        public IActionResult UpdateSpecialization(SpecializationViewModel model)
        {
            var specialization = adminService.UpdateSpecialization(mapper.Map<Specialization>(model));

            return Json(mapper.Map<SpecializationViewModel>(specialization));
        }

        public JsonResult GetAllSpecialization()
        {
            var specializations = adminService.GetAllSpecialization();
            return Json(mapper.Map<IEnumerable<SpecializationViewModel>>(specializations));
        }
        
        public IActionResult GetAllCabinet()
        {
            var cabinets = adminService.GetAllCabinet();
            return Json(mapper.Map<IEnumerable<CabinetViewModel>>(cabinets));
        }

        public IActionResult GetAllService()
        {
            var service = adminService.GetAllService();
            return Json(mapper.Map<IEnumerable<ServiceViewModel>>(service));
        }
    }
}