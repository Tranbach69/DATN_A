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

		
		
		public int UserId { get; set; }
		public string MacAddress { get; set; }
		public string Name { get; set; }
		public float Price { get; set; }
		public string ProductCode { get; set; }
		public string EquipmentShop { get; set; }
		public DateTime PurchaseDate { get; set; }
		public DateTime WarrantyPeriod { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
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
			await _deviceRepository.BAddAsync(entity);
			return BResult.Success();
		}
	}
}
