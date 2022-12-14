using DATN.Application.Mapper;
using DATN.Core.Entities;
using DATN.Infastructure.Repositories.DeviceRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.DeviceHandler.Queries.GetDevice
{
    public class GetDeviceQuery : IRequest<GetDeviceResponse>
    {
        public string Imei { get; set; }

        public GetDeviceQuery(string imei)
        {
            Imei = imei;
        }
    }
    public class GetDeviceResponse
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

    public class GetDeviceQueryHandler : IRequestHandler<GetDeviceQuery, GetDeviceResponse>
    {
        private readonly IDeviceRepository _deviceRepository;

        public GetDeviceQueryHandler(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public async Task<GetDeviceResponse> Handle(GetDeviceQuery request, CancellationToken cancellationToken)
        {
            var entity = await _deviceRepository.BGetByImeiAsync(request.Imei);
            var result = DeviceMapper.Mapper.Map<GetDeviceResponse>(entity);
            return result;

        }
    }
}
