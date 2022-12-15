using DATN.Core.Entities;
using DATN.Infastructure.Repositories.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Infastructure.Repositories.WifiRepository
{
	public interface IWifiRepository: IRepository<Wifi>
	{
		Task<Wifi> AddWifiAsync(Wifi entity);
		Task<int> GetTotalWifiActiveAsync();
	}
	
}
