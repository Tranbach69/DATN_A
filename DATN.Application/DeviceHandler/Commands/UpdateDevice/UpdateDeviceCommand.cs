using DATN.Application.Mapper;
using DATN.Application.Models;
using DATN.Core.Entities;
using DATN.Infastructure.Repositories.DeviceRepository;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.DeviceHandler.Commands.UpdateDevice
{
    public class UpdateDeviceCommand : IRequest<BResult>
    {
        public string Imei { get; set; }
        public int SocketConnection { get; set; }

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
        public string UpTime { get; set; }
        public string ActiveTime { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime TimingCreate { get; set; }
        public DateTime TimingUpdate { get; set; }
        public DateTime TimingDelete { get; set; }
    }

    public class UpdateDeviceCommandHandler : IRequestHandler<UpdateDeviceCommand, BResult>
    {
        private readonly IDeviceRepository _deviceRepository;

        public UpdateDeviceCommandHandler(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public async Task<BResult> Handle(UpdateDeviceCommand request, CancellationToken cancellationToken)
        {
            var entity = DeviceMapper.Mapper.Map<Device>(request);
            var result = await _deviceRepository.BUpdateAsync(entity);
            if (result == null)
            {
				if (request.Imei == "")
				{
					return BResult.Failure("Imei phải có giá trị");
				}
				else return BResult.Failure("Imei không tồn tại");
				
            }
            return BResult.Success();
        }
    }
}
