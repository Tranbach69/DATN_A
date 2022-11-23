using DATN.Core.Entities;
using DATN.Infastructure.Repositories.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Infastructure.Repositories.DeviceRepository
{
	public interface IDeviceRepository : IRepository<Device>
	{

		Task<Device> CheckAuth(string userName, string password);
		Task ChangePassword(int id, string oldPassword, string newPassword);
		//Task<List<DeviceUserQuery>> GetAllDeviceWithUserInfo();
	}
}
