using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdiPlus.Business.Interfaces;
using AdiPlus.Migrations;
using AdiPlus.Models;
using AdiPlus.ViewModels.Admin;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AdiPlus.Business.Services
{
    public class AdminService : IAdminService
    {
        private readonly ApplicationContext db;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        public AdminService(ApplicationContext db, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.db = db;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public void AddMaterial(Material material)
        {
            db.Materials.Add(material);
            db.SaveChanges();
        }

        public IEnumerable<Specialization> GetAllSpecializations()
        {
            var specializations = db.Specializations;

            return specializations;
        }

        public void AddService(Service service)
        {
            db.Services.Add(service);
            db.SaveChanges();
        }

        public void AddSpecialization(Specialization specialization)
        {
            db.Specializations.Add(specialization);
            db.SaveChanges();
        }

        public async Task<IActionResult> AddDoctor(RegisterDoctorViewModel model)
        {
            var user = new User
            {
                Email = model.Email, UserName = model.UserName,
                UserImage = model.UserImage
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await db.Doctors.AddAsync(new Doctor
                {
                    User = user,
                    Name = model.Name,
                    Surname = model.Surname,
                    LastName = model.LastName,
                    SpecializationId = model.SpecializationId,
                    CabinetId = model.CabinetId
                });
                await db.SaveChangesAsync();
                await _userManager.AddToRoleAsync(user, "Doctor");
                await _signInManager.SignInAsync(user, false);
            }

            return null;
        }

        public void AddCabinet(Cabinet cabinet)
        {
            db.Cabinets.Add(cabinet);
            db.SaveChanges();
        }

        public IEnumerable GetAllMaterials()
        {
            var materials = db.Materials;
            return materials;
        }

        public IEnumerable GetAllSpecialization()
        {
            var specializations = db.Specializations;
            return specializations;
        }

        public IEnumerable GetAllCabinet()
        {
            var cabinets = db.Cabinets;
            return cabinets;
        }
    }
}