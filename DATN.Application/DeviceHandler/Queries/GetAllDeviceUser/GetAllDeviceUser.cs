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
	public class GetDevicesWithUserInfoQuery : IRequest<BResult<BPaging<GetDevicesWithUserInfoResponse>>>
	{
		public int Skip { get; set; }
		public int PageSize { get; set; }

	}

	public class GetDevicesWithUserInfoResponse
	{
		//device
		public string Imei { get; set; }
		public string DeviceName { get; set; }
		public float Price { get; set; }
		public string EquipmentShop { get; set; }
		public string PurchaseDate { get; set; }
		public string WarrantyPeriod { get; set; }

		// user
		public int Age { get; set; }
		public string Phone { get; set; }
		public string NameOfUser { get; set; }
		public string Address { get; set; }
		public string Email { get; set; }
	}

	public class GetDevicesWithUserInfoQueryHandler : IRequestHandler<GetDevicesWithUserInfoQuery, BResult<BPaging<GetDevicesWithUserInfoResponse>>>
	{
		private readonly IDeviceRepository _deviceRepository;
		private readonly IUserRepository _userRepository;


		public GetDevicesWithUserInfoQueryHandler(IDeviceRepository deviceRepository, IUserRepository userRepository)
		{
			_deviceRepository = deviceRepository;
			_userRepository = userRepository;
		}

		public async Task<BResult<BPaging<GetDevicesWithUserInfoResponse>>> Handle(GetDevicesWithUserInfoQuery request, CancellationToken cancellationToken)
		{
			var devices = await _deviceRepository.BGetAllAsync();
			var users = await _userRepository.BGetAllAsync();
			var devicesWithUser = from user in users
								  join device in devices on user.Imei equals device.Imei
								  select new GetDevicesWithUserInfoResponse
								  {
									  DeviceName = device.Name,
									  Imei = device.Imei,
									  Price = device.Price,
									  EquipmentShop = device.EquipmentShop,
									  PurchaseDate = device.PurchaseDate,
									  WarrantyPeriod = device.WarrantyPeriod,				

									  // user
									  NameOfUser = user.Name,
									  Age = user.Age,
									  Address = user.Address,
									  Phone = user.Phone,
									  Email= user.Email,
								  };
			var total = devicesWithUser.Count();
			var item =  devicesWithUser.Skip(request.Skip).Take(request.PageSize).ToList();

			var result = new BPaging<GetDevicesWithUserInfoResponse>()
			{
				Items = item,
				TotalItems = total,
			};
			return BResult<BPaging<GetDevicesWithUserInfoResponse>>.Success(result);
			//var deviceUserList = await _deviceRepository.GetAllDeviceWithUserInfo();
			//return DeviceUserMapper.Mapper.Map<List<GetDevicesWithUserInfoResponse>>(deviceUserList);
		}
	}
}
