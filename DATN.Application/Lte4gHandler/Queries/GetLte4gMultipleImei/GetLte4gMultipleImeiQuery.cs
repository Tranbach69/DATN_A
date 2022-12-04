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

namespace DATN.Application.Lte4gHandler.Queries.GetLte4gByMultipleImei
{
    public class GetLte4gMultipleImeiQuery : IRequest<BResult<BPaging<GetLte4gMultipleImeiResponse>>>
    {
        public string Imei { get; set; }

        public GetLte4gMultipleImeiQuery(string imei)
        {
            Imei = imei;
        }
    }
    public class GetLte4gMultipleImeiResponse
    {
        public int Id { get; set; }
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

    public class GetLte4gMultipleImeiQueryHandler : IRequestHandler<GetLte4gMultipleImeiQuery, BResult<BPaging<GetLte4gMultipleImeiResponse>>>
    {
        private readonly ILte4gRepository _lte4gRepository;

        public GetLte4gMultipleImeiQueryHandler(ILte4gRepository lte4gRepository)
        {
            _lte4gRepository = lte4gRepository;
        }

        public async Task<BResult<BPaging<GetLte4gMultipleImeiResponse>>> Handle(GetLte4gMultipleImeiQuery request, CancellationToken cancellationToken)
        {
            var entity = await _lte4gRepository.BGetMultipleImeiAsync(request.Imei);
            var items = Lte4gMapper.Mapper.Map<List<GetLte4gMultipleImeiResponse>>(entity);
            var total = await _lte4gRepository.BGetTotalImeiAsync(request.Imei);
            var result = new BPaging<GetLte4gMultipleImeiResponse>()
            {
                Items = items,
                TotalItems = total,
            };
            return BResult<BPaging<GetLte4gMultipleImeiResponse>>.Success(result);

        }
    }
}
