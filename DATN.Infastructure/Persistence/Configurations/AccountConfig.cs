using DATN.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Infastructure.Persistence.Configurations
{
    public static class AccountConfig
    {
        public static void AccountConfigTable(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(e => {
                e.ToTable("Account");
            });

        }
    }
}
