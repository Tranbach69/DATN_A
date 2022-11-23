using DATN.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Infastructure.Persistence.Configurations
{
	public static class EthernetConfig
    {
        public static void EthernetConfigTable(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ethernet>(e => {
                e.ToTable("Ethernet");
                e.HasOne<Device>(sc => sc.Device)
                    .WithOne(s => s.Ethernet)
                    .HasForeignKey<Ethernet>(s => s.EthernetOfDeviceId);
            });

        }
    }
}
