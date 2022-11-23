using DATN.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Infastructure.Persistence.Configurations
{
	public static class GpsConfig
    {
        public static void GpsConfigTable(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gps>(e => {
                e.ToTable("Gps");
                e.HasOne<Device>(sc => sc.Device)
                    .WithOne(s => s.Gps)
                    .HasForeignKey<Gps>(s => s.GpsOfDeviceId);

            });

        }
    }
}
