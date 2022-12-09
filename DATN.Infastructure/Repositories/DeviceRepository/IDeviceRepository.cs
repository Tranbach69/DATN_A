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
		//Task<Device> AddDeviceAsync(Device entity);
		//Task<Device> UpdateDeviceAsync(Device entity);
	}
}
