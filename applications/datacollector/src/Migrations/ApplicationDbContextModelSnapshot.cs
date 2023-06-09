﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SharedInfrastructure;

#nullable disable

namespace datacollector.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SharedModels.AQIDataPoint", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("componentsId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("dt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("main")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("componentsId");

                    b.ToTable("AQIDataPoints");
                });

            modelBuilder.Entity("SharedModels.Components", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<double>("co")
                        .HasColumnType("double");

                    b.Property<double>("nh3")
                        .HasColumnType("double");

                    b.Property<double>("no")
                        .HasColumnType("double");

                    b.Property<double>("no2")
                        .HasColumnType("double");

                    b.Property<double>("o3")
                        .HasColumnType("double");

                    b.Property<double>("pm10")
                        .HasColumnType("double");

                    b.Property<double>("pm2_5")
                        .HasColumnType("double");

                    b.Property<double>("so2")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("Components");
                });

            modelBuilder.Entity("SharedModels.AQIDataPoint", b =>
                {
                    b.HasOne("SharedModels.Components", "components")
                        .WithMany()
                        .HasForeignKey("componentsId");

                    b.Navigation("components");
                });
#pragma warning restore 612, 618
        }
    }
}
