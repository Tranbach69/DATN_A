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

namespace DATN.Application.DeviceHandler.Queries.GetDevicePaging
{
    public class GetDevicePagingQuery : IRequest<BResult<BPaging<GetDevicePagingResponse>>>
    {
        public int Skip { get; set; }
        public int PageSize { get; set; }
    }
    public class GetDevicePagingResponse
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
    public class GetDevicePagingQueryHandler : IRequestHandler<GetDevicePagingQuery, BResult<BPaging<GetDevicePagingResponse>>>
    {
        private readonly IDeviceRepository _deviceRepository;

        public GetDevicePagingQueryHandler(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }
        public async Task<BResult<BPaging<GetDevicePagingResponse>>> Handle(GetDevicePagingQuery request, CancellationToken cancellationToken)
        {
            var entities = await _deviceRepository.BGetPagingAsync(request.Skip, request.PageSize);
            var items = DeviceMapper.Mapper.Map<List<GetDevicePagingResponse>>(entities);
            var total = await _deviceRepository.BGetTotalAsync();

            var result = new BPaging<GetDevicePagingResponse>()
            {
                Items = items,

                TotalItems = total,
            };
            return BResult<BPaging<GetDevicePagingResponse>>.Success(result);
        }
    }
}
