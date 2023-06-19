using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MAS_PROJ.Server.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LandVehicle_FuelTypes");

            migrationBuilder.DropTable(
                name: "LoadType");

            migrationBuilder.DropTable(
                name: "PoiseType");

            migrationBuilder.DropTable(
                name: "PurposeType");

            migrationBuilder.DropTable(
                name: "WaterVehicle_FuelTypes");

            migrationBuilder.RenameColumn(
                name: "FuelSpecifics_CombustionType_CombustionTypes",
                table: "WaterVehicle",
                newName: "PurposeSpecifics_LoadType");

            migrationBuilder.RenameColumn(
                name: "FuelSpecifics_BatteryType_BatteryTypes",
                table: "WaterVehicle",
                newName: "FuelSpecifics_FuelType");

            migrationBuilder.RenameColumn(
                name: "FuelSpecifics_CombustionType_CombustionTypes",
                table: "LandVehicle",
                newName: "FuelSpecifics_FuelType");

            migrationBuilder.RenameColumn(
                name: "FuelSpecifics_BatteryType_BatteryTypes",
                table: "LandVehicle",
                newName: "FuelSpecifics_CombustionType");

            migrationBuilder.AddColumn<int>(
                name: "FuelSpecifics_BatteryType",
                table: "WaterVehicle",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FuelSpecifics_CombustionType",
                table: "WaterVehicle",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PurposeSpecifics_PurposeType",
                table: "WaterVehicle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FuelSpecifics_BatteryType",
                table: "LandVehicle",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PoiseSpecifics_PoiseType",
                table: "LandVehicle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "LandVehicle",
                keyColumn: "IdSubtype",
                keyValue: 1,
                columns: new[] { "EnginePower", "EngineTorque", "FuelSpecifics_CombustionType", "FuelSpecifics_FuelType", "FuelSpecifics_TankCapacity", "PoiseSpecifics_WheelAmount", "PoiseSpecifics_WheelWidth" },
                values: new object[] { 86, 90, 0, 0, 60, 4, 18 });

            migrationBuilder.UpdateData(
                table: "LandVehicle",
                keyColumn: "IdSubtype",
                keyValue: 2,
                columns: new[] { "EnginePower", "EngineTorque", "FuelSpecifics_BatteryCapacity", "FuelSpecifics_BatteryType", "FuelSpecifics_FuelType", "PoiseSpecifics_PoiseType", "PoiseSpecifics_TrackLength", "PoiseSpecifics_TrackWidth" },
                values: new object[] { 120, 150, 120, 2, 1, 1, 20, 20 });

            migrationBuilder.UpdateData(
                table: "VehicleTypes",
                keyColumn: "IdSubtype",
                keyValue: 1,
                columns: new[] { "IdVehicle", "Name" },
                values: new object[] { 1, "Basic" });

            migrationBuilder.UpdateData(
                table: "VehicleTypes",
                keyColumn: "IdSubtype",
                keyValue: 2,
                columns: new[] { "IdVehicle", "Name" },
                values: new object[] { 2, "Premium" });

            migrationBuilder.UpdateData(
                table: "VehicleTypes",
                keyColumn: "IdSubtype",
                keyValue: 3,
                columns: new[] { "IdVehicle", "Name" },
                values: new object[] { 3, "Unsinkable Type" });

            migrationBuilder.UpdateData(
                table: "VehicleTypes",
                keyColumn: "IdSubtype",
                keyValue: 4,
                columns: new[] { "IdVehicle", "Name" },
                values: new object[] { 4, "Tanker" });

            migrationBuilder.UpdateData(
                table: "WaterVehicle",
                keyColumn: "IdSubtype",
                keyValue: 3,
                columns: new[] { "MinCrew", "PurposeSpecifics_MaxPassengers", "PurposeSpecifics_MinLifeBoats", "PurposeSpecifics_PurposeType", "FuelSpecifics_FuelType", "FuelSpecifics_FuelTypeDescription" },
                values: new object[] { 12, 100, 5, 1, 2, "Sail" });

            migrationBuilder.UpdateData(
                table: "WaterVehicle",
                keyColumn: "IdSubtype",
                keyValue: 4,
                columns: new[] { "MinCrew", "PurposeSpecifics_LoadType", "PurposeSpecifics_ShipCapacity", "FuelSpecifics_CombustionType", "FuelSpecifics_FuelType", "FuelSpecifics_TankCapacity" },
                values: new object[] { 35, 0, 123, 0, 0, 2000 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FuelSpecifics_BatteryType",
                table: "WaterVehicle");

            migrationBuilder.DropColumn(
                name: "FuelSpecifics_CombustionType",
                table: "WaterVehicle");

            migrationBuilder.DropColumn(
                name: "PurposeSpecifics_PurposeType",
                table: "WaterVehicle");

            migrationBuilder.DropColumn(
                name: "FuelSpecifics_BatteryType",
                table: "LandVehicle");

            migrationBuilder.DropColumn(
                name: "PoiseSpecifics_PoiseType",
                table: "LandVehicle");

            migrationBuilder.RenameColumn(
                name: "PurposeSpecifics_LoadType",
                table: "WaterVehicle",
                newName: "FuelSpecifics_CombustionType_CombustionTypes");

            migrationBuilder.RenameColumn(
                name: "FuelSpecifics_FuelType",
                table: "WaterVehicle",
                newName: "FuelSpecifics_BatteryType_BatteryTypes");

            migrationBuilder.RenameColumn(
                name: "FuelSpecifics_FuelType",
                table: "LandVehicle",
                newName: "FuelSpecifics_CombustionType_CombustionTypes");

            migrationBuilder.RenameColumn(
                name: "FuelSpecifics_CombustionType",
                table: "LandVehicle",
                newName: "FuelSpecifics_BatteryType_BatteryTypes");

            migrationBuilder.CreateTable(
                name: "LandVehicle_FuelTypes",
                columns: table => new
                {
                    FuelSpecificsLandVehicleIdSubtype = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FuelTypes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandVehicle_FuelTypes", x => new { x.FuelSpecificsLandVehicleIdSubtype, x.Id });
                    table.ForeignKey(
                        name: "FK_LandVehicle_FuelTypes_LandVehicle_FuelSpecificsLandVehicleIdSubtype",
                        column: x => x.FuelSpecificsLandVehicleIdSubtype,
                        principalTable: "LandVehicle",
                        principalColumn: "IdSubtype",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoadType",
                columns: table => new
                {
                    PurposeSpecificsWaterVehicleIdSubtype = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoadTypes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoadType", x => new { x.PurposeSpecificsWaterVehicleIdSubtype, x.Id });
                    table.ForeignKey(
                        name: "FK_LoadType_WaterVehicle_PurposeSpecificsWaterVehicleIdSubtype",
                        column: x => x.PurposeSpecificsWaterVehicleIdSubtype,
                        principalTable: "WaterVehicle",
                        principalColumn: "IdSubtype",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PoiseType",
                columns: table => new
                {
                    PoiseSpecificsLandVehicleIdSubtype = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoiseTypes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoiseType", x => new { x.PoiseSpecificsLandVehicleIdSubtype, x.Id });
                    table.ForeignKey(
                        name: "FK_PoiseType_LandVehicle_PoiseSpecificsLandVehicleIdSubtype",
                        column: x => x.PoiseSpecificsLandVehicleIdSubtype,
                        principalTable: "LandVehicle",
                        principalColumn: "IdSubtype",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurposeType",
                columns: table => new
                {
                    PurposeSpecificsWaterVehicleIdSubtype = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurposeTypes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurposeType", x => new { x.PurposeSpecificsWaterVehicleIdSubtype, x.Id });
                    table.ForeignKey(
                        name: "FK_PurposeType_WaterVehicle_PurposeSpecificsWaterVehicleIdSubtype",
                        column: x => x.PurposeSpecificsWaterVehicleIdSubtype,
                        principalTable: "WaterVehicle",
                        principalColumn: "IdSubtype",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WaterVehicle_FuelTypes",
                columns: table => new
                {
                    FuelSpecificsWaterVehicleIdSubtype = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FuelTypes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterVehicle_FuelTypes", x => new { x.FuelSpecificsWaterVehicleIdSubtype, x.Id });
                    table.ForeignKey(
                        name: "FK_WaterVehicle_FuelTypes_WaterVehicle_FuelSpecificsWaterVehicleIdSubtype",
                        column: x => x.FuelSpecificsWaterVehicleIdSubtype,
                        principalTable: "WaterVehicle",
                        principalColumn: "IdSubtype",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "LandVehicle",
                keyColumn: "IdSubtype",
                keyValue: 1,
                columns: new[] { "PoiseSpecifics_WheelAmount", "PoiseSpecifics_WheelWidth" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "LandVehicle",
                keyColumn: "IdSubtype",
                keyValue: 2,
                columns: new[] { "PoiseSpecifics_TrackLength", "PoiseSpecifics_TrackWidth" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "WaterVehicle",
                keyColumn: "IdSubtype",
                keyValue: 3,
                columns: new[] { "PurposeSpecifics_MaxPassengers", "PurposeSpecifics_MinLifeBoats" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "WaterVehicle",
                keyColumn: "IdSubtype",
                keyValue: 4,
                column: "PurposeSpecifics_ShipCapacity",
                value: null);
        }
    }
}
