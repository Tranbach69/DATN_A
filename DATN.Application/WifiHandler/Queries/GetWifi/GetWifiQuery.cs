using DATN.Application.Mapper;
using DATN.Infastructure.Repositories.WifiRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.WifiHandler.Queries.GetWifi
{
    public class GetWifiQuery : IRequest<GetWifiResponse>
    {
        public int Id { get; set; }

        public GetWifiQuery(int id)
        {
            Id = id;
        }
    }
    public class GetWifiResponse
    {
        public int Id { get; set; }
        public string MacAddress { get; set; }
        public int WifiOfDeviceId { get; set; }
        public string Ssid { get; set; }
        public string Pwd { get; set; }
        public string BroadCast { get; set; }
        public string Iso { get; set; }
        public string AuthType { get; set; }
        public string EncryptMode { get; set; }
        public string Channel { get; set; }
        public string ChannelMode { get; set; }
        public string Mode { get; set; }
        public string DhcpHostIp { get; set; }
        public string DhcpStartIp { get; set; }
        public string DhcpEndIp { get; set; }
        public string DhcpTime { get; set; }
        public string MacAdd { get; set; }
        public string MacCount { get; set; }
        public string NatType { get; set; }
        public string Status { get; set; }
        public string CurrentAp { get; set; }
        public int ClientCount { get; set; }
        public string WpsEnable { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime TimingCreate { get; set; }
        public DateTime TimingUpdate { get; set; }
        public DateTime TimingDelete { get; set; }
    }

    public class GetWifiQueryHandler : IRequestHandler<GetWifiQuery, GetWifiResponse>
    {
        private readonly IWifiRepository _WifiRepository;

        public GetWifiQueryHandler(IWifiRepository WifiRepository)
        {
            _WifiRepository = WifiRepository;
        }

        public async Task<GetWifiResponse> Handle(GetWifiQuery request, CancellationToken cancellationToken)
        {
            var entity = await _WifiRepository.BGetByIdAsync(request.Id);
            var result = WifiMapper.Mapper.Map<GetWifiResponse>(entity);
            return result;

        }
    }
}
