using DATN.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DATN.Infastructure.Persistence.Configurations
{
	public static class GpsConfig
    {
        public static void GpsConfigTable(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gps>(e => {
                e.ToTable("Gps");
                e.HasKey(e => e.Imei);
                e.HasOne<Device>(s => s.Device)
                    .WithOne(ss => ss.Gps)
                    .HasForeignKey<Gps>(s => s.Imei);
            });

        }
    }
}
