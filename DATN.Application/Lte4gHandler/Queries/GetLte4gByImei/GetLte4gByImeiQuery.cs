using DATN.Application.Mapper;
using DATN.Infastructure.Repositories.Lte4gRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.Lte4gHandler.Queries.GetLte4gByImei
{
    public class GetLte4gByImeiQuery : IRequest<GetLte4gByImeiResponse>
    {
        public string Imei { get; set; }

        public GetLte4gByImeiQuery(string imei)
        {
            Imei = imei;
        }
    }
    public class GetLte4gByImeiResponse
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

    public class GetLte4gQueryHandler : IRequestHandler<GetLte4gByImeiQuery, GetLte4gByImeiResponse>
    {
        private readonly ILte4gRepository _lte4gRepository;

        public GetLte4gQueryHandler(ILte4gRepository lte4gRepository)
        {
            _lte4gRepository = lte4gRepository;
        }

        public async Task<GetLte4gByImeiResponse> Handle(GetLte4gByImeiQuery request, CancellationToken cancellationToken)
        {
            var entity = await _lte4gRepository.BGetByImeiAsync(request.Imei);
            var result = Lte4gMapper.Mapper.Map<GetLte4gByImeiResponse>(entity);
            return result;

        }
    }
}
