using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DATN.Infastructure.Migrations
{
    public partial class dbInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    Imei = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    TimingCreate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TimingUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TimingDelete = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Device",
                columns: table => new
                {
                    Imei = table.Column<string>(type: "text", nullable: false),
                    DeviceName = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    EquipmentShop = table.Column<string>(type: "text", nullable: true),
                    PurchaseDate = table.Column<string>(type: "text", nullable: true),
                    WarrantyPeriod = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    OwnerName = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    TimingCreate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TimingUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TimingDelete = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Device", x => x.Imei);
                });

            migrationBuilder.CreateTable(
                name: "Ethernet",
                columns: table => new
                {
                    Imei = table.Column<string>(type: "text", nullable: false),
                    DriverType = table.Column<int>(type: "integer", nullable: false),
                    DriverEn = table.Column<int>(type: "integer", nullable: false),
                    BringUpdownEn = table.Column<int>(type: "integer", nullable: false),
                    IpStaticEn = table.Column<int>(type: "integer", nullable: false),
                    IpAddr = table.Column<string>(type: "text", nullable: true),
                    Netmask = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    TimingCreate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TimingUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TimingDelete = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ethernet", x => x.Imei);
                    table.ForeignKey(
                        name: "FK_Ethernet_Device_Imei",
                        column: x => x.Imei,
                        principalTable: "Device",
                        principalColumn: "Imei",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gps",
                columns: table => new
                {
                    Imei = table.Column<string>(type: "text", nullable: false),
                    Latitude = table.Column<double>(type: "double precision", nullable: false),
                    Longitude = table.Column<double>(type: "double precision", nullable: false),
                    Altitude = table.Column<double>(type: "double precision", nullable: false),
                    Speed = table.Column<float>(type: "real", nullable: false),
                    Bearing = table.Column<float>(type: "real", nullable: false),
                    Accuracy = table.Column<float>(type: "real", nullable: false),
                    Time = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    TimingCreate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TimingUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TimingDelete = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gps", x => x.Imei);
                    table.ForeignKey(
                        name: "FK_Gps_Device_Imei",
                        column: x => x.Imei,
                        principalTable: "Device",
                        principalColumn: "Imei",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lte4g",
                columns: table => new
                {
                    Imei = table.Column<string>(type: "text", nullable: false),
                    CardStatus = table.Column<int>(type: "integer", nullable: false),
                    Apptype = table.Column<int>(type: "integer", nullable: false),
                    AppState = table.Column<int>(type: "integer", nullable: false),
                    Pin = table.Column<int>(type: "integer", nullable: false),
                    SimIccid = table.Column<string>(type: "text", nullable: true),
                    SimImsi = table.Column<string>(type: "text", nullable: true),
                    SystemMode = table.Column<string>(type: "text", nullable: true),
                    OperationMode = table.Column<string>(type: "text", nullable: true),
                    MobileCountryCode = table.Column<string>(type: "text", nullable: true),
                    MobileNetworkCode = table.Column<string>(type: "text", nullable: true),
                    LocationAreaCode = table.Column<string>(type: "text", nullable: true),
                    ServiceCellId = table.Column<string>(type: "text", nullable: true),
                    FreqBand = table.Column<string>(type: "text", nullable: true),
                    Current4GData = table.Column<string>(type: "text", nullable: true),
                    Afrcn = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    Rssi4G = table.Column<int>(type: "integer", nullable: false),
                    NetworkMode = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    TimingCreate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TimingUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TimingDelete = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lte4g", x => x.Imei);
                    table.ForeignKey(
                        name: "FK_Lte4g_Device_Imei",
                        column: x => x.Imei,
                        principalTable: "Device",
                        principalColumn: "Imei",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wifi",
                columns: table => new
                {
                    Imei = table.Column<string>(type: "text", nullable: false),
                    WifiOpen = table.Column<int>(type: "integer", nullable: false),
                    WifiMode = table.Column<int>(type: "integer", nullable: false),
                    CurrentAp = table.Column<int>(type: "integer", nullable: false),
                    WifiNat = table.Column<int>(type: "integer", nullable: false),
                    SsidWifi1 = table.Column<string>(type: "text", nullable: true),
                    AuthTypeWifi1 = table.Column<int>(type: "integer", nullable: false),
                    EncryptModeWifi1 = table.Column<int>(type: "integer", nullable: false),
                    AuthPwdWifi1 = table.Column<string>(type: "text", nullable: true),
                    ClientCountWifi1 = table.Column<int>(type: "integer", nullable: false),
                    BroadCastWifi1 = table.Column<int>(type: "integer", nullable: false),
                    IsolationWifi1 = table.Column<int>(type: "integer", nullable: false),
                    MacAddressWifi1 = table.Column<string>(type: "text", nullable: true),
                    ChannelModeWifi1 = table.Column<int>(type: "integer", nullable: false),
                    ChannelWifi1 = table.Column<int>(type: "integer", nullable: false),
                    DhcpHostIpWifi1 = table.Column<string>(type: "text", nullable: true),
                    DhcpStartIpWifi1 = table.Column<string>(type: "text", nullable: true),
                    DhcpEndIpWifi1 = table.Column<string>(type: "text", nullable: true),
                    DhcpTimeWifi1 = table.Column<string>(type: "text", nullable: true),
                    SsidWifi2 = table.Column<string>(type: "text", nullable: true),
                    AuthTypeWifi2 = table.Column<int>(type: "integer", nullable: false),
                    EncryptModeWifi2 = table.Column<int>(type: "integer", nullable: false),
                    AuthPwdWifi2 = table.Column<string>(type: "text", nullable: true),
                    ClientCountWifi2 = table.Column<int>(type: "integer", nullable: false),
                    BroadCastWifi2 = table.Column<int>(type: "integer", nullable: false),
                    IsolationWifi2 = table.Column<int>(type: "integer", nullable: false),
                    MacAddressWifi2 = table.Column<string>(type: "text", nullable: true),
                    ChannelModeWifi2 = table.Column<int>(type: "integer", nullable: false),
                    ChannelWifi2 = table.Column<int>(type: "integer", nullable: false),
                    DhcpHostIpWifi2 = table.Column<string>(type: "text", nullable: true),
                    DhcpStartIpWifi2 = table.Column<string>(type: "text", nullable: true),
                    DhcpEndIpWifi2 = table.Column<string>(type: "text", nullable: true),
                    DhcpTimeWifi2 = table.Column<string>(type: "text", nullable: true),
                    StaIp = table.Column<string>(type: "text", nullable: true),
                    StaSsidExt = table.Column<string>(type: "text", nullable: true),
                    StaSecurity = table.Column<int>(type: "integer", nullable: false),
                    StaProtocol = table.Column<int>(type: "integer", nullable: false),
                    StaPassword = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    TimingCreate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TimingUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TimingDelete = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wifi", x => x.Imei);
                    table.ForeignKey(
                        name: "FK_Wifi_Device_Imei",
                        column: x => x.Imei,
                        principalTable: "Device",
                        principalColumn: "Imei",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");

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
        }
    }
}
