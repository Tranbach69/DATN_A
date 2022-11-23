using DATN.Application.Mapper;
using DATN.Application.Models;
using DATN.Infastructure.Repositories.DeviceRepository;
using DATN.Infastructure.Repositories.UserRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.DeviceHandler.Queries.GetAllDeviceUser
{
	public class GetDevicesWithUserInfoQuery : IRequest<List<GetDevicesWithUserInfoResponse>>
	{

	}

	public class GetDevicesWithUserInfoResponse
	{
		//device
		public string DeviceName { get; set; }
		public string ProductCode { get; set; }
		public string MacAddress { get; set; }
		public float Price { get; set; }
		public string EquipmentShop { get; set; }
		public DateTime PurchaseDate { get; set; }
		public DateTime WarrantyPeriod { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		public int UserId { get; set; }
		public int WifiId { get; set; }
		public int EthernetId { get; set; }
		public int Lte4gId { get; set; }
		public int GpsId { get; set; }

		// user
		public string NameOfUser { get; set; }
		public int Age { get; set; }
		public string Address { get; set; }
		public string Phone { get; set; }
	}

	public class GetDevicesWithUserInfoQueryHandler : IRequestHandler<GetDevicesWithUserInfoQuery, List<GetDevicesWithUserInfoResponse>>
	{
		private readonly IDeviceRepository _deviceRepository;
		private readonly IUserRepository _userRepository;


		public GetDevicesWithUserInfoQueryHandler(IDeviceRepository deviceRepository, IUserRepository userRepository)
		{
			_deviceRepository = deviceRepository;
			_userRepository = userRepository;
		}

		public async Task<List<GetDevicesWithUserInfoResponse>> Handle(GetDevicesWithUserInfoQuery request, CancellationToken cancellationToken)
		{
			var devices = await _deviceRepository.BGetAllAsync();
			var users = await _userRepository.BGetAllAsync();
			var devicesWithUser = from user in users
								  join device in devices on user.Id equals device.UserId
								  select new GetDevicesWithUserInfoResponse
								  {
									  DeviceName = device.Name,
									  ProductCode = device.MacAddress,
									  Price = device.Price,
									  EquipmentShop = device.EquipmentShop,
									  PurchaseDate = device.PurchaseDate,
									  WarrantyPeriod = device.WarrantyPeriod,
									  UserName = device.UserName,
									  Password = device.Password,
									  UserId = device.UserId,
									  WifiId = device.WifiId,
									  EthernetId = device.EthernetId,
									  Lte4gId = device.Lte4gId,
									  GpsId = device.GpsId,

									  // user
									  NameOfUser = user.Name,
									  Age = user.Age,
									  Address = user.Address,
									  Phone = user.Phone
								  };
			return devicesWithUser.ToList();
			//var deviceUserList = await _deviceRepository.GetAllDeviceWithUserInfo();
			//return DeviceUserMapper.Mapper.Map<List<GetDevicesWithUserInfoResponse>>(deviceUserList);
		}
	}
}
