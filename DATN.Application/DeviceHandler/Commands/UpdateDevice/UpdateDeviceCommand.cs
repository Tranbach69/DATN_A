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

namespace DATN.Application.DeviceHandler.Commands.UpdateDevice
{
    public class UpdateDeviceCommand : IRequest<BResult>
    {
        public string Id { get; set; }
        public string Imei { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string EquipmentShop { get; set; }
        public string PurchaseDate { get; set; }
        public string WarrantyPeriod { get; set; }
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
            await _deviceRepository.BUpdateAsync(entity);
            return BResult.Success();
        }
    }
}
