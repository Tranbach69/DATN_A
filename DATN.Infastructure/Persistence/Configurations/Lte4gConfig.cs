using DATN.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Infastructure.Persistence.Configurations
{
	public static class Lte4gConfig
	{
        public static void Lte4gConfigTable(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lte4g>(e => {
                e.ToTable("Lte4g");
                e.HasOne<Device>(sc => sc.Device)
                      .WithOne(s => s.Lte4g)
                      .HasForeignKey<Lte4g>(s => s.Lte4gOfDeviceId);


            });

        }
    }
}
