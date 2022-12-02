using DATN.Application.Mapper;
using DATN.Infastructure.Repositories.StationWifiRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.StationWifiHandler.Queries.GetStationWifi
{
    public class GetStationWifiQuery : IRequest<GetStationWifiResponse>
    {
        public int Id { get; set; }

        public GetStationWifiQuery(int id)
        {
            Id = id;
        }
    }
    public class GetStationWifiResponse
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

    public class GetStationWifiQueryHandler : IRequestHandler<GetStationWifiQuery, GetStationWifiResponse>
    {
        private readonly IStationWifiRepository _StationWifiRepository;

        public GetStationWifiQueryHandler(IStationWifiRepository StationWifiRepository)
        {
            _StationWifiRepository = StationWifiRepository;
        }

        public async Task<GetStationWifiResponse> Handle(GetStationWifiQuery request, CancellationToken cancellationToken)
        {
            var entity = await _StationWifiRepository.BGetByIdAsync(request.Id);
            var result = StationWifiMapper.Mapper.Map<GetStationWifiResponse>(entity);
            return result;

        }
    }
}
