using DATN.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DATN.Infastructure.Persistence.Configurations
{
    public static class StationWifiConfig
    {
        public static void StationWifiConfigTable(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StationWifi>(e => {
                e.ToTable("StationWifi");

            });

        }
    }
}
