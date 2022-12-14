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
                e.HasKey(e => e.Imei);
                e.HasOne<Device>(s => s.Device)
                    .WithOne(ss => ss.Ethernet)
                    .HasForeignKey<Ethernet>(s => s.Imei);

            });

        }
    }
}
