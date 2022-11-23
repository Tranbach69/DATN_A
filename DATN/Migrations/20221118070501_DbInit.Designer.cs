﻿// <auto-generated />
using System;
using DATN.Infastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DATN.Api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221118070501_DbInit")]
    partial class DbInit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DATN.Core.Entities.AccountAdmin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimingCreate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TimingDelete")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TimingUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AccountAdmin");
                });

            modelBuilder.Entity("DATN.Core.Entities.Device", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EquipmentShop")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EthernetId")
                        .HasColumnType("int");

                    b.Property<int>("GpsId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Lte4gId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<string>("ProductCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TimingCreate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TimingDelete")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TimingUpdate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("WarrantyPeriod")
                        .HasColumnType("datetime2");

                    b.Property<int>("WifiId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Device");
                });

            modelBuilder.Entity("DATN.Core.Entities.Ethernet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DriverType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EthernetIp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EthernetOfDeviceId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LanCtrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LanMode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimingCreate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TimingDelete")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TimingUpdate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EthernetOfDeviceId")
                        .IsUnique();

                    b.ToTable("Ethernet");
                });

            modelBuilder.Entity("DATN.Core.Entities.Gps", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DoubleAltitude")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DoubleLatitude")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DoubleLongitude")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FloatAccuracy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FloatSpeed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GpsOfDeviceId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Time")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimingCreate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TimingDelete")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TimingUpdate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("GpsOfDeviceId")
                        .IsUnique();

                    b.ToTable("Gps");
                });

            modelBuilder.Entity("DATN.Core.Entities.Lte4g", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Current4gData")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FregBand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LocationArea")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Lte4gOfDeviceId")
                        .HasColumnType("int");

                    b.Property<string>("MobileCountryMode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNetworkMode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NetworkMode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NetworkProvider")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OperationMode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rssi4g")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServiceCellId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SimCardPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SimCardState")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SimCardStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SimCardType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SystemMode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimingCreate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TimingDelete")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TimingUpdate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Lte4gOfDeviceId")
                        .IsUnique();

                    b.ToTable("Lte4g");
                });

            modelBuilder.Entity("DATN.Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimingCreate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TimingDelete")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TimingUpdate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("DATN.Core.Entities.Wifi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AuthType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BroadCast")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Channel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ChannelMode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ClientCount")
                        .HasColumnType("int");

                    b.Property<string>("CurrentAp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DhcpEndIp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DhcpHostIp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DhcpStartIp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DhcpTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EncryptMode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Iso")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MacAdd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MacCount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NatType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pwd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ssid")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimingCreate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TimingDelete")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TimingUpdate")
                        .HasColumnType("datetime2");

                    b.Property<int>("WifiOfDeviceId")
                        .HasColumnType("int");

                    b.Property<string>("WpsEnable")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("WifiOfDeviceId")
                        .IsUnique();

                    b.ToTable("Wifi");
                });

            modelBuilder.Entity("DATN.Core.Entities.Device", b =>
                {
                    b.HasOne("DATN.Core.Entities.User", "User")
                        .WithMany("Devices")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DATN.Core.Entities.Ethernet", b =>
                {
                    b.HasOne("DATN.Core.Entities.Device", "Device")
                        .WithOne("Ethernet")
                        .HasForeignKey("DATN.Core.Entities.Ethernet", "EthernetOfDeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Device");
                });

            modelBuilder.Entity("DATN.Core.Entities.Gps", b =>
                {
                    b.HasOne("DATN.Core.Entities.Device", "Device")
                        .WithOne("Gps")
                        .HasForeignKey("DATN.Core.Entities.Gps", "GpsOfDeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Device");
                });

            modelBuilder.Entity("DATN.Core.Entities.Lte4g", b =>
                {
                    b.HasOne("DATN.Core.Entities.Device", "Device")
                        .WithOne("Lte4g")
                        .HasForeignKey("DATN.Core.Entities.Lte4g", "Lte4gOfDeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Device");
                });

            modelBuilder.Entity("DATN.Core.Entities.Wifi", b =>
                {
                    b.HasOne("DATN.Core.Entities.Device", "Device")
                        .WithOne("Wifi")
                        .HasForeignKey("DATN.Core.Entities.Wifi", "WifiOfDeviceId")
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

            modelBuilder.Entity("DATN.Core.Entities.User", b =>
                {
                    b.Navigation("Devices");
                });
#pragma warning restore 612, 618
        }
    }
}
