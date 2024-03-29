﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using your_bike_admin_backend.Data;

#nullable disable

namespace your_bike_admin_backend.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20240317150937_AddYourBikeAPIWithImageCoorection")]
    partial class AddYourBikeAPIWithImageCoorection
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("your_bike_admin_backend.Models.Bike", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("CC")
                        .HasColumnType("float");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("EngineOilCapacity")
                        .HasColumnType("float");

                    b.Property<string>("FrontBreak")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FrontSuspension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FrontTyre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FrontWheel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("FuelTankCapacity")
                        .HasColumnType("float");

                    b.Property<int>("Gears")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaxPower")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaxTorque")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mileage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RearBreak")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RearSuspension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RearTyre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RearWheel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("SeatHeight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Bikes");
                });
#pragma warning restore 612, 618
        }
    }
}
