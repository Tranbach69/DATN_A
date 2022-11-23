using DATN.Infastructure.Repositories.AccountAdminRepository;
using DATN.Infastructure.Repositories.BaseRepository;
using DATN.Infastructure.Repositories.DeviceRepository;
using DATN.Infastructure.Repositories.EthernetRepository;
using DATN.Infastructure.Repositories.GpsRepository;
using DATN.Infastructure.Repositories.Lte4gRepository;

using DATN.Infastructure.Repositories.UserRepository;
using DATN.Infastructure.Repositories.WifiRepository;
using Microsoft.Extensions.DependencyInjection;

namespace DATN.Infastructure
{
	public static class DDependencies
	{
		public static void RegisterRepositories(this IServiceCollection services)
		{
			services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
			services.AddTransient<IDeviceRepository, DeviceRepository>();
			services.AddTransient<IEthernetRepository, EthernetRepository>();
			services.AddTransient<IWifiRepository, WifiRepository>();
			services.AddTransient<ILte4gRepository, Lte4gRepository>();
			services.AddTransient<IGpsRepository, GpsRepository>();
			services.AddTransient<IUserRepository, UserRepository>();
			services.AddTransient<IAccountAdminRepository, AccountAdminRepository>();
			//services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
		}
	}
}
