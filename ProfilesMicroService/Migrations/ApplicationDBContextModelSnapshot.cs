﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ProfilesMicroService.Infrastructure;

#nullable disable

namespace ProfilesMicroService.Api.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ProfilesMicroService.Domain.Entities.Models.Doctor", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("AccountId")
                        .HasColumnType("text");

                    b.Property<string>("AccountPhoneNumber")
                        .HasColumnType("text");

                    b.Property<int>("CareerStartYear")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("MiddleName")
                        .HasColumnType("text");

                    b.Property<string>("OfficeId")
                        .HasColumnType("text");

                    b.Property<string>("SpecializationId")
                        .HasColumnType("text");

                    b.Property<string>("SpecializationName")
                        .HasColumnType("text");

                    b.Property<string>("StatusId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("ProfilesMicroService.Domain.Entities.Models.Patient", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("AccountId")
                        .HasColumnType("text");

                    b.Property<string>("AccountPhoneNumber")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("MiddleName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("ProfilesMicroService.Domain.Entities.Models.Receptionist", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("AccountId")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("MiddleName")
                        .HasColumnType("text");

                    b.Property<string>("OfficeId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Receptionists");
                });

            modelBuilder.Entity("ProfilesMicroService.Domain.Entities.Models.Status", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Statuss");

                    b.HasData(
                        new
                        {
                            Id = "242bb89f-149a-4cd0-b81f-55a378b8da3b",
                            Name = "AtWork"
                        },
                        new
                        {
                            Id = "a6dee6ab-4edf-4006-8e2f-b8be6f842b86",
                            Name = "OnVacation"
                        },
                        new
                        {
                            Id = "222ad367-3e96-41ad-b7e1-e6c3b31d408f",
                            Name = "SickDay"
                        },
                        new
                        {
                            Id = "7a55ff1b-2e82-4db5-abfb-046128e395e0",
                            Name = "SickLeave"
                        },
                        new
                        {
                            Id = "b9877be3-1b84-4083-a464-fb2c6dfda87d",
                            Name = "SelfIsolation"
                        },
                        new
                        {
                            Id = "ceb6bc1e-cc2b-43ae-8243-b73fb11a4d0f",
                            Name = "LeaveWithoutPay"
                        },
                        new
                        {
                            Id = "283f6717-6bbf-4b06-b960-2a2a6b727630",
                            Name = "Inactive"
                        });
                });

            modelBuilder.Entity("ProfilesMicroService.Domain.Entities.Models.Doctor", b =>
                {
                    b.HasOne("ProfilesMicroService.Domain.Entities.Models.Status", "Status")
                        .WithMany("Doctors")
                        .HasForeignKey("StatusId");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("ProfilesMicroService.Domain.Entities.Models.Status", b =>
                {
                    b.Navigation("Doctors");
                });
#pragma warning restore 612, 618
        }
    }
}
