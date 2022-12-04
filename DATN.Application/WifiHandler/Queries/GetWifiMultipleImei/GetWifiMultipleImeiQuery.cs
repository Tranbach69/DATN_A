using DATN.Application.Mapper;
using DATN.Application.Models;
using DATN.Infastructure.Repositories.WifiRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.WifiHandler.Queries.GetWifiByMultipleImei
{
    public class GetWifiMultipleImeiQuery : IRequest<BResult<BPaging<GetWifiMultipleImeiResponse>>>
    {
        public string Imei { get; set; }

        public GetWifiMultipleImeiQuery(string imei)
        {
            Imei = imei;
        }
    }
    public class GetWifiMultipleImeiResponse
    {
        public int Id { get; set; }
        public int ClientCount { get; set; }
        public string Imei { get; set; }
        public string WifiOpen { get; set; }
        public string WifiMode { get; set; }
        public string CurrentAp { get; set; }
        public string WifiNat { get; set; }
        public string Ssid { get; set; }
        public string AuthPwd { get; set; }
        public string BroadCast { get; set; }
        public string Isolation { get; set; }
        public string MacAddress { get; set; }
        public string AuthType { get; set; }
        public string EncryptMode { get; set; }
        public string Channel { get; set; }
        public string ChannelMode { get; set; }
        public string DhcpHostIp { get; set; }
        public string DhcpStartIp { get; set; }
        public string DhcpEndIp { get; set; }
        public string DhcpTime { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime TimingCreate { get; set; }
        public DateTime TimingUpdate { get; set; }
        public DateTime TimingDelete { get; set; }
    }

    public class GetWifiMultipleImeiQueryHandler : IRequestHandler<GetWifiMultipleImeiQuery, BResult<BPaging<GetWifiMultipleImeiResponse>>>
    {
        private readonly IWifiRepository _wifiRepository;

        public GetWifiMultipleImeiQueryHandler(IWifiRepository wifiRepository)
        {
            _wifiRepository = wifiRepository;
        }

        public async Task<BResult<BPaging<GetWifiMultipleImeiResponse>>> Handle(GetWifiMultipleImeiQuery request, CancellationToken cancellationToken)
        {
            var entity = await _wifiRepository.BGetMultipleImeiAsync(request.Imei);
            var items = WifiMapper.Mapper.Map<List<GetWifiMultipleImeiResponse>>(entity);
            var total = await _wifiRepository.BGetTotalImeiAsync(request.Imei);
            var result = new BPaging<GetWifiMultipleImeiResponse>()
            {
                Items = items,
                TotalItems = total,
            };
            return BResult<BPaging<GetWifiMultipleImeiResponse>>.Success(result);

        }
    }
}
