using System.Threading.Tasks;

namespace AdiPlus.Business.Interfaces
{
    public interface ISeedDatabaseService
    {
        public Task CreateStartAdmin();
        public Task CreateStartRole();
    }
}