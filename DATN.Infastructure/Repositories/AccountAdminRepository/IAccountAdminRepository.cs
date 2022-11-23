using DATN.Core.Entities;
using DATN.Infastructure.Repositories.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Infastructure.Repositories.AccountAdminRepository
{
	public interface IAccountAdminRepository : IRepository<AccountAdmin>
	{
		public Task<AccountAdmin> CheckAuth(string userName, string password);
		public Task ChangePassword(int id, string oldPassword, string newPassword);
	}
}
