using DATN.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DATN.Infastructure.Persistence.Configurations
{
	public static class Lte4gConfig
	{
        public static void Lte4gConfigTable(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lte4g>(e => {
                e.ToTable("Lte4g");
                e.HasKey(e => e.Imei);
                e.HasOne<Device>(s => s.Device)
                    .WithOne(ss => ss.Lte4g)
                    .HasForeignKey<Lte4g>(s => s.Imei);

            });

        }
    }
}
