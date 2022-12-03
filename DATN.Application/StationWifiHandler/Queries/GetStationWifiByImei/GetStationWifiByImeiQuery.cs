using DATN.Application.Mapper;
using DATN.Infastructure.Repositories.StationWifiRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.StationWifiHandler.Queries.GetStationWifiByImei
{
    public class GetStationWifiByImeiQuery : IRequest<GetStationWifiByImeiResponse>
    {
        public string Imei { get; set; }

        public GetStationWifiByImeiQuery(string imei)
        {
            Imei = imei;
        }
    }
    public class GetStationWifiByImeiResponse
    {
        public int Id { get; set; }
        public string Imei { get; set; }
        public string StaIp { get; set; }
        public string StaSsidExt { get; set; }
        public string StaSecurity { get; set; }
        public string StaProtocol { get; set; }
        public int StaPassword { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime TimingCreate { get; set; }
        public DateTime TimingUpdate { get; set; }
        public DateTime TimingDelete { get; set; }
    }

    public class GetStationWifiQueryHandler : IRequestHandler<GetStationWifiByImeiQuery, GetStationWifiByImeiResponse>
    {
        private readonly IStationWifiRepository _stationWifiRepository;

        public GetStationWifiQueryHandler(IStationWifiRepository stationWifiRepository)
        {
            _stationWifiRepository = stationWifiRepository;
        }

        public async Task<GetStationWifiByImeiResponse> Handle(GetStationWifiByImeiQuery request, CancellationToken cancellationToken)
        {
            var entity = await _stationWifiRepository.BGetByImeiAsync(request.Imei);
            var result = StationWifiMapper.Mapper.Map<GetStationWifiByImeiResponse>(entity);
            return result;

        }
    }
}
