using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) :
            base(options) { }


        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Office> Offices { get; set; }

        public DbSet<Reserve> Reserves { get; set; }
    }
}