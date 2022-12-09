using DATN.Core.Entities;
using Microsoft.EntityFrameworkCore;
namespace DATN.Infastructure.Persistence.Configurations
{
	public static class WifiConfig
	{
        public static void WifiConfigTable(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Wifi>(e => {
                e.ToTable("Wifi");
                e.HasKey(e => e.Imei);
                e.HasOne<Device>(s => s.Device)
                    .WithOne(ss => ss.Wifi)
                    .HasForeignKey<Wifi>(s => s.Imei);


                ;
			})
				
            ;

        }
    }
}
