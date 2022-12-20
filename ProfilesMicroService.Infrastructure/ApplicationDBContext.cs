using Microsoft.EntityFrameworkCore;
using ProfilesMicroService.Api.DataBaseConfiguration;
using ProfilesMicroService.Domain.Entities.Models;

namespace ProfilesMicroService.Infrastructure
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Receptionist> Receptionists { get; set; }
        public DbSet<Patient> Patients { get; set; }

        public DbSet<Status> Statuss { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Receptionist>().Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
            builder.Entity<Doctor>().Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
            builder.Entity<Status>().Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
            builder.Entity<Patient>().Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");

            ConfigureTables(builder);
        }

        private void ConfigureTables(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new StatusConfiguration());
        }


    }
}
