using DATN.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Infastructure.Persistence.Configurations
{
    public static class AccountAdminConfig
    {
        public static void AccountAdminConfigTable(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountAdmin>(e => {
                e.ToTable("AccountAdmin");
            });

        }
    }
}
