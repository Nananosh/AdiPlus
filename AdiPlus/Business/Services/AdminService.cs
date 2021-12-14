using System.Collections;
using AdiPlus.Business.Interfaces;
using AdiPlus.Migrations;
using AdiPlus.Models;

namespace AdiPlus.Business.Services
{
    public class AdminService : IAdminService
    {
        public void AddMaterial(ApplicationContext db, Material material)
        {
            db.Materials.Add(material);
            db.SaveChanges();
        }
        
        public void AddService(ApplicationContext db, Service service)
        {
            db.Services.Add(service);
            db.SaveChanges();
        }

        public IEnumerable GetAllMaterials(ApplicationContext db)
        {
            var materials = db.Materials;
            return materials;
        }
    }
}