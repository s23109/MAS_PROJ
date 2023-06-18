using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MAS_PROJ.Server.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Part",
                columns: table => new
                {
                    IdPart = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PartType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PartCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdPartParent = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Part", x => x.IdPart);
                    table.ForeignKey(
                        name: "FK_Part_Part_IdPartParent",
                        column: x => x.IdPartParent,
                        principalTable: "Part",
                        principalColumn: "IdPart");
                });

            migrationBuilder.CreateTable(
                name: "SystemUser",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegonNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientData_RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ClientData_ClientNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonalData_FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonalData_LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FireDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CurrentSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EmployeeNotes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemUser", x => x.IdUser);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    IdVehicle = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductionStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductionEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VehicleNotes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.IdVehicle);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    IdProduct = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<int>(type: "int", nullable: false),
                    PartIdPart = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.IdProduct);
                    table.ForeignKey(
                        name: "FK_Product_Part_PartIdPart",
                        column: x => x.PartIdPart,
                        principalTable: "Part",
                        principalColumn: "IdPart");
                });

            migrationBuilder.CreateTable(
                name: "Sale",
                columns: table => new
                {
                    IdSale = table.Column<int>(type: "int", nullable: false),
                    DateOfTransaction = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: true),
                    IdEmployee = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x.IdSale);
                    table.ForeignKey(
                        name: "FK_Sale_SystemUser_IdSale",
                        column: x => x.IdSale,
                        principalTable: "SystemUser",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sale_SystemUser_IdUser",
                        column: x => x.IdUser,
                        principalTable: "SystemUser",
                        principalColumn: "IdUser");
                });

            migrationBuilder.CreateTable(
                name: "VehiclePart",
                columns: table => new
                {
                    IdVehicle = table.Column<int>(type: "int", nullable: false),
                    IdPart = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiclePart", x => new { x.IdVehicle, x.IdPart });
                    table.ForeignKey(
                        name: "FK_VehiclePart_Part_IdPart",
                        column: x => x.IdPart,
                        principalTable: "Part",
                        principalColumn: "IdPart",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehiclePart_Vehicles_IdVehicle",
                        column: x => x.IdVehicle,
                        principalTable: "Vehicles",
                        principalColumn: "IdVehicle",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleTypes",
                columns: table => new
                {
                    IdSubtype = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubtypeNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdVehicle = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleTypes", x => x.IdSubtype);
                    table.ForeignKey(
                        name: "FK_VehicleTypes_Vehicles_IdVehicle",
                        column: x => x.IdVehicle,
                        principalTable: "Vehicles",
                        principalColumn: "IdVehicle",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductReference",
                columns: table => new
                {
                    IdProduct = table.Column<int>(type: "int", nullable: false),
                    IdPart = table.Column<int>(type: "int", nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IdSale = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductReference", x => new { x.IdPart, x.IdProduct });
                    table.ForeignKey(
                        name: "FK_ProductReference_Part_IdPart",
                        column: x => x.IdPart,
                        principalTable: "Part",
                        principalColumn: "IdPart");
                    table.ForeignKey(
                        name: "FK_ProductReference_Sale_IdSale",
                        column: x => x.IdSale,
                        principalTable: "Sale",
                        principalColumn: "IdSale");
                });

            migrationBuilder.CreateTable(
                name: "LandVehicle",
                columns: table => new
                {
                    IdSubtype = table.Column<int>(type: "int", nullable: false),
                    EnginePower = table.Column<int>(type: "int", nullable: true),
                    EngineTorque = table.Column<int>(type: "int", nullable: true),
                    PoiseSpecifics_WheelAmount = table.Column<int>(type: "int", nullable: true),
                    PoiseSpecifics_WheelWidth = table.Column<int>(type: "int", nullable: true),
                    PoiseSpecifics_TrackLength = table.Column<int>(type: "int", nullable: true),
                    PoiseSpecifics_TrackWidth = table.Column<int>(type: "int", nullable: true),
                    FuelSpecifics_TankCapacity = table.Column<int>(type: "int", nullable: true),
                    FuelSpecifics_CombustionType_Id = table.Column<int>(type: "int", nullable: true),
                    FuelSpecifics_CombustionType_CombustionTypes = table.Column<int>(type: "int", nullable: true),
                    FuelSpecifics_BatteryCapacity = table.Column<int>(type: "int", nullable: true),
                    FuelSpecifics_BatteryType_Id = table.Column<int>(type: "int", nullable: true),
                    FuelSpecifics_BatteryType_BatteryTypes = table.Column<int>(type: "int", nullable: true),
                    FuelSpecifics_FuelTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandVehicle", x => x.IdSubtype);
                    table.ForeignKey(
                        name: "FK_LandVehicle_VehicleTypes_IdSubtype",
                        column: x => x.IdSubtype,
                        principalTable: "VehicleTypes",
                        principalColumn: "IdSubtype");
                });

            migrationBuilder.CreateTable(
                name: "WaterVehicle",
                columns: table => new
                {
                    IdSubtype = table.Column<int>(type: "int", nullable: false),
                    MinCrew = table.Column<int>(type: "int", nullable: false),
                    PurposeSpecifics_ShipCapacity = table.Column<int>(type: "int", nullable: true),
                    PurposeSpecifics_MaxPassengers = table.Column<int>(type: "int", nullable: true),
                    PurposeSpecifics_MinLifeBoats = table.Column<int>(type: "int", nullable: true),
                    FuelSpecifics_TankCapacity = table.Column<int>(type: "int", nullable: true),
                    FuelSpecifics_CombustionType_Id = table.Column<int>(type: "int", nullable: true),
                    FuelSpecifics_CombustionType_CombustionTypes = table.Column<int>(type: "int", nullable: true),
                    FuelSpecifics_BatteryCapacity = table.Column<int>(type: "int", nullable: true),
                    FuelSpecifics_BatteryType_Id = table.Column<int>(type: "int", nullable: true),
                    FuelSpecifics_BatteryType_BatteryTypes = table.Column<int>(type: "int", nullable: true),
                    FuelSpecifics_FuelTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterVehicle", x => x.IdSubtype);
                    table.ForeignKey(
                        name: "FK_WaterVehicle_VehicleTypes_IdSubtype",
                        column: x => x.IdSubtype,
                        principalTable: "VehicleTypes",
                        principalColumn: "IdSubtype");
                });

            migrationBuilder.CreateTable(
                name: "LandVehicle_FuelTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FuelSpecificsLandVehicleIdSubtype = table.Column<int>(type: "int", nullable: false),
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
                name: "PoiseType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoiseSpecificsLandVehicleIdSubtype = table.Column<int>(type: "int", nullable: false),
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
                name: "LoadType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurposeSpecificsWaterVehicleIdSubtype = table.Column<int>(type: "int", nullable: false),
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
                name: "PurposeType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurposeSpecificsWaterVehicleIdSubtype = table.Column<int>(type: "int", nullable: false),
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FuelSpecificsWaterVehicleIdSubtype = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_Part_IdPartParent",
                table: "Part",
                column: "IdPartParent");

            migrationBuilder.CreateIndex(
                name: "IX_Product_PartIdPart",
                table: "Product",
                column: "PartIdPart");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReference_IdSale",
                table: "ProductReference",
                column: "IdSale");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_IdUser",
                table: "Sale",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePart_IdPart",
                table: "VehiclePart",
                column: "IdPart");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleTypes_IdVehicle",
                table: "VehicleTypes",
                column: "IdVehicle");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LandVehicle_FuelTypes");

            migrationBuilder.DropTable(
                name: "LoadType");

            migrationBuilder.DropTable(
                name: "PoiseType");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "ProductReference");

            migrationBuilder.DropTable(
                name: "PurposeType");

            migrationBuilder.DropTable(
                name: "VehiclePart");

            migrationBuilder.DropTable(
                name: "WaterVehicle_FuelTypes");

            migrationBuilder.DropTable(
                name: "LandVehicle");

            migrationBuilder.DropTable(
                name: "Sale");

            migrationBuilder.DropTable(
                name: "Part");

            migrationBuilder.DropTable(
                name: "WaterVehicle");

            migrationBuilder.DropTable(
                name: "SystemUser");

            migrationBuilder.DropTable(
                name: "VehicleTypes");

            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
