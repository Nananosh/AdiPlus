using System.Collections;
using AdiPlus.Migrations;
using AdiPlus.Models;

namespace AdiPlus.Business.Interfaces
{
    public interface IAdminService
    {
        public void AddMaterial(ApplicationContext db, Material material);
        public void AddService(ApplicationContext db, Service service);
        public IEnumerable GetAllMaterials(ApplicationContext db);
    }
}