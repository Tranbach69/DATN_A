using DATN.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Infastructure.Persistence.Configurations
{
	public static class WifiConfig
	{
        public static void WifiConfigTable(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Wifi>(e => {
                e.ToTable("Wifi");
                e.HasOne<Device>(sc => sc.Device)
                     .WithOne(s => s.Wifi)
                     .HasForeignKey<Wifi>(s => s.WifiOfDeviceId);


                e.Property(e => e.Ssid).HasMaxLength(50);})
                
                ;

        }
    }
}
