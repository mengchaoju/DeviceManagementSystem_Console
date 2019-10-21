﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestDevice;

namespace TestDevice.Migrations
{
    [DbContext(typeof(DeviceContext))]
    partial class DeviceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("TestDevice.Device", b =>
                {
                    b.Property<int>("DeviceID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("DeviceID");

                    b.ToTable("Devices");
                });
#pragma warning restore 612, 618
        }
    }
}

