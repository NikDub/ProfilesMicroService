﻿using Microsoft.EntityFrameworkCore;
using ProfilesMicroService.Domain.Entities.Models;
using ProfilesMicroService.Infrastructure.DataBaseConfiguration;

namespace ProfilesMicroService.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Receptionist> Receptionists { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Status> Statuses { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Receptionist>().Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
        builder.Entity<Receptionist>().Property(e => e.OfficeId).IsRequired();
        builder.Entity<Receptionist>().Property(e => e.FirstName).IsRequired();
        builder.Entity<Receptionist>().Property(e => e.LastName).IsRequired();

        builder.Entity<Doctor>().Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
        builder.Entity<Doctor>().Property(e => e.OfficeId).IsRequired();
        builder.Entity<Doctor>().Property(e => e.FirstName).IsRequired();
        builder.Entity<Doctor>().Property(e => e.LastName).IsRequired();
        builder.Entity<Doctor>().Property(e => e.StatusId).IsRequired();
        builder.Entity<Doctor>().Property(e => e.CareerStartYear).IsRequired();
        builder.Entity<Doctor>().Property(e => e.SpecializationId).IsRequired();
        builder.Entity<Doctor>().Property(e => e.DateOfBirth).IsRequired();

        builder.Entity<Patient>().Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
        builder.Entity<Patient>().Property(e => e.FirstName).IsRequired();
        builder.Entity<Patient>().Property(e => e.LastName).IsRequired();
        builder.Entity<Patient>().Property(e => e.DateOfBirth).IsRequired();

        builder.Entity<Status>().Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");

        ConfigureTables(builder);
    }

    private void ConfigureTables(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new StatusConfiguration());
    }
}