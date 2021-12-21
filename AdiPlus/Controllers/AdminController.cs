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
        
        [HttpPost]
        public async Task<IActionResult> AddDoctor(RegisterDoctorViewModel model)
        {
            await adminService.AddDoctor(model);
            return RedirectToAction();
        }
        
        public IActionResult GetAllMaterials()
        {
            var materials = adminService.GetAllMaterials();
            return Json(mapper.Map<IEnumerable<MaterialViewModel>>(materials));
        }
        
        public IActionResult GetAllSpecialization()
        {
            var specializations = adminService.GetAllSpecialization();
            return Json(mapper.Map<IEnumerable<SpecializationViewModel>>(specializations));
        }
        
        public IActionResult GetAllCabinet()
        {
            var cabinets = adminService.GetAllCabinet();
            return Json(mapper.Map<IEnumerable<CabinetViewModel>>(cabinets));
        }
    }
}