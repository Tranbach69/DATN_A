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
        public int Id { get; set; }

        public GetDeviceQuery(int id)
        {
            Id = id;
        }
    }
    public class GetDeviceResponse
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

    public class GetDeviceQueryHandler : IRequestHandler<GetDeviceQuery, GetDeviceResponse>
    {
        private readonly IDeviceRepository _deviceRepository;

        public GetDeviceQueryHandler(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public async Task<GetDeviceResponse> Handle(GetDeviceQuery request, CancellationToken cancellationToken)
        {
            var entity = await _deviceRepository.BGetByIdAsync(request.Id);
            var result = DeviceMapper.Mapper.Map<GetDeviceResponse>(entity);
            return result;

        }
    }
}
