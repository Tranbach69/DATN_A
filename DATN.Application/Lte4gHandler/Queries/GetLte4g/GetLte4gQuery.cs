using DATN.Application.Mapper;
using DATN.Infastructure.Repositories.Lte4gRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.Lte4gHandler.Queries.GetLte4g
{
    public class GetLte4gQuery : IRequest<GetLte4gResponse>
    {
        public string Imei { get; set; }

        public GetLte4gQuery(string imei)
        {
            Imei = imei;
        }
    }
    public class GetLte4gResponse
    {
        public string Imei { get; set; }
        public int CardStatus { get; set; }
        public int Apptype { get; set; }
        public int AppState { get; set; }
        public int Pin { get; set; }
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
        public int Rssi4G { get; set; }
        public int NetworkMode { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime TimingCreate { get; set; }
        public DateTime TimingUpdate { get; set; }
        public DateTime TimingDelete { get; set; }
    }

    public class GetLte4gQueryHandler : IRequestHandler<GetLte4gQuery, GetLte4gResponse>
    {
        private readonly ILte4gRepository _Lte4gRepository;

        public GetLte4gQueryHandler(ILte4gRepository lte4gRepository)
        {
            _Lte4gRepository = lte4gRepository;
        }

        public async Task<GetLte4gResponse> Handle(GetLte4gQuery request, CancellationToken cancellationToken)
        {
            var entity = await _Lte4gRepository.BGetByImeiAsync(request.Imei);
            var result = Lte4gMapper.Mapper.Map<GetLte4gResponse>(entity);
            return result;

        }
    }
}
