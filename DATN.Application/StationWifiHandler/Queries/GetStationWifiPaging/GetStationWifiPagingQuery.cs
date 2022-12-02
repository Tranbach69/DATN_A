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

namespace DATN.Application.StationWifiHandler.Queries.GetStationWifiPaging
{
    public class GetStationWifiPagingQuery : IRequest<BResult<BPaging<GetStationWifiPagingResponse>>>
    {
        public int Skip { get; set; }
        public int PageSize { get; set; }
    }
    public class GetStationWifiPagingResponse
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
    public class GetStationWifiPagingQueryHandler : IRequestHandler<GetStationWifiPagingQuery, BResult<BPaging<GetStationWifiPagingResponse>>>
    {
        private readonly IStationWifiRepository _stationWifiRepository;

        public GetStationWifiPagingQueryHandler(IStationWifiRepository stationWifiRepository)
        {
            _stationWifiRepository = stationWifiRepository;
        }
        public async Task<BResult<BPaging<GetStationWifiPagingResponse>>> Handle(GetStationWifiPagingQuery request, CancellationToken cancellationToken)
        {
            var entities = await _stationWifiRepository.BGetPagingAsync(request.Skip, request.PageSize);
            var items = StationWifiMapper.Mapper.Map<List<GetStationWifiPagingResponse>>(entities);
            var total = await _stationWifiRepository.BGetTotalAsync();

            var result = new BPaging<GetStationWifiPagingResponse>()
            {
                Items = items,

                TotalItems = total,
            };
            return BResult<BPaging<GetStationWifiPagingResponse>>.Success(result);
        }
    }
}
