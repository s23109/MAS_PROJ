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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Vehicle>(model => {

                model.HasKey(e => e.IdVehicle);

                model.HasMany(e => e.VehicleSubTypeNavigation)
                .WithOne(e => e.VehicleNavigation)
                .HasForeignKey(e => e.IdVehicle)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);
            
            });

            modelBuilder.Entity<VehicleSubType>(model => {
                model.HasKey(e => e.IdSubtype);
            });

            modelBuilder.Entity<LandVehicle>(model => {
                model.OwnsOne(e => e.FuelSpecifics);
                model.OwnsOne(e => e.PoiseSpecifics);

            });

            modelBuilder.Entity<WaterVehicle>(model => {
                model.OwnsOne(e => e.FuelSpecifics);
                model.OwnsOne(e => e.PurposeSpecifics);
            });

            modelBuilder.Entity<VehiclePart>(model => {
                model.HasKey(e => new { e.IdVehicle, e.IdPart });

                model.HasOne(e => e.VehicleNavigation).WithMany(e => e.VehiclePartNavigation).HasForeignKey(e => e.IdVehicle);
                model.HasOne(e => e.PartNavigation).WithMany(e => e.VehiclePartNavigation).HasForeignKey(e => e.IdPart);
            });

            modelBuilder.Entity<Part>(model => {
                model.HasKey(e => e.IdPart);

                model.HasMany(e => e.ProductReferenceNavigation)
                .WithOne(e => e.PartNavigation)
                .HasForeignKey(e => e.IdPart)
                .OnDelete(DeleteBehavior.SetNull);
            
            });

            modelBuilder.Entity<ProductReference>(model => {
                model.HasKey(e => new { e.IdPart, e.IdProduct });

                model.HasOne(e => e.SaleNavigation).
                WithMany(e => e.ProductReferenceNavigation)
                .HasForeignKey(e => e.IdSale);
            });

            modelBuilder.Entity<Sale>(model => {
                model.HasKey(e => e.IdSale);

                model.HasOne(e => e.BuyerNavigation)
                .WithMany(e => e.OwnSaleNavigation)
                .HasForeignKey(e => e.IdUser);

            });

            modelBuilder.Entity<SystemUser>(model => {
                model.HasKey(e => e.IdUser);
            });

            modelBuilder.Entity<Employee>(model => {
                model.OwnsOne(e => e.PersonalData);

                model.HasMany(e => e.PerformedSaleNavigation)
                .WithOne(e => e.EmployeeNavigation)
                .HasForeignKey(e => e.IdSale);
            });

            modelBuilder.Entity<ClientPerson>(model => {
                model.OwnsOne(e => e.PersonalData);
                model.OwnsOne(e => e.ClientData);
            });

            modelBuilder.Entity<ClientFirm>(model => {
                model.OwnsOne(e => e.ClientData);
            });

            
        }
    }
}
