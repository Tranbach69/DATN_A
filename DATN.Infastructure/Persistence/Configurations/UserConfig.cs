using DATN.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Infastructure.Persistence.Configurations
{
	public static class UserConfig
	{
        public static void UserConfigTable(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(e => {
                e.ToTable("User");
                
            });

		}
    }
}
