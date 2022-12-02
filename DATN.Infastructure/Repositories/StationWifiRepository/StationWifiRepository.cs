using DATN.Core.Entities;
using DATN.Infastructure.Persistence;
using DATN.Infastructure.Repositories.BaseRepository;


namespace DATN.Infastructure.Repositories.StationWifiRepository
{

	public class StationWifiRepository : Repository<StationWifi>, IStationWifiRepository
	{
		public StationWifiRepository(ApplicationDbContext context) : base(context)
		{

		}
	}
}
