using DATN.Core.Entities;
using DATN.Infastructure.Persistence;
using DATN.Infastructure.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DATN.Infastructure.Repositories.DeviceRepository
{
	//public class DeviceUserQuery
	//{
	//	//device
	//	public string DeviceName { get; set; }
	//	public string ProductCode { get; set; }
	//	public float Price { get; set; }
	//	public string EquipmentShop { get; set; }
	//	public DateTime PurchaseDate { get; set; }
	//	public DateTime WarrantyPeriod { get; set; }
	//	public string UserName { get; set; }
	//	public string Password { get; set; }
	//	public int UserId { get; set; }
	//	public int WifiId { get; set; }
	//	public int EthernetId { get; set; }
	//	public int Lte4gId { get; set; }
	//	public int GpsId { get; set; }
	//	// user
	//	public string NameOfUser { get; set; }
	//	public int Age { get; set; }
	//	public string Address { get; set; }
	//	public string Phone { get; set; }
	//}
	public class DeviceRepository : Repository<Device>, IDeviceRepository
	{
		//private readonly IUserRepository _userRepository;
		//public DeviceRepository(ApplicationDbContext context, IUserRepository userRepository) : base(context)
		//{
		//	_userRepository = userRepository;
		//}
		public DeviceRepository(ApplicationDbContext context) : base(context)
		{
		}

		public async Task<Device> AddDeviceAsync(Device entity)
		{
			entity.TimingCreate = System.DateTime.Now;
			entity.IsDeleted = false;
			if (entity.Imei == "") return null;
			var a = await _context.Set<Device>().FirstOrDefaultAsync(a => a.Imei.Equals(entity.Imei));
			if (a != null) return null;
			await _context.Set<Device>().AddAsync(entity);
			await _context.SaveChangesAsync();
			return entity;
		}

		public async Task<Device> UpdateDeviceAsync(Device entity)
		{
			entity.TimingUpdate = System.DateTime.Now;
			entity.IsDeleted = false;
			if (entity.Imei == "") return null;
			_context.Entry(entity).State = EntityState.Modified;
			var a = await _context.Set<Device>().FirstOrDefaultAsync(a => a.Imei.Equals(entity.Imei));
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

		//public async Task<Device> CheckAuth(string userName, string password)
		//{
		//	var device = await BFistOrDefaultAsync(acc => acc.UserName.Equals(userName) && acc.Password.Equals(password));
		//	return device;
		//}
		//public async Task ChangePassword(int id, string oldPassword, string newPassword)
		//{
		//	var device = await BFistOrDefaultAsync(acc => acc.Id == id && acc.Password == oldPassword);
		//	device.Password = newPassword;
		//	await BUpdateAsync(device);
		//}

		//public async Task<List<DeviceUserQuery>> GetAllDeviceWithUserInfo()
		//{
		//	var devices = await BGetAllAsync();
		//	var users = await _userRepository.BGetAllAsync();
		//	var devicesWithUser = from user in users
		//						  join device in devices on user.Id equals device.UserId
		//						  select new DeviceUserQuery
		//						  {
		//							  DeviceName = device.Name,
		//							  ProductCode = device.ProductCode,
		//							  Price = device.Price,
		//							  EquipmentShop = device.EquipmentShop,
		//							  PurchaseDate = device.PurchaseDate,
		//							  WarrantyPeriod = device.WarrantyPeriod,
		//							  UserName = device.UserName,
		//							  Password = device.Password,
		//							  UserId = device.UserId,
		//							  WifiId = device.WifiId,
		//							  EthernetId = device.EthernetId,
		//							  Lte4gId = device.Lte4gId,
		//							  GpsId = device.GpsId,

		//							  // user
		//							  NameOfUser = user.Name,
		//							  Age = user.Age,
		//							  Address = user.Address,
		//							  Phone = user.Phone
		//						  };
		//	return devicesWithUser.ToList();
		//}

		//public async Task<Device> GetAllDevice()
		//{
		//	var devices = await BGetAllAsync();
		//	return (Device)devices;
		//	//var users = await _userRepository.BGetAllAsync();
		//}


	}
}
