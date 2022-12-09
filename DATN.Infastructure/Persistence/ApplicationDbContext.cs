using DATN.Core.Entities;
using DATN.Infastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Infastructure.Persistence
{
	public class ApplicationDbContext: DbContext
	{
		public ApplicationDbContext(DbContextOptions options) : base(options)
		{

		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.WifiConfigTable();
			modelBuilder.EthernetConfigTable();
			modelBuilder.Lte4gConfigTable();
			modelBuilder.GpsConfigTable();
			modelBuilder.DeviceConfigTable();
			modelBuilder.AccountConfigTable();

			//modelBuilder.SeedInitial();
		}

		public DbSet<Device> Devices  => Set<Device>();
		public DbSet<Wifi> Wifis => Set<Wifi>();
		public DbSet<Ethernet> Ethernets => Set<Ethernet>();
		public DbSet<Lte4g> Lte4gs => Set<Lte4g>();
		public DbSet<Gps> Gpss => Set<Gps>();
		public DbSet<Account> Accounts => Set<Account>();

		//public object Device { get; internal set; }
	}
}
