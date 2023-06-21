using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MAS_PROJ.Server.Migrations
{
    public partial class EnumChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MinCrew",
                table: "WaterVehicle",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FuelSpecifics_FuelType",
                table: "WaterVehicle",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FuelSpecifics_FuelType",
                table: "LandVehicle",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "LandVehicle",
                keyColumn: "IdSubtype",
                keyValue: 1,
                columns: new[] { "FuelSpecifics_CombustionType", "FuelSpecifics_FuelType", "PoiseSpecifics_PoiseType" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.UpdateData(
                table: "LandVehicle",
                keyColumn: "IdSubtype",
                keyValue: 2,
                columns: new[] { "FuelSpecifics_BatteryType", "FuelSpecifics_FuelType", "PoiseSpecifics_PoiseType" },
                values: new object[] { 3, 2, 2 });

            migrationBuilder.UpdateData(
                table: "WaterVehicle",
                keyColumn: "IdSubtype",
                keyValue: 3,
                columns: new[] { "PurposeSpecifics_PurposeType", "FuelSpecifics_FuelType" },
                values: new object[] { 2, 3 });

            migrationBuilder.UpdateData(
                table: "WaterVehicle",
                keyColumn: "IdSubtype",
                keyValue: 4,
                columns: new[] { "PurposeSpecifics_LoadType", "PurposeSpecifics_PurposeType", "FuelSpecifics_CombustionType", "FuelSpecifics_FuelType" },
                values: new object[] { 1, 1, 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MinCrew",
                table: "WaterVehicle",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FuelSpecifics_FuelType",
                table: "WaterVehicle",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FuelSpecifics_FuelType",
                table: "LandVehicle",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "LandVehicle",
                keyColumn: "IdSubtype",
                keyValue: 1,
                columns: new[] { "FuelSpecifics_CombustionType", "FuelSpecifics_FuelType", "PoiseSpecifics_PoiseType" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "LandVehicle",
                keyColumn: "IdSubtype",
                keyValue: 2,
                columns: new[] { "FuelSpecifics_BatteryType", "FuelSpecifics_FuelType", "PoiseSpecifics_PoiseType" },
                values: new object[] { 2, 1, 1 });

            migrationBuilder.UpdateData(
                table: "WaterVehicle",
                keyColumn: "IdSubtype",
                keyValue: 3,
                columns: new[] { "FuelSpecifics_FuelType", "PurposeSpecifics_PurposeType" },
                values: new object[] { 2, 1 });

            migrationBuilder.UpdateData(
                table: "WaterVehicle",
                keyColumn: "IdSubtype",
                keyValue: 4,
                columns: new[] { "FuelSpecifics_CombustionType", "FuelSpecifics_FuelType", "PurposeSpecifics_LoadType", "PurposeSpecifics_PurposeType" },
                values: new object[] { 0, 0, 0, 0 });
        }
    }
}
