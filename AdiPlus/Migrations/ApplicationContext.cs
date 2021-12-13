using AdiPlus.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MoreHealth.Models;

namespace AdiPlus.Migrations
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }
        
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentMaterialUsed> AppointmentMaterialUseds { get; set; }
        public DbSet<Cabinet> Cabinets { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<MedicalCard> MedicalCards { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceMeterialStandart> ServiceMeterialStandarts { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<WorkSchedule> WorkSchedules { get; set; }
    }
}