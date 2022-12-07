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
                name: "AccountAdmin",
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
                    table.PrimaryKey("PK_AccountAdmin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Device",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
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
                    Imei = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    TimingCreate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TimingUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TimingDelete = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Device", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ethernet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DriverType = table.Column<string>(type: "text", nullable: true),
                    BringUpdownEn = table.Column<string>(type: "text", nullable: true),
                    IpStaticEn = table.Column<string>(type: "text", nullable: true),
                    IpAddr = table.Column<string>(type: "text", nullable: true),
                    DriverEn = table.Column<string>(type: "text", nullable: true),
                    Netmask = table.Column<string>(type: "text", nullable: true),
                    Imei = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    TimingCreate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TimingUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TimingDelete = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ethernet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Latitude = table.Column<string>(type: "text", nullable: true),
                    Longitude = table.Column<string>(type: "text", nullable: true),
                    Altitude = table.Column<string>(type: "text", nullable: true),
                    Speed = table.Column<string>(type: "text", nullable: true),
                    Bearing = table.Column<string>(type: "text", nullable: true),
                    Accuracy = table.Column<string>(type: "text", nullable: true),
                    Time = table.Column<string>(type: "text", nullable: true),
                    Imei = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    TimingCreate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TimingUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TimingDelete = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lte4g",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SimStatus = table.Column<string>(type: "text", nullable: true),
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
                    Rssi4G = table.Column<string>(type: "text", nullable: true),
                    Imei = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    TimingCreate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TimingUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TimingDelete = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lte4g", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StationWifi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StaIp = table.Column<string>(type: "text", nullable: true),
                    StaSsidExt = table.Column<string>(type: "text", nullable: true),
                    StaSecurity = table.Column<string>(type: "text", nullable: true),
                    StaProtocol = table.Column<string>(type: "text", nullable: true),
                    StaPassword = table.Column<int>(type: "integer", nullable: false),
                    Imei = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    TimingCreate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TimingUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TimingDelete = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StationWifi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Imei = table.Column<string>(type: "text", nullable: true),
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
                name: "Wifi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClientCount = table.Column<int>(type: "integer", nullable: false),
                    WifiOpen = table.Column<string>(type: "text", nullable: true),
                    WifiMode = table.Column<string>(type: "text", nullable: true),
                    CurrentAp = table.Column<string>(type: "text", nullable: true),
                    WifiNat = table.Column<string>(type: "text", nullable: true),
                    Ssid = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    AuthPwd = table.Column<string>(type: "text", nullable: true),
                    BroadCast = table.Column<string>(type: "text", nullable: true),
                    Isolation = table.Column<string>(type: "text", nullable: true),
                    MacAddress = table.Column<string>(type: "text", nullable: true),
                    AuthType = table.Column<string>(type: "text", nullable: true),
                    EncryptMode = table.Column<string>(type: "text", nullable: true),
                    Channel = table.Column<string>(type: "text", nullable: true),
                    ChannelMode = table.Column<string>(type: "text", nullable: true),
                    DhcpHostIp = table.Column<string>(type: "text", nullable: true),
                    DhcpStartIp = table.Column<string>(type: "text", nullable: true),
                    DhcpEndIp = table.Column<string>(type: "text", nullable: true),
                    DhcpTime = table.Column<string>(type: "text", nullable: true),
                    Imei = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    TimingCreate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TimingUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TimingDelete = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wifi", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountAdmin");

            migrationBuilder.DropTable(
                name: "Device");

            migrationBuilder.DropTable(
                name: "Ethernet");

            migrationBuilder.DropTable(
                name: "Gps");

            migrationBuilder.DropTable(
                name: "Lte4g");

            migrationBuilder.DropTable(
                name: "StationWifi");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Wifi");
        }
    }
}
