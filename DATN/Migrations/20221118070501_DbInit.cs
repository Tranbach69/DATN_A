using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DATN.Api.Migrations
{
    public partial class DbInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountAdmin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    TimingCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimingUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimingDelete = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountAdmin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    TimingCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimingUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimingDelete = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Device",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    EquipmentShop = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WarrantyPeriod = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    WifiId = table.Column<int>(type: "int", nullable: false),
                    EthernetId = table.Column<int>(type: "int", nullable: false),
                    Lte4gId = table.Column<int>(type: "int", nullable: false),
                    GpsId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    TimingCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimingUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimingDelete = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Device", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Device_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ethernet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LanCtrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LanMode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EthernetIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EthernetOfDeviceId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    TimingCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimingUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimingDelete = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ethernet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ethernet_Device_EthernetOfDeviceId",
                        column: x => x.EthernetOfDeviceId,
                        principalTable: "Device",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoubleLatitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoubleLongitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoubleAltitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FloatSpeed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FloatAccuracy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GpsOfDeviceId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    TimingCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimingUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimingDelete = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gps_Device_GpsOfDeviceId",
                        column: x => x.GpsOfDeviceId,
                        principalTable: "Device",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lte4g",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NetworkProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NetworkMode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemMode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OperationMode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileCountryMode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNetworkMode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationArea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceCellId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FregBand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Current4gData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SimCardStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SimCardType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SimCardState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SimCardPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rssi4g = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lte4gOfDeviceId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    TimingCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimingUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimingDelete = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lte4g", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lte4g_Device_Lte4gOfDeviceId",
                        column: x => x.Lte4gOfDeviceId,
                        principalTable: "Device",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wifi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ssid = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Pwd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BroadCast = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Iso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EncryptMode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Channel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChannelMode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DhcpHostIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DhcpStartIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DhcpEndIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DhcpTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MacAdd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MacCount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NatType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentAp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientCount = table.Column<int>(type: "int", nullable: false),
                    WpsEnable = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WifiOfDeviceId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    TimingCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimingUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimingDelete = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wifi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wifi_Device_WifiOfDeviceId",
                        column: x => x.WifiOfDeviceId,
                        principalTable: "Device",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Device_UserId",
                table: "Device",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ethernet_EthernetOfDeviceId",
                table: "Ethernet",
                column: "EthernetOfDeviceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Gps_GpsOfDeviceId",
                table: "Gps",
                column: "GpsOfDeviceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lte4g_Lte4gOfDeviceId",
                table: "Lte4g",
                column: "Lte4gOfDeviceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wifi_WifiOfDeviceId",
                table: "Wifi",
                column: "WifiOfDeviceId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountAdmin");

            migrationBuilder.DropTable(
                name: "Ethernet");

            migrationBuilder.DropTable(
                name: "Gps");

            migrationBuilder.DropTable(
                name: "Lte4g");

            migrationBuilder.DropTable(
                name: "Wifi");

            migrationBuilder.DropTable(
                name: "Device");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
