using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdiPlus.Business.Interfaces;
using AdiPlus.Migrations;
using AdiPlus.Models;
using AdiPlus.ViewModels.Admin;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public void RemoveDoctor(Doctor model)
        {
            var doctor = db.Doctors.FirstOrDefault(ah => ah.Id == model.Id);

            if (doctor != null)
            {
                db.Doctors.Remove(doctor);
                db.SaveChanges();
            }
        }
        
        public void RemoveMaterial(Material model)
        {
            var material = db.Materials.FirstOrDefault(a => a.Id == model.Id);

            if (material != null)
            {
                db.Materials.Remove(material);
                db.SaveChanges();
            }
        }
        
        public void RemoveSpecialization(Specialization model)
        {
            var specialization = db.Specializations.FirstOrDefault(a => a.Id == model.Id);

            if (specialization != null)
            {
                db.Specializations.Remove(specialization);
                db.SaveChanges();
            }
        }
        
        public void RemoveCabinet(Cabinet model)
        {
            var cabinet = db.Cabinets.FirstOrDefault(a => a.Id == model.Id);

            if (cabinet != null)
            {
                db.Cabinets.Remove(cabinet);
                db.SaveChanges();
            }
        }

        public Doctor UpdateDoctor(Doctor model)
        {
            var doctor = db.Doctors.FirstOrDefault(c => c.Id == model.Id);

            if (doctor != null)
            {
                doctor.LastName = model.LastName;
                doctor.Name = model.Name;
                doctor.Surname = model.Surname;
                doctor.SpecializationId = model.SpecializationId;
                doctor.CabinetId = model.CabinetId;

                db.SaveChanges();
            }

            var updatedCabinet = db.Doctors.Include(x => x.Cabinet).Include(x => x.Specialization).FirstOrDefault(c => c.Id == doctor.Id);

            return updatedCabinet;
        }

        public Specialization UpdateSpecialization(Specialization model)
        {
            var specialization = db.Specializations.FirstOrDefault(c => c.Id == model.Id);

            if (specialization != null)
            {
                specialization.SpecializationName = model.SpecializationName;

                db.SaveChanges();
            }

            var updatedSpecialization = db.Specializations.FirstOrDefault(c => c.Id == specialization.Id);

            return updatedSpecialization;
        }
        
        public Cabinet UpdateCabinet(Cabinet model)
        {
            var cabinet = db.Cabinets.FirstOrDefault(c => c.Id == model.Id);

            if (cabinet != null)
            {
                cabinet.CabinetNumber = model.CabinetNumber;

                db.SaveChanges();
            }

            var updatedCabinet = db.Cabinets.FirstOrDefault(c => c.Id == cabinet.Id);

            return updatedCabinet;
        }

        public Material UpdateMaterial(Material model)
        {
            var material = db.Materials.FirstOrDefault(c => c.Id == model.Id);

            if (material != null)
            {
                material.MaterialName = model.MaterialName;
                material.Price = model.Price;
                material.Quantity = model.Quantity;
                material.ExpirationDate = model.ExpirationDate;

                db.SaveChanges();
            }

            var updatedMaterial = db.Materials.FirstOrDefault(c => c.Id == material.Id);

            return updatedMaterial;
        }

        public Cabinet CreateCabinet(Cabinet model)
        {
            if (model != null)
            {
                db.Cabinets.Add(model);
                db.SaveChanges();
            }

            var addedCabinet = db.Cabinets.FirstOrDefault(c => c.Id == model.Id);

            return addedCabinet;
        }

        public Specialization CreateSpecialization(Specialization model)
        {
            if (model != null)
            {
                db.Specializations.Add(model);
                db.SaveChanges();
            }

            var addedSpecializations = db.Specializations.FirstOrDefault(c => c.Id == model.Id);

            return addedSpecializations;
        }

        public Material CreateMaterial(Material model)
        {
            if (model != null)
            {
                db.Materials.Add(model);
                db.SaveChanges();
            }

            var addedMaterials = db.Materials.FirstOrDefault(c => c.Id == model.Id);

            return addedMaterials;
        }

        public Doctor AddDoctorAdminGrid(Doctor model)
        {
            if (model != null)
            {
                db.Doctors.Add(model);
                db.SaveChanges();
            }

            var addedDoctor = db.Doctors.FirstOrDefault(d => d.Id == model.Id);

            return addedDoctor;
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