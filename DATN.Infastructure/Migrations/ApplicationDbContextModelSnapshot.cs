﻿// <auto-generated />
using System;
using DATN.Infastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DATN.Infastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("DATN.Core.Entities.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Imei")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<DateTime>("TimingCreate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("TimingDelete")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("TimingUpdate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("DATN.Core.Entities.Device", b =>
                {
                    b.Property<string>("Imei")
                        .HasColumnType("text");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<string>("DeviceName")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("EquipmentShop")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("OwnerName")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<string>("PurchaseDate")
                        .HasColumnType("text");

                    b.Property<DateTime>("TimingCreate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("TimingDelete")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("TimingUpdate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("WarrantyPeriod")
                        .HasColumnType("text");

                    b.HasKey("Imei");

                    b.ToTable("Device");
                });

            modelBuilder.Entity("DATN.Core.Entities.Ethernet", b =>
                {
                    b.Property<string>("Imei")
                        .HasColumnType("text");

                    b.Property<int>("BringUpdownEn")
                        .HasColumnType("integer");

                    b.Property<int>("DriverEn")
                        .HasColumnType("integer");

                    b.Property<int>("DriverType")
                        .HasColumnType("integer");

                    b.Property<string>("IpAddr")
                        .HasColumnType("text");

                    b.Property<int>("IpStaticEn")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Netmask")
                        .HasColumnType("text");

                    b.Property<DateTime>("TimingCreate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("TimingDelete")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("TimingUpdate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Imei");

                    b.ToTable("Ethernet");
                });

            modelBuilder.Entity("DATN.Core.Entities.Gps", b =>
                {
                    b.Property<string>("Imei")
                        .HasColumnType("text");

                    b.Property<float>("Accuracy")
                        .HasColumnType("real");

                    b.Property<double>("Altitude")
                        .HasColumnType("double precision");

                    b.Property<float>("Bearing")
                        .HasColumnType("real");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<double>("Latitude")
                        .HasColumnType("double precision");

                    b.Property<double>("Longitude")
                        .HasColumnType("double precision");

                    b.Property<float>("Speed")
                        .HasColumnType("real");

                    b.Property<string>("Time")
                        .HasColumnType("text");

                    b.Property<DateTime>("TimingCreate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("TimingDelete")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("TimingUpdate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Imei");

                    b.ToTable("Gps");
                });

            modelBuilder.Entity("DATN.Core.Entities.Lte4g", b =>
                {
                    b.Property<string>("Imei")
                        .HasColumnType("text");

                    b.Property<string>("Afrcn")
                        .HasColumnType("text");

                    b.Property<int>("AppState")
                        .HasColumnType("integer");

                    b.Property<int>("AppType")
                        .HasColumnType("integer");

                    b.Property<int>("CardStatus")
                        .HasColumnType("integer");

                    b.Property<string>("Current4GData")
                        .HasColumnType("text");

                    b.Property<string>("FreqBand")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("LocationAreaCode")
                        .HasColumnType("text");

                    b.Property<string>("MobileCountryCode")
                        .HasColumnType("text");

                    b.Property<string>("MobileNetworkCode")
                        .HasColumnType("text");

                    b.Property<int>("NetworkMode")
                        .HasColumnType("integer");

                    b.Property<string>("OperationMode")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<int>("Pin")
                        .HasColumnType("integer");

                    b.Property<int>("Rssi4G")
                        .HasColumnType("integer");

                    b.Property<string>("ServiceCellId")
                        .HasColumnType("text");

                    b.Property<string>("SimIccid")
                        .HasColumnType("text");

                    b.Property<string>("SimImsi")
                        .HasColumnType("text");

                    b.Property<string>("SystemMode")
                        .HasColumnType("text");

                    b.Property<DateTime>("TimingCreate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("TimingDelete")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("TimingUpdate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Imei");

                    b.ToTable("Lte4g");
                });

            modelBuilder.Entity("DATN.Core.Entities.Wifi", b =>
                {
                    b.Property<string>("Imei")
                        .HasColumnType("text");

                    b.Property<string>("AuthPwdWifi1")
                        .HasColumnType("text");

                    b.Property<string>("AuthPwdWifi2")
                        .HasColumnType("text");

                    b.Property<int>("AuthTypeWifi1")
                        .HasColumnType("integer");

                    b.Property<int>("AuthTypeWifi2")
                        .HasColumnType("integer");

                    b.Property<int>("BroadCastWifi1")
                        .HasColumnType("integer");

                    b.Property<int>("BroadCastWifi2")
                        .HasColumnType("integer");

                    b.Property<int>("ChannelModeWifi1")
                        .HasColumnType("integer");

                    b.Property<int>("ChannelModeWifi2")
                        .HasColumnType("integer");

                    b.Property<int>("ChannelWifi1")
                        .HasColumnType("integer");

                    b.Property<int>("ChannelWifi2")
                        .HasColumnType("integer");

                    b.Property<int>("ClientCountWifi1")
                        .HasColumnType("integer");

                    b.Property<int>("ClientCountWifi2")
                        .HasColumnType("integer");

                    b.Property<int>("CurrentAp")
                        .HasColumnType("integer");

                    b.Property<string>("DhcpEndIpWifi1")
                        .HasColumnType("text");

                    b.Property<string>("DhcpEndIpWifi2")
                        .HasColumnType("text");

                    b.Property<string>("DhcpHostIpWifi1")
                        .HasColumnType("text");

                    b.Property<string>("DhcpHostIpWifi2")
                        .HasColumnType("text");

                    b.Property<string>("DhcpStartIpWifi1")
                        .HasColumnType("text");

                    b.Property<string>("DhcpStartIpWifi2")
                        .HasColumnType("text");

                    b.Property<string>("DhcpTimeWifi1")
                        .HasColumnType("text");

                    b.Property<string>("DhcpTimeWifi2")
                        .HasColumnType("text");

                    b.Property<int>("EncryptModeWifi1")
                        .HasColumnType("integer");

                    b.Property<int>("EncryptModeWifi2")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int>("IsolationWifi1")
                        .HasColumnType("integer");

                    b.Property<int>("IsolationWifi2")
                        .HasColumnType("integer");

                    b.Property<string>("MacAddressWifi1")
                        .HasColumnType("text");

                    b.Property<string>("MacAddressWifi2")
                        .HasColumnType("text");

                    b.Property<string>("SsidWifi1")
                        .HasColumnType("text");

                    b.Property<string>("SsidWifi2")
                        .HasColumnType("text");

                    b.Property<string>("StaIp")
                        .HasColumnType("text");

                    b.Property<string>("StaPassword")
                        .HasColumnType("text");

                    b.Property<int>("StaProtocol")
                        .HasColumnType("integer");

                    b.Property<int>("StaSecurity")
                        .HasColumnType("integer");

                    b.Property<string>("StaSsidExt")
                        .HasColumnType("text");

                    b.Property<DateTime>("TimingCreate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("TimingDelete")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("TimingUpdate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("WifiMode")
                        .HasColumnType("integer");

                    b.Property<int>("WifiNat")
                        .HasColumnType("integer");

                    b.Property<int>("WifiOpen")
                        .HasColumnType("integer");

                    b.HasKey("Imei");

                    b.ToTable("Wifi");
                });

            modelBuilder.Entity("DATN.Core.Entities.Ethernet", b =>
                {
                    b.HasOne("DATN.Core.Entities.Device", "Device")
                        .WithOne("Ethernet")
                        .HasForeignKey("DATN.Core.Entities.Ethernet", "Imei")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Device");
                });

            modelBuilder.Entity("DATN.Core.Entities.Gps", b =>
                {
                    b.HasOne("DATN.Core.Entities.Device", "Device")
                        .WithOne("Gps")
                        .HasForeignKey("DATN.Core.Entities.Gps", "Imei")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Device");
                });

            modelBuilder.Entity("DATN.Core.Entities.Lte4g", b =>
                {
                    b.HasOne("DATN.Core.Entities.Device", "Device")
                        .WithOne("Lte4g")
                        .HasForeignKey("DATN.Core.Entities.Lte4g", "Imei")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Device");
                });

            modelBuilder.Entity("DATN.Core.Entities.Wifi", b =>
                {
                    b.HasOne("DATN.Core.Entities.Device", "Device")
                        .WithOne("Wifi")
                        .HasForeignKey("DATN.Core.Entities.Wifi", "Imei")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Device");
                });

            modelBuilder.Entity("DATN.Core.Entities.Device", b =>
                {
                    b.Navigation("Ethernet");

                    b.Navigation("Gps");

                    b.Navigation("Lte4g");

                    b.Navigation("Wifi");
                });
#pragma warning restore 612, 618
        }
    }
}
