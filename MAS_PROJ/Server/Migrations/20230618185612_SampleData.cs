using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MAS_PROJ.Server.Migrations
{
    public partial class SampleData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FuelSpecifics_BatteryType_Id",
                table: "WaterVehicle");

            migrationBuilder.DropColumn(
                name: "FuelSpecifics_BatteryType_Id",
                table: "LandVehicle");

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "IdVehicle", "Manufacturer", "Model", "ProductionEnd", "ProductionStart", "VehicleNotes" },
                values: new object[,]
                {
                    { 1, "Toyota", "Corolla", new DateTime(2001, 1, 29, 0, 3, 0, 0, DateTimeKind.Unspecified), new DateTime(1997, 1, 2, 0, 3, 0, 0, DateTimeKind.Unspecified), "Pre lift" },
                    { 2, "PC", "M3", new DateTime(2016, 1, 9, 0, 12, 0, 0, DateTimeKind.Unspecified), new DateTime(2014, 1, 11, 0, 11, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, "BoatFirm", "Floater", new DateTime(2012, 1, 1, 0, 2, 0, 0, DateTimeKind.Unspecified), new DateTime(2004, 1, 2, 0, 3, 0, 0, DateTimeKind.Unspecified), null },
                    { 4, "TTT", "Transporter", new DateTime(2012, 1, 1, 0, 2, 0, 0, DateTimeKind.Unspecified), new DateTime(2004, 1, 2, 0, 3, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "VehicleTypes",
                columns: new[] { "IdSubtype", "IdVehicle", "Name", "SubtypeNotes" },
                values: new object[,]
                {
                    { 1, 1, "Basic", null },
                    { 2, 2, "Premium", null },
                    { 3, 3, "Unsinkable Type", null },
                    { 4, 4, "Tanker", null }
                });

            migrationBuilder.InsertData(
                table: "LandVehicle",
                columns: new[] { "IdSubtype", "EnginePower", "EngineTorque", "FuelSpecifics_BatteryCapacity", "FuelSpecifics_FuelTypeDescription", "FuelSpecifics_TankCapacity", "PoiseSpecifics_TrackLength", "PoiseSpecifics_TrackWidth", "PoiseSpecifics_WheelAmount", "PoiseSpecifics_WheelWidth" },
                values: new object[,]
                {
                    { 1, 86, 90, null, null, null, null, null, null, null },
                    { 2, 120, 150, null, null, null, null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "WaterVehicle",
                columns: new[] { "IdSubtype", "MinCrew", "PurposeSpecifics_MaxPassengers", "PurposeSpecifics_MinLifeBoats", "PurposeSpecifics_ShipCapacity", "FuelSpecifics_BatteryCapacity", "FuelSpecifics_FuelTypeDescription", "FuelSpecifics_TankCapacity" },
                values: new object[,]
                {
                    { 3, 12, null, null, null, null, null, null },
                    { 4, 35, null, null, null, null, null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LandVehicle",
                keyColumn: "IdSubtype",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LandVehicle",
                keyColumn: "IdSubtype",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "WaterVehicle",
                keyColumn: "IdSubtype",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "WaterVehicle",
                keyColumn: "IdSubtype",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "VehicleTypes",
                keyColumn: "IdSubtype",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VehicleTypes",
                keyColumn: "IdSubtype",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VehicleTypes",
                keyColumn: "IdSubtype",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "VehicleTypes",
                keyColumn: "IdSubtype",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "IdVehicle",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "IdVehicle",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "IdVehicle",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "IdVehicle",
                keyValue: 4);

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
