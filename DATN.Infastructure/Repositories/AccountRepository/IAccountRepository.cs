using DATN.Core.Entities;
using DATN.Infastructure.Repositories.BaseRepository;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Infastructure.Repositories.AccountRepository
{
	public interface IAccountRepository : IRepository<Account>
	{
		public Task<Account> CheckAuth(string userName, string password);
		public Task ChangePassword(int id, string oldPassword, string newPassword);
		Task<IReadOnlyList<Account>> GetMultipleRoleAsync(int role, int skip, int pageSize);
		Task<int> GetTotalRoleAsync(int role);
		Task<Account> AddAccountAsync(Account entity);
		Task<Account> UpdateAccountAsync(Account entity);
		Task DeleteAccountByIdAsync(int id);
		Task UpdateAccountPatchAsync(int id, JsonPatchDocument TModel);
		Task<Account> GetAccountByIdAsync(int id);
	}
}
