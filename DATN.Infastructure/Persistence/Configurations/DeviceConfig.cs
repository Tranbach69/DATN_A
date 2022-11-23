using DATN.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Infastructure.Persistence.Configurations
{
    public static class DeviceConfig
    {
        public static void DeviceConfigTable(this ModelBuilder modelBuilder)
        {
			modelBuilder.Entity<Device>(e =>
			{
				e.ToTable("Device");
				e.HasKey(e => e.Id);
		});
        }
    }
}
