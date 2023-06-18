using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MAS_PROJ.Server.Migrations
{
    public partial class IdsInEnumWrappersDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FuelSpecifics_BatteryType_Id",
                table: "WaterVehicle");

            migrationBuilder.DropColumn(
                name: "FuelSpecifics_BatteryType_Id",
                table: "LandVehicle");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FuelSpecifics_BatteryType_Id",
                table: "WaterVehicle",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FuelSpecifics_BatteryType_Id",
                table: "LandVehicle",
                type: "int",
                nullable: true);
        }
    }
}
