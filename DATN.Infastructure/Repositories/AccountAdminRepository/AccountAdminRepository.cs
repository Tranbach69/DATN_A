using DATN.Core.Entities;
using DATN.Infastructure.Persistence;
using DATN.Infastructure.Repositories.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Infastructure.Repositories.AccountAdminRepository
{
    public class AccountAdminRepository : Repository<AccountAdmin>, IAccountAdminRepository
    {
        public AccountAdminRepository(ApplicationDbContext context) : base(context)
        {

        }
        public async Task<AccountAdmin> CheckAuth(string userName, string password)
        {
            var accountAdmin = await BFistOrDefaultAsync(acc => acc.UserName.Equals(userName) && acc.Password.Equals(password));
            return accountAdmin;
        }
        public async Task ChangePassword(int id, string oldPassword, string newPassword)
        {
            var accountAdmin = await BFistOrDefaultAsync(acc => acc.Id == id && acc.Password == oldPassword);
            accountAdmin.Password = newPassword;
            await _context.SaveChangesAsync();
        }
    }
}
