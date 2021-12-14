using System.Collections.Generic;
using AdiPlus.Business.Interfaces;
using AdiPlus.Migrations;
using AdiPlus.Models;
using AdiPlus.ViewModels.Admin;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AdiPlus.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationContext db;
        private readonly IAdminService adminService;
        private readonly IMapper mapper;

        public AdminController(ApplicationContext db, IAdminService adminService, IMapper mapper)
        {
            this.db = db;
            this.adminService = adminService;
            this.mapper = mapper;
        }

        public IActionResult AddMaterial()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult AddMaterial(MaterialViewModel model)
        {
            adminService.AddMaterial(db,mapper.Map<Material>(model));
            return RedirectToAction();
        }

        public IActionResult AddService()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult AddService(ServiceViewModel model)
        {
            adminService.AddService(db,mapper.Map<Service>(model));
            return RedirectToAction();
        }

        public IActionResult GetAllMaterials()
        {
            var materials = adminService.GetAllMaterials(db);
            return Json(mapper.Map<IEnumerable<MaterialViewModel>>(materials));
        }
    }
}