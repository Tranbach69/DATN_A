using DATN.Application.Mapper;
using DATN.Application.Models;
using DATN.Infastructure.Repositories.StationWifiRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.StationWifiHandler.Queries.GetStationWifiByMultipleImei
{
    public class GetStationWifiMultipleImeiQuery : IRequest<BResult<BPaging<GetStationWifiMultipleImeiResponse>>>
    {
        public string Imei { get; set; }

        public GetStationWifiMultipleImeiQuery(string imei)
        {
            Imei = imei;
        }
    }
    public class GetStationWifiMultipleImeiResponse
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

    public class GetStationWifiMultipleImeQueryHandler : IRequestHandler<GetStationWifiMultipleImeiQuery, BResult<BPaging<GetStationWifiMultipleImeiResponse>>>
    {
        private readonly IStationWifiRepository _stationWifiRepository;

        public GetStationWifiMultipleImeQueryHandler(IStationWifiRepository stationWifiRepository)
        {
            _stationWifiRepository = stationWifiRepository;
        }

        public async Task<BResult<BPaging<GetStationWifiMultipleImeiResponse>>> Handle(GetStationWifiMultipleImeiQuery request, CancellationToken cancellationToken)
        {
            var entity = await _stationWifiRepository.BGetMultipleImeiAsync(request.Imei);
            var items = StationWifiMapper.Mapper.Map<List<GetStationWifiMultipleImeiResponse>>(entity);
            var total = await _stationWifiRepository.BGetTotalImeiAsync(request.Imei);
            var result = new BPaging<GetStationWifiMultipleImeiResponse>()
            {
                Items = items,
                TotalItems = total,
            };
            return BResult<BPaging<GetStationWifiMultipleImeiResponse>>.Success(result);

        }
    }
}
