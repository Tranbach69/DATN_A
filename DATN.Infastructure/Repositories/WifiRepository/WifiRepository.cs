using DATN.Core.Entities;
using DATN.Infastructure.Persistence;
using DATN.Infastructure.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Infastructure.Repositories.WifiRepository
{
	public class WifiRepository : Repository<Wifi>, IWifiRepository
	{
		public WifiRepository(ApplicationDbContext context) : base(context)
		{

		}
        public async Task<Wifi> AddWifiAsync(Wifi entity)
        {
            entity.TimingCreate = System.DateTime.Now;
            entity.IsDeleted = false;
            //var a = await _context.Set<Wifi>().FirstOrDefaultAsync(a => a.Imei.Equals(entity.Imei));

            //if (a != null)
            //{
            if (entity.Imei !="")
            {
			await _context.Set<Wifi>().AddAsync(entity);
			await _context.SaveChangesAsync();
                return entity;
            }
            else
            {
                return null;
            }       
        }
        public async Task<int> GetTotalWifiActiveAsync()
        {
            return await _context.Set<Wifi>().Where(a => a.IsDeleted == false).Where(a => a.WifiOpen == 1).CountAsync();
        }
    }
}

