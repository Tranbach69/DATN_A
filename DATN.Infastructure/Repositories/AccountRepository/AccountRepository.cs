using DATN.Core.Entities;
using DATN.Infastructure.Persistence;
using DATN.Infastructure.Repositories.BaseRepository;
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
    }
}
