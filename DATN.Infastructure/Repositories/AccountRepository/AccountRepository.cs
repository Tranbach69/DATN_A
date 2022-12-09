using DATN.Core.Entities;
using DATN.Infastructure.Persistence;
using DATN.Infastructure.Repositories.BaseRepository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Infastructure.Repositories.AccountRepository
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(ApplicationDbContext context) : base(context)
        {

        }
        public async Task<Account> CheckAuth(string userName, string password)
        {
            var account = await BFistOrDefaultAsync(acc => acc.UserName.Equals(userName) && acc.Password.Equals(password));
            return account;
        }
        public async Task ChangePassword(int id, string oldPassword, string newPassword)
        {
            var account = await BFistOrDefaultAsync(acc => acc.Id == id && acc.Password == oldPassword);
            account.Password = newPassword;
            await _context.SaveChangesAsync();
        }
        public async Task<IReadOnlyList<Account>> GetMultipleRoleAsync(int role, int skip, int pageSize)
        {
            return await _context.Set<Account>().Where(a => a.IsDeleted == false).Where(a => a.Role == role).Skip(skip).Take(pageSize).ToListAsync();
        }
        public async Task<int> GetTotalRoleAsync(int role)
        {
            return await _context.Set<Account>().Where(a => a.IsDeleted == false).Where(a => a.Role == role).CountAsync();
        }

        public async Task<Account> AddAccountAsync(Account entity)
        {
            entity.TimingCreate = System.DateTime.Now;
            entity.IsDeleted = false;
			var a = await _context.Set<Account>().FirstOrDefaultAsync(a => a.Imei.Equals(entity.Imei));

            if (a != null) {
                if (entity.Role < 2 && entity.Imei=="")
                {
                    await _context.Set<Account>().AddAsync(entity);
                    await _context.SaveChangesAsync();
                    return entity;
                }
                else {
                    return null;
                }
            }

            await _context.Set<Account>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<Account> UpdateAccountAsync(Account entity)
        {
            entity.TimingUpdate = System.DateTime.Now;
            entity.IsDeleted = false;
            if (entity.Imei == "") return null;
            _context.Entry(entity).State = EntityState.Modified;
            var a = await _context.Set<Account>().FirstOrDefaultAsync(a => a.Imei.Equals(entity.Imei));
			if (a != null)
			{
				if (entity.Imei == a.Imei && entity.Id == a.Id)
				{
					await _context.SaveChangesAsync();
					return entity;
				}
				else
				{
					return null;
				}
			}
			await _context.SaveChangesAsync();
            return entity;
        }
        public async Task DeleteAccountByIdAsync(int id)
        {
            var entity = await _context.Set<Account>().FindAsync(id);
            entity.IsDeleted = true;
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAccountPatchAsync(int id, JsonPatchDocument TModel)
        {
            var entity = await _context.Set<Account>().FindAsync(id);

            entity.IsDeleted = false;
            if (entity != null)
            {
                TModel.ApplyTo(entity);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<Account> GetAccountByIdAsync(int id)
        {
            var entity = await _context.Set<Account>().FirstOrDefaultAsync(t => t.Id.Equals(id));
            _context.Entry(entity).State = EntityState.Detached;
            if (entity?.IsDeleted == true)
            {
                return null;
            }
            return entity;
        }
    }

}

