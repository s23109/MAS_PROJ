using Microsoft.EntityFrameworkCore;

namespace MAS_PROJ.Server.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleSubType> VehicleTypes { get; set; }
        public DbSet<WaterVehicle> WaterVehicles { get; set; }
        public DbSet<LandVehicle> LandVehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Vehicle>(model =>
            {

                model.HasKey(e => e.IdVehicle);

                model.HasMany(e => e.VehicleSubTypeNavigation)
                .WithOne(e => e.VehicleNavigation)
                .HasForeignKey(e => e.IdVehicle)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

                model.HasData(
                    new Vehicle
                    {
                        IdVehicle = 1,
                        Manufacturer = "Toyota",
                        Model = "Corolla",
                        ProductionStart = DateTime.ParseExact("02-03-1997", "dd-mm-yyyy", System.Globalization.CultureInfo.InvariantCulture),
                        ProductionEnd = DateTime.ParseExact("29-03-2001", "dd-mm-yyyy", System.Globalization.CultureInfo.InvariantCulture),
                        VehicleNotes = "Pre lift"
                    },
                    new Vehicle
                    {
                        IdVehicle = 2,
                        Manufacturer = "PC",
                        Model = "M3",
                        ProductionStart = DateTime.ParseExact("11-11-2014", "dd-mm-yyyy", System.Globalization.CultureInfo.InvariantCulture),
                        ProductionEnd = DateTime.ParseExact("09-12-2016", "dd-mm-yyyy", System.Globalization.CultureInfo.InvariantCulture)
                    },
                    new Vehicle
                    {
                        IdVehicle = 3,
                        Manufacturer = "BoatFirm",
                        Model = "Floater",
                        ProductionStart = DateTime.ParseExact("02-03-2004", "dd-mm-yyyy", System.Globalization.CultureInfo.InvariantCulture),
                        ProductionEnd = DateTime.ParseExact("01-02-2012", "dd-mm-yyyy", System.Globalization.CultureInfo.InvariantCulture)
                    },
                    new Vehicle
                    {
                        IdVehicle = 4,
                        Manufacturer = "TTT",
                        Model = "Transporter",
                        ProductionStart = DateTime.ParseExact("02-03-2004", "dd-mm-yyyy", System.Globalization.CultureInfo.InvariantCulture),
                        ProductionEnd = DateTime.ParseExact("01-02-2012", "dd-mm-yyyy", System.Globalization.CultureInfo.InvariantCulture)
                    }
                    );

            });

            modelBuilder.Entity<VehicleSubType>(model =>
            {
                model.HasKey(e => e.IdSubtype);
            });


            modelBuilder.Entity<LandVehicle>(model =>
            {
                model.ToTable("LandVehicle");

                model.HasData(
                    new
                    {
                        Name = "Basic",
                        IdSubtype = 1,
                        IdVehicle = 1,
                        EnginePower = 86,
                        EngineTorque = 90
                    },

                    new
                    {
                        Name = "Premium",
                        IdSubtype = 2,
                        IdVehicle = 2,
                        EnginePower = 120,
                        EngineTorque = 150
                    }
                );
                //Oddzielny init owned obiektów 
                model.OwnsOne(e => e.FuelSpecifics).HasData(
                    new
                    {
                        LandVehicleIdSubtype = 1,
                        IdVehicle = 1,
                        FuelSpecifics =
                        new FuelSpecifics()
                        {
                            FuelTypes = new HashSet<FuelType> { new FuelType { FuelTypes = FuelTypes.Combustion } },
                            CombustionType = new CombustionType { CombustionTypes = CombustionTypes.Diesel },
                            TankCapacity = 60
                        },
                    },
                    new
                    {
                        LandVehicleIdSubtype = 2,
                        IdVehicle = 2,
                        FuelSpecifics =
                        new FuelSpecifics()
                        {
                            FuelTypes = new HashSet<FuelType> { new FuelType { FuelTypes = FuelTypes.Electric } },
                            BatteryType = new BatteryType { BatteryTypes = BatteryTypes.LFP },
                            BatteryCapacity = 120,
                        },
                    }
                    );

                model.OwnsOne(e => e.PoiseSpecifics).HasData(
                    new
                    {
                        LandVehicleIdSubtype = 1,
                        IdVehicle = 1,
                        PoiseSpecifics =
                        new PoiseSpecifics
                        {
                            PoiseTypes = new HashSet<PoiseType> { new PoiseType { PoiseTypes = PoiseTypes.Wheels } },
                            WheelAmount = 4,
                            WheelWidth = 18
                        }
                    },
                    new
                    {
                        LandVehicleIdSubtype = 2,
                        IdVehicle = 2,
                        PoiseSpecifics =
                        new PoiseSpecifics
                        {
                            PoiseTypes = new HashSet<PoiseType> { new PoiseType { PoiseTypes = PoiseTypes.Tracks } },
                            TrackLength = 20,
                            TrackWidth = 20
                        }
                    }
                    );
            });

            modelBuilder.Entity<WaterVehicle>(model =>
            {
                model.ToTable("WaterVehicle");

                model.HasData(
                    new WaterVehicle
                    {
                        Name = "Unsinkable Type",
                        IdSubtype = 3,
                        IdVehicle = 3,
                        MinCrew = 12
                    },
                    new WaterVehicle
                    {
                        Name = "Tanker",
                        IdSubtype = 4,
                        IdVehicle = 4,
                        MinCrew = 35
                    }
                    );

                model.OwnsOne(e => e.FuelSpecifics).HasData(
                    new {
                        WaterVehicleIdSubtype = 3,
                        IdVehicle = 3,
                        FuelSpecifics =
                        new FuelSpecifics
                        {
                            FuelTypes = new HashSet<FuelType> { new FuelType { FuelTypes = FuelTypes.Other } },
                            FuelTypeDescription = "Sail"
                        }
                    },
                    new
                    {
                        WaterVehicleIdSubtype = 4,
                        IdVehicle = 4,
                        FuelSpecifics =
                        new FuelSpecifics
                        {
                            FuelTypes = new HashSet<FuelType> { new FuelType { FuelTypes = FuelTypes.Combustion } },
                            CombustionType = new CombustionType { CombustionTypes = CombustionTypes.Diesel },
                            TankCapacity = 2000
                        }
                    }
                    );
                model.OwnsOne(e => e.PurposeSpecifics).HasData(
                    new
                    {
                        WaterVehicleIdSubtype = 3,
                        IdVehicle = 3,
                        PurposeSpecifics =
                        new PurposeSpecifics
                        {
                            Purposes = new HashSet<PurposeType> { new PurposeType { PurposeTypes = PurposeTypes.Passenger } },
                            MaxPassengers = 100,
                            MinLifeBoats = 5
                        }

                    },
                    new
                    {
                        WaterVehicleIdSubtype = 4,
                        IdVehicle = 4,
                        PurposeSpecifics =
                        new PurposeSpecifics
                        {
                            Purposes = new HashSet<PurposeType> { new PurposeType { PurposeTypes = PurposeTypes.Transport } },
                            Loads = new HashSet<LoadType> { new LoadType { LoadTypes = LoadTypes.Liquid } },
                            ShipCapacity = 123
                        }
                    }



                    );
            });

            modelBuilder.Entity<VehiclePart>(model =>
            {
                model.HasKey(e => new { e.IdVehicle, e.IdPart });

                model.HasOne(e => e.VehicleNavigation).WithMany(e => e.VehiclePartNavigation).HasForeignKey(e => e.IdVehicle);
                model.HasOne(e => e.PartNavigation).WithMany(e => e.VehiclePartNavigation).HasForeignKey(e => e.IdPart);
            });

            modelBuilder.Entity<Part>(model =>
            {
                model.HasKey(e => e.IdPart);

                model.HasMany(e => e.ProductReferenceNavigation)
                .WithOne(e => e.PartNavigation)
                .HasForeignKey(e => e.IdPart)
                .OnDelete(DeleteBehavior.NoAction);

                model.HasMany(e => e.AlternativePartNavigation)
                .WithOne(e => e.PartParent)
                .HasForeignKey(e => e.IdPartParent)
                .OnDelete(DeleteBehavior.NoAction);

            });

            modelBuilder.Entity<ProductReference>(model =>
            {
                model.HasKey(e => new { e.IdPart, e.IdProduct });

                model.HasOne(e => e.SaleNavigation).
                WithMany(e => e.ProductReferenceNavigation)
                .HasForeignKey(e => e.IdSale);
            });

            modelBuilder.Entity<Sale>(model =>
            {
                model.HasKey(e => e.IdSale);

                model.HasOne(e => e.BuyerNavigation)
                .WithMany(e => e.OwnSaleNavigation)
                .HasForeignKey(e => e.IdUser);

            });

            modelBuilder.Entity<SystemUser>(model =>
            {
                model.HasKey(e => e.IdUser);
            });

            modelBuilder.Entity<Employee>(model =>
            {
                model.OwnsOne(e => e.PersonalData);

                model.HasMany(e => e.PerformedSaleNavigation)
                .WithOne(e => e.EmployeeNavigation)
                .HasForeignKey(e => e.IdSale);
            });

            modelBuilder.Entity<ClientPerson>(model =>
            {
                model.OwnsOne(e => e.PersonalData);
                model.OwnsOne(e => e.ClientData);
            });

            modelBuilder.Entity<ClientFirm>(model =>
            {
                model.OwnsOne(e => e.ClientData);
            });


        }
    }
}
