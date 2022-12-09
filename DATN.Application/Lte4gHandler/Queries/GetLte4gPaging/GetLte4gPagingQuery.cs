using DATN.Application.Mapper;
using DATN.Application.Models;
using DATN.Infastructure.Repositories.Lte4gRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.Lte4gHandler.Queries.GetLte4gPaging
{
    public class GetLte4gPagingQuery : IRequest<BResult<BPaging<GetLte4gPagingResponse>>>
    {
        public int Skip { get; set; }
        public int PageSize { get; set; }
    }
    public class GetLte4gPagingResponse
    {
        public string Imei { get; set; }
        public string SimStatus { get; set; }
        public string SimIccid { get; set; }
        public string SimImsi { get; set; }
        public string SystemMode { get; set; }
        public string OperationMode { get; set; }
        public string MobileCountryCode { get; set; }
        public string MobileNetworkCode { get; set; }
        public string LocationAreaCode { get; set; }
        public string ServiceCellId { get; set; }
        public string FreqBand { get; set; }
        public string Current4GData { get; set; }
        public string Afrcn { get; set; }
        public string PhoneNumber { get; set; }
        public string Rssi4G { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime TimingCreate { get; set; }
        public DateTime TimingUpdate { get; set; }
        public DateTime TimingDelete { get; set; }
    }
    public class GetLte4gPagingQueryHandler : IRequestHandler<GetLte4gPagingQuery, BResult<BPaging<GetLte4gPagingResponse>>>
    {
        private readonly ILte4gRepository _Lte4gRepository;

        public GetLte4gPagingQueryHandler(ILte4gRepository Lte4gRepository)
        {
            _Lte4gRepository = Lte4gRepository;
        }
        public async Task<BResult<BPaging<GetLte4gPagingResponse>>> Handle(GetLte4gPagingQuery request, CancellationToken cancellationToken)
        {
            var entities = await _Lte4gRepository.BGetPagingAsync(request.Skip, request.PageSize);
            var items = Lte4gMapper.Mapper.Map<List<GetLte4gPagingResponse>>(entities);
            var total = await _Lte4gRepository.BGetTotalAsync();

            var result = new BPaging<GetLte4gPagingResponse>()
            {
                Items = items,

                TotalItems = total,
            };
            return BResult<BPaging<GetLte4gPagingResponse>>.Success(result);
        }
    }
}
