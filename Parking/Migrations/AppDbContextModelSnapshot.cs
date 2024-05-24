﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Parking.Data;

#nullable disable

namespace Parking.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.5");

            modelBuilder.Entity("Parking.Models.Car", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("Parking.Models.Parking", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Capacity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("StreetNr")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Parkings");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d779316a-aa42-45ed-a4f0-b3ea3e1de3b0"),
                            Capacity = 100,
                            City = "Warszawa",
                            Description = "Big parking near Legia",
                            Logo = "",
                            Name = "Parking A",
                            Street = "Lazienkowska",
                            StreetNr = "1"
                        },
                        new
                        {
                            Id = new Guid("472cec39-7639-4903-9d1a-f03f38c93ced"),
                            Capacity = 150,
                            City = "Krakow",
                            Description = "Parking dla kibicow Cracovii",
                            Logo = "",
                            Name = "Parking B",
                            Street = "Reymonta",
                            StreetNr = "2"
                        },
                        new
                        {
                            Id = new Guid("697ef19f-b4cc-4572-8b76-27cd7821dd7e"),
                            Capacity = 200,
                            City = "Krakow",
                            Description = "Parking Wiselki",
                            Logo = "",
                            Name = "Parking Wiselka",
                            Street = "Reymonta",
                            StreetNr = "3"
                        });
                });

            modelBuilder.Entity("Parking.Models.ParkingSlot", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ParkingId")
                        .HasColumnType("TEXT");

                    b.Property<string>("SlotNr")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ParkingId");

                    b.ToTable("ParkingSlots");
                });

            modelBuilder.Entity("Parking.Models.Reservation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CarId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("ParkingSlotId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("ParkingSlotId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("Parking.Models.ParkingSlot", b =>
                {
                    b.HasOne("Parking.Models.Parking", "Parking")
                        .WithMany("ParkingSlots")
                        .HasForeignKey("ParkingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parking");
                });

            modelBuilder.Entity("Parking.Models.Reservation", b =>
                {
                    b.HasOne("Parking.Models.Car", "Car")
                        .WithMany("Reservations")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Parking.Models.ParkingSlot", "ParkingSlot")
                        .WithMany("Reservations")
                        .HasForeignKey("ParkingSlotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("ParkingSlot");
                });

            modelBuilder.Entity("Parking.Models.Car", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("Parking.Models.Parking", b =>
                {
                    b.Navigation("ParkingSlots");
                });

            modelBuilder.Entity("Parking.Models.ParkingSlot", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
