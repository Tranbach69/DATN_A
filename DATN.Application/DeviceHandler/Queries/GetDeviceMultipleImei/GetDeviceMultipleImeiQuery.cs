using DATN.Application.Mapper;
using DATN.Application.Models;
using DATN.Infastructure.Repositories.DeviceRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.DeviceHandler.Queries.GetDeviceByMultipleImei
{
    public class GetDeviceMultipleImeiQuery : IRequest<BResult<BPaging<GetDeviceMultipleImeiResponse>>>
    {
        public string Imei { get; set; }

        public GetDeviceMultipleImeiQuery(string imei)
        {
            Imei = imei;
        }
    }
    public class GetDeviceMultipleImeiResponse
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

    public class GetDeviceMultipleImeiQueryHandler : IRequestHandler<GetDeviceMultipleImeiQuery, BResult<BPaging<GetDeviceMultipleImeiResponse>>>
    {
        private readonly IDeviceRepository _deviceRepository;

        public GetDeviceMultipleImeiQueryHandler(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public async Task<BResult<BPaging<GetDeviceMultipleImeiResponse>>> Handle(GetDeviceMultipleImeiQuery request, CancellationToken cancellationToken)
        {
            var entity = await _deviceRepository.BGetMultipleImeiAsync(request.Imei);
            var items = DeviceMapper.Mapper.Map<List<GetDeviceMultipleImeiResponse>>(entity);
            var total = await _deviceRepository.BGetTotalImeiAsync(request.Imei);
            var result = new BPaging<GetDeviceMultipleImeiResponse>()
            {
                Items = items,
                TotalItems = total,
            };
            return BResult<BPaging<GetDeviceMultipleImeiResponse>>.Success(result);

        }
    }
}
