﻿// <auto-generated />
using System;
using MAS_PROJ.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MAS_PROJ.Server.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20230622134804_RefactorFailsafe")]
    partial class RefactorFailsafe
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MAS_PROJ.Shared.Models.Part", b =>
                {
                    b.Property<int>("IdPart")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPart"), 1L, 1);

                    b.Property<decimal>("CurrentPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("IdPartParent")
                        .HasColumnType("int");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PartCategory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PartType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPart");

                    b.HasIndex("IdPartParent");

                    b.ToTable("Part");
                });

            modelBuilder.Entity("MAS_PROJ.Shared.Models.Product", b =>
                {
                    b.Property<int>("IdProduct")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProduct"), 1L, 1);

                    b.Property<int?>("PartIdPart")
                        .HasColumnType("int");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("IdProduct");

                    b.HasIndex("PartIdPart");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("MAS_PROJ.Shared.Models.ProductReference", b =>
                {
                    b.Property<int?>("IdPart")
                        .HasColumnType("int");

                    b.Property<int>("IdProduct")
                        .HasColumnType("int");

                    b.Property<int?>("IdSale")
                        .HasColumnType("int");

                    b.Property<decimal?>("SalePrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdPart", "IdProduct");

                    b.HasIndex("IdSale");

                    b.ToTable("ProductReference");
                });

            modelBuilder.Entity("MAS_PROJ.Shared.Models.Sale", b =>
                {
                    b.Property<int>("IdSale")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfTransaction")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdEmployee")
                        .HasColumnType("int");

                    b.Property<int?>("IdUser")
                        .HasColumnType("int");

                    b.HasKey("IdSale");

                    b.HasIndex("IdUser");

                    b.ToTable("Sale");
                });

            modelBuilder.Entity("MAS_PROJ.Shared.Models.SystemUser", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUser"), 1L, 1);

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUser");

                    b.ToTable("SystemUser");

                    b.HasDiscriminator<string>("Discriminator").HasValue("SystemUser");
                });

            modelBuilder.Entity("MAS_PROJ.Shared.Models.Vehicle", b =>
                {
                    b.Property<int>("IdVehicle")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdVehicle"), 1L, 1);

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ProductionEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ProductionStart")
                        .HasColumnType("datetime2");

                    b.Property<string>("VehicleNotes")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdVehicle");

                    b.ToTable("Vehicles");

                    b.HasData(
                        new
                        {
                            IdVehicle = 1,
                            Manufacturer = "Toyota",
                            Model = "Corolla",
                            ProductionEnd = new DateTime(2001, 1, 29, 0, 3, 0, 0, DateTimeKind.Unspecified),
                            ProductionStart = new DateTime(1997, 1, 2, 0, 3, 0, 0, DateTimeKind.Unspecified),
                            VehicleNotes = "Pre lift"
                        },
                        new
                        {
                            IdVehicle = 2,
                            Manufacturer = "PC",
                            Model = "M3",
                            ProductionEnd = new DateTime(2016, 1, 9, 0, 12, 0, 0, DateTimeKind.Unspecified),
                            ProductionStart = new DateTime(2014, 1, 11, 0, 11, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            IdVehicle = 3,
                            Manufacturer = "BoatFirm",
                            Model = "Floater",
                            ProductionEnd = new DateTime(2012, 1, 1, 0, 2, 0, 0, DateTimeKind.Unspecified),
                            ProductionStart = new DateTime(2004, 1, 2, 0, 3, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            IdVehicle = 4,
                            Manufacturer = "TTT",
                            Model = "Transporter",
                            ProductionEnd = new DateTime(2012, 1, 1, 0, 2, 0, 0, DateTimeKind.Unspecified),
                            ProductionStart = new DateTime(2004, 1, 2, 0, 3, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("MAS_PROJ.Shared.Models.VehiclePart", b =>
                {
                    b.Property<int>("IdVehicle")
                        .HasColumnType("int");

                    b.Property<int>("IdPart")
                        .HasColumnType("int");

                    b.HasKey("IdVehicle", "IdPart");

                    b.HasIndex("IdPart");

                    b.ToTable("VehiclePart");
                });

            modelBuilder.Entity("MAS_PROJ.Shared.Models.VehicleSubType", b =>
                {
                    b.Property<int>("IdSubtype")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSubtype"), 1L, 1);

                    b.Property<int?>("IdVehicle")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubtypeNotes")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdSubtype");

                    b.HasIndex("IdVehicle");

                    b.ToTable("VehicleTypes");
                });

            modelBuilder.Entity("MAS_PROJ.Shared.Models.ClientFirm", b =>
                {
                    b.HasBaseType("MAS_PROJ.Shared.Models.SystemUser");

                    b.Property<string>("RegonNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("ClientFirm");
                });

            modelBuilder.Entity("MAS_PROJ.Shared.Models.ClientPerson", b =>
                {
                    b.HasBaseType("MAS_PROJ.Shared.Models.SystemUser");

                    b.HasDiscriminator().HasValue("ClientPerson");
                });

            modelBuilder.Entity("MAS_PROJ.Shared.Models.Employee", b =>
                {
                    b.HasBaseType("MAS_PROJ.Shared.Models.SystemUser");

                    b.Property<decimal>("CurrentSalary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("EmployeeNotes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FireDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("datetime2");

                    b.HasDiscriminator().HasValue("Employee");
                });

            modelBuilder.Entity("MAS_PROJ.Shared.Models.LandVehicle", b =>
                {
                    b.HasBaseType("MAS_PROJ.Shared.Models.VehicleSubType");

                    b.Property<int?>("EnginePower")
                        .HasColumnType("int");

                    b.Property<int?>("EngineTorque")
                        .HasColumnType("int");

                    b.ToTable("LandVehicle", (string)null);

                    b.HasData(
                        new
                        {
                            IdSubtype = 1,
                            IdVehicle = 1,
                            Name = "Basic",
                            EnginePower = 86,
                            EngineTorque = 90
                        },
                        new
                        {
                            IdSubtype = 2,
                            IdVehicle = 2,
                            Name = "Premium",
                            EnginePower = 120,
                            EngineTorque = 150
                        });
                });

            modelBuilder.Entity("MAS_PROJ.Shared.Models.WaterVehicle", b =>
                {
                    b.HasBaseType("MAS_PROJ.Shared.Models.VehicleSubType");

                    b.Property<int?>("MinCrew")
                        .HasColumnType("int");

                    b.ToTable("WaterVehicle", (string)null);

                    b.HasData(
                        new
                        {
                            IdSubtype = 3,
                            IdVehicle = 3,
                            Name = "Unsinkable Type",
                            MinCrew = 12
                        },
                        new
                        {
                            IdSubtype = 4,
                            IdVehicle = 4,
                            Name = "Tanker",
                            MinCrew = 35
                        });
                });

            modelBuilder.Entity("MAS_PROJ.Shared.Models.Part", b =>
                {
                    b.HasOne("MAS_PROJ.Shared.Models.Part", "PartParent")
                        .WithMany("AlternativePartNavigation")
                        .HasForeignKey("IdPartParent")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("PartParent");
                });

            modelBuilder.Entity("MAS_PROJ.Shared.Models.Product", b =>
                {
                    b.HasOne("MAS_PROJ.Shared.Models.Part", null)
                        .WithMany("Products")
                        .HasForeignKey("PartIdPart");
                });

            modelBuilder.Entity("MAS_PROJ.Shared.Models.ProductReference", b =>
                {
                    b.HasOne("MAS_PROJ.Shared.Models.Part", "PartNavigation")
                        .WithMany("ProductReferenceNavigation")
                        .HasForeignKey("IdPart")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("MAS_PROJ.Shared.Models.Sale", "SaleNavigation")
                        .WithMany("ProductReferenceNavigation")
                        .HasForeignKey("IdSale");

                    b.Navigation("PartNavigation");

                    b.Navigation("SaleNavigation");
                });

            modelBuilder.Entity("MAS_PROJ.Shared.Models.Sale", b =>
                {
                    b.HasOne("MAS_PROJ.Shared.Models.Employee", "EmployeeNavigation")
                        .WithMany("PerformedSaleNavigation")
                        .HasForeignKey("IdSale")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MAS_PROJ.Shared.Models.SystemUser", "BuyerNavigation")
                        .WithMany("OwnSaleNavigation")
                        .HasForeignKey("IdUser");

                    b.Navigation("BuyerNavigation");

                    b.Navigation("EmployeeNavigation");
                });

            modelBuilder.Entity("MAS_PROJ.Shared.Models.VehiclePart", b =>
                {
                    b.HasOne("MAS_PROJ.Shared.Models.Part", "PartNavigation")
                        .WithMany("VehiclePartNavigation")
                        .HasForeignKey("IdPart")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MAS_PROJ.Shared.Models.Vehicle", "VehicleNavigation")
                        .WithMany("VehiclePartNavigation")
                        .HasForeignKey("IdVehicle")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PartNavigation");

                    b.Navigation("VehicleNavigation");
                });

            modelBuilder.Entity("MAS_PROJ.Shared.Models.VehicleSubType", b =>
                {
                    b.HasOne("MAS_PROJ.Shared.Models.Vehicle", "VehicleNavigation")
                        .WithMany("VehicleSubTypeNavigation")
                        .HasForeignKey("IdVehicle")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("VehicleNavigation");
                });

            modelBuilder.Entity("MAS_PROJ.Shared.Models.ClientFirm", b =>
                {
                    b.OwnsOne("MAS_PROJ.Shared.Models.ClientData", "ClientData", b1 =>
                        {
                            b1.Property<int>("ClientFirmIdUser")
                                .HasColumnType("int");

                            b1.Property<string>("ClientNotes")
                                .ValueGeneratedOnUpdateSometimes()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<DateTime>("RegistrationDate")
                                .ValueGeneratedOnUpdateSometimes()
                                .HasColumnType("datetime2");

                            b1.HasKey("ClientFirmIdUser");

                            b1.ToTable("SystemUser");

                            b1.WithOwner()
                                .HasForeignKey("ClientFirmIdUser");
                        });

                    b.Navigation("ClientData")
                        .IsRequired();
                });

            modelBuilder.Entity("MAS_PROJ.Shared.Models.ClientPerson", b =>
                {
                    b.OwnsOne("MAS_PROJ.Shared.Models.ClientData", "ClientData", b1 =>
                        {
                            b1.Property<int>("ClientPersonIdUser")
                                .HasColumnType("int");

                            b1.Property<string>("ClientNotes")
                                .ValueGeneratedOnUpdateSometimes()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<DateTime>("RegistrationDate")
                                .ValueGeneratedOnUpdateSometimes()
                                .HasColumnType("datetime2");

                            b1.HasKey("ClientPersonIdUser");

                            b1.ToTable("SystemUser");

                            b1.WithOwner()
                                .HasForeignKey("ClientPersonIdUser");
                        });

                    b.OwnsOne("MAS_PROJ.Shared.Models.PersonalData", "PersonalData", b1 =>
                        {
                            b1.Property<int>("ClientPersonIdUser")
                                .HasColumnType("int");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .ValueGeneratedOnUpdateSometimes()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .ValueGeneratedOnUpdateSometimes()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ClientPersonIdUser");

                            b1.ToTable("SystemUser");

                            b1.WithOwner()
                                .HasForeignKey("ClientPersonIdUser");
                        });

                    b.Navigation("ClientData")
                        .IsRequired();

                    b.Navigation("PersonalData")
                        .IsRequired();
                });

            modelBuilder.Entity("MAS_PROJ.Shared.Models.Employee", b =>
                {
                    b.OwnsOne("MAS_PROJ.Shared.Models.PersonalData", "PersonalData", b1 =>
                        {
                            b1.Property<int>("EmployeeIdUser")
                                .HasColumnType("int");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .ValueGeneratedOnUpdateSometimes()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .ValueGeneratedOnUpdateSometimes()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("EmployeeIdUser");

                            b1.ToTable("SystemUser");

                            b1.WithOwner()
                                .HasForeignKey("EmployeeIdUser");
                        });

                    b.Navigation("PersonalData")
                        .IsRequired();
                });

            modelBuilder.Entity("MAS_PROJ.Shared.Models.LandVehicle", b =>
                {
                    b.HasOne("MAS_PROJ.Shared.Models.VehicleSubType", null)
                        .WithOne()
                        .HasForeignKey("MAS_PROJ.Shared.Models.LandVehicle", "IdSubtype")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.OwnsOne("MAS_PROJ.Shared.Models.FuelSpecifics", "FuelSpecifics", b1 =>
                        {
                            b1.Property<int>("LandVehicleIdSubtype")
                                .HasColumnType("int");

                            b1.Property<int?>("BatteryCapacity")
                                .HasColumnType("int");

                            b1.Property<int?>("BatteryType")
                                .HasColumnType("int");

                            b1.Property<int?>("CombustionType")
                                .HasColumnType("int");

                            b1.Property<int>("FuelType")
                                .HasColumnType("int");

                            b1.Property<string>("FuelTypeDescription")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int?>("TankCapacity")
                                .HasColumnType("int");

                            b1.HasKey("LandVehicleIdSubtype");

                            b1.ToTable("LandVehicle");

                            b1.WithOwner()
                                .HasForeignKey("LandVehicleIdSubtype");

                            b1.HasData(
                                new
                                {
                                    LandVehicleIdSubtype = 1,
                                    CombustionType = 1,
                                    FuelType = 1,
                                    TankCapacity = 60
                                },
                                new
                                {
                                    LandVehicleIdSubtype = 2,
                                    BatteryCapacity = 120,
                                    BatteryType = 3,
                                    FuelType = 2
                                });
                        });

                    b.OwnsOne("MAS_PROJ.Shared.Models.PoiseSpecifics", "PoiseSpecifics", b1 =>
                        {
                            b1.Property<int>("LandVehicleIdSubtype")
                                .HasColumnType("int");

                            b1.Property<int>("PoiseType")
                                .HasColumnType("int");

                            b1.Property<int?>("TrackLength")
                                .HasColumnType("int");

                            b1.Property<int?>("TrackWidth")
                                .HasColumnType("int");

                            b1.Property<int?>("WheelAmount")
                                .HasColumnType("int");

                            b1.Property<int?>("WheelWidth")
                                .HasColumnType("int");

                            b1.HasKey("LandVehicleIdSubtype");

                            b1.ToTable("LandVehicle");

                            b1.WithOwner()
                                .HasForeignKey("LandVehicleIdSubtype");

                            b1.HasData(
                                new
                                {
                                    LandVehicleIdSubtype = 1,
                                    PoiseType = 1,
                                    WheelAmount = 4,
                                    WheelWidth = 18
                                },
                                new
                                {
                                    LandVehicleIdSubtype = 2,
                                    PoiseType = 2,
                                    TrackLength = 20,
                                    TrackWidth = 20
                                });
                        });

                    b.Navigation("FuelSpecifics")
                        .IsRequired();

                    b.Navigation("PoiseSpecifics")
                        .IsRequired();
                });

            modelBuilder.Entity("MAS_PROJ.Shared.Models.WaterVehicle", b =>
                {
                    b.HasOne("MAS_PROJ.Shared.Models.VehicleSubType", null)
                        .WithOne()
                        .HasForeignKey("MAS_PROJ.Shared.Models.WaterVehicle", "IdSubtype")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.OwnsOne("MAS_PROJ.Shared.Models.PurposeSpecifics", "PurposeSpecifics", b1 =>
                        {
                            b1.Property<int>("WaterVehicleIdSubtype")
                                .HasColumnType("int");

                            b1.Property<int?>("LoadType")
                                .HasColumnType("int");

                            b1.Property<int?>("MaxPassengers")
                                .HasColumnType("int");

                            b1.Property<int?>("MinLifeBoats")
                                .HasColumnType("int");

                            b1.Property<int>("PurposeType")
                                .HasColumnType("int");

                            b1.Property<int?>("ShipCapacity")
                                .HasColumnType("int");

                            b1.HasKey("WaterVehicleIdSubtype");

                            b1.ToTable("WaterVehicle");

                            b1.WithOwner()
                                .HasForeignKey("WaterVehicleIdSubtype");

                            b1.HasData(
                                new
                                {
                                    WaterVehicleIdSubtype = 3,
                                    MaxPassengers = 100,
                                    MinLifeBoats = 5,
                                    PurposeType = 2
                                },
                                new
                                {
                                    WaterVehicleIdSubtype = 4,
                                    LoadType = 1,
                                    PurposeType = 1,
                                    ShipCapacity = 123
                                });
                        });

                    b.OwnsOne("MAS_PROJ.Shared.Models.FuelSpecifics", "FuelSpecifics", b1 =>
                        {
                            b1.Property<int>("WaterVehicleIdSubtype")
                                .HasColumnType("int");

                            b1.Property<int?>("BatteryCapacity")
                                .HasColumnType("int");

                            b1.Property<int?>("BatteryType")
                                .HasColumnType("int");

                            b1.Property<int?>("CombustionType")
                                .HasColumnType("int");

                            b1.Property<int>("FuelType")
                                .HasColumnType("int");

                            b1.Property<string>("FuelTypeDescription")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int?>("TankCapacity")
                                .HasColumnType("int");

                            b1.HasKey("WaterVehicleIdSubtype");

                            b1.ToTable("WaterVehicle");

                            b1.WithOwner()
                                .HasForeignKey("WaterVehicleIdSubtype");

                            b1.HasData(
                                new
                                {
                                    WaterVehicleIdSubtype = 3,
                                    FuelType = 3,
                                    FuelTypeDescription = "Sail"
                                },
                                new
                                {
                                    WaterVehicleIdSubtype = 4,
                                    CombustionType = 1,
                                    FuelType = 1,
                                    TankCapacity = 2000
                                });
                        });

                    b.Navigation("FuelSpecifics")
                        .IsRequired();

                    b.Navigation("PurposeSpecifics")
                        .IsRequired();
                });

            modelBuilder.Entity("MAS_PROJ.Shared.Models.Part", b =>
                {
                    b.Navigation("AlternativePartNavigation");

                    b.Navigation("ProductReferenceNavigation");

                    b.Navigation("Products");

                    b.Navigation("VehiclePartNavigation");
                });

            modelBuilder.Entity("MAS_PROJ.Shared.Models.Sale", b =>
                {
                    b.Navigation("ProductReferenceNavigation");
                });

            modelBuilder.Entity("MAS_PROJ.Shared.Models.SystemUser", b =>
                {
                    b.Navigation("OwnSaleNavigation");
                });

            modelBuilder.Entity("MAS_PROJ.Shared.Models.Vehicle", b =>
                {
                    b.Navigation("VehiclePartNavigation");

                    b.Navigation("VehicleSubTypeNavigation");
                });

            modelBuilder.Entity("MAS_PROJ.Shared.Models.Employee", b =>
                {
                    b.Navigation("PerformedSaleNavigation");
                });
#pragma warning restore 612, 618
        }
    }
}
