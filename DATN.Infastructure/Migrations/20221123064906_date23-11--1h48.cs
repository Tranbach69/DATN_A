using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DATN.Infastructure.Migrations
{
    public partial class date23111h48 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountAdmin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    TimingCreate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TimingUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TimingDelete = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountAdmin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MacAddress = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    TimingCreate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TimingUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TimingDelete = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Device",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    MacAddress = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    EquipmentShop = table.Column<string>(type: "text", nullable: true),
                    PurchaseDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    WarrantyPeriod = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    WifiId = table.Column<int>(type: "integer", nullable: false),
                    EthernetId = table.Column<int>(type: "integer", nullable: false),
                    Lte4gId = table.Column<int>(type: "integer", nullable: false),
                    GpsId = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    TimingCreate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TimingUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TimingDelete = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MacAddress = table.Column<string>(type: "text", nullable: true),
                    DriverType = table.Column<string>(type: "text", nullable: true),
                    LanCtrl = table.Column<string>(type: "text", nullable: true),
                    LanMode = table.Column<string>(type: "text", nullable: true),
                    EthernetIp = table.Column<string>(type: "text", nullable: true),
                    EthernetOfDeviceId = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    TimingCreate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TimingUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TimingDelete = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MacAddress = table.Column<string>(type: "text", nullable: true),
                    DoubleLatitude = table.Column<string>(type: "text", nullable: true),
                    DoubleLongitude = table.Column<string>(type: "text", nullable: true),
                    DoubleAltitude = table.Column<string>(type: "text", nullable: true),
                    FloatSpeed = table.Column<string>(type: "text", nullable: true),
                    FloatAccuracy = table.Column<string>(type: "text", nullable: true),
                    Time = table.Column<string>(type: "text", nullable: true),
                    GpsOfDeviceId = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    TimingCreate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TimingUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TimingDelete = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MacAddress = table.Column<string>(type: "text", nullable: true),
                    NetworkProvider = table.Column<string>(type: "text", nullable: true),
                    NetworkMode = table.Column<string>(type: "text", nullable: true),
                    SystemMode = table.Column<string>(type: "text", nullable: true),
                    OperationMode = table.Column<string>(type: "text", nullable: true),
                    MobileCountryMode = table.Column<string>(type: "text", nullable: true),
                    MobileNetworkMode = table.Column<string>(type: "text", nullable: true),
                    LocationArea = table.Column<string>(type: "text", nullable: true),
                    ServiceCellId = table.Column<string>(type: "text", nullable: true),
                    FregBand = table.Column<string>(type: "text", nullable: true),
                    Current4gData = table.Column<string>(type: "text", nullable: true),
                    SimCardStatus = table.Column<string>(type: "text", nullable: true),
                    SimCardType = table.Column<string>(type: "text", nullable: true),
                    SimCardState = table.Column<string>(type: "text", nullable: true),
                    SimCardPhone = table.Column<string>(type: "text", nullable: true),
                    Rssi4g = table.Column<string>(type: "text", nullable: true),
                    Lte4gOfDeviceId = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    TimingCreate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TimingUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TimingDelete = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MacAddress = table.Column<string>(type: "text", nullable: true),
                    Ssid = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Pwd = table.Column<string>(type: "text", nullable: true),
                    BroadCast = table.Column<string>(type: "text", nullable: true),
                    Iso = table.Column<string>(type: "text", nullable: true),
                    AuthType = table.Column<string>(type: "text", nullable: true),
                    EncryptMode = table.Column<string>(type: "text", nullable: true),
                    Channel = table.Column<string>(type: "text", nullable: true),
                    ChannelMode = table.Column<string>(type: "text", nullable: true),
                    Mode = table.Column<string>(type: "text", nullable: true),
                    DhcpHostIp = table.Column<string>(type: "text", nullable: true),
                    DhcpStartIp = table.Column<string>(type: "text", nullable: true),
                    DhcpEndIp = table.Column<string>(type: "text", nullable: true),
                    DhcpTime = table.Column<string>(type: "text", nullable: true),
                    MacAdd = table.Column<string>(type: "text", nullable: true),
                    MacCount = table.Column<string>(type: "text", nullable: true),
                    NatType = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    CurrentAp = table.Column<string>(type: "text", nullable: true),
                    ClientCount = table.Column<int>(type: "integer", nullable: false),
                    WpsEnable = table.Column<string>(type: "text", nullable: true),
                    WifiOfDeviceId = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    TimingCreate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TimingUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TimingDelete = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
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
