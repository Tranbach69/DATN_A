using DATN.Application.Mapper;
using DATN.Application.Models;
using DATN.Core.Entities;
using DATN.Infastructure.Repositories.DeviceRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.DeviceHandler.Commands.CreateDevice
{
	public class CreateDeviceCommand : IRequest<BResult>
	{
		public string Imei { get; set; }
		public string DeviceName { get; set; }
		public float Price { get; set; }
		public string EquipmentShop { get; set; }
		public string PurchaseDate { get; set; }
		public string WarrantyPeriod { get; set; }
		public string Phone { get; set; }
		public int Age { get; set; }
		public string OwnerName { get; set; }
		public string Address { get; set; }
		public string Email { get; set; }
		public bool IsDeleted { get; set; }
		public DateTime TimingCreate { get; set; }
		public DateTime TimingUpdate { get; set; }
		public DateTime TimingDelete { get; set; }
	}
	public class CreateDeviceCommandHandler : IRequestHandler<CreateDeviceCommand, BResult>
	{
		private readonly IDeviceRepository _deviceRepository;

		public CreateDeviceCommandHandler(IDeviceRepository deviceRepository)
		{
			_deviceRepository = deviceRepository;
		}

		public async Task<BResult> Handle(CreateDeviceCommand request, CancellationToken cancellationToken)
		{
			var entity = DeviceMapper.Mapper.Map<Device>(request);
			var result = await _deviceRepository.BAddAsync(entity);
			if (result == null)
			{
				if (request.Imei == "")
				{
					return BResult.Failure("Imei phải có giá trị");
				}
				else return BResult.Failure("không thể thêm vì Số imei này đã bị xóa, nếu vẫn muốn thêm số imei này vui lòng thao tác undo imei...");

			}
			return BResult.Success();
		}
	}
}
