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
        public string Imei { get; set; }

        public GetWifiQuery(string imei)
        {
            Imei = imei;
        }
    }
    public class GetWifiResponse
    {
		public string Imei { get; set; }
		public string WifiOpen { get; set; }
		public string WifiMode { get; set; }
		public string CurrentAp { get; set; }
		public string WifiNat { get; set; }

		public string SsidWifi1 { get; set; }
		public string AuthTypeWifi1 { get; set; }
		public string EncryptModeWifi1 { get; set; }
		public string AuthPwdWifi1 { get; set; }
		public string ClientCountWifi1 { get; set; }
		public string BroadCastWifi1 { get; set; }
		public string IsolationWifi1 { get; set; }
		public string MacAddressWifi1 { get; set; }
		public string ChannelModeWifi1 { get; set; }
		public string ChannelWifi1 { get; set; }
		public string DhcpHostIpWifi1 { get; set; }
		public string DhcpStartIpWifi1 { get; set; }
		public string DhcpEndIpWifi1 { get; set; }
		public string DhcpTimeWifi1 { get; set; }

		public string SsidWifi2 { get; set; }
		public string AuthTypeWifi2 { get; set; }
		public string EncryptModeWifi2 { get; set; }
		public string AuthPwdWifi2 { get; set; }
		public string ClientCountWifi2 { get; set; }
		public string BroadCastWifi2 { get; set; }
		public string IsolationWifi2 { get; set; }
		public string MacAddressWifi2 { get; set; }
		public string ChannelModeWifi2 { get; set; }
		public string ChannelWifi2 { get; set; }
		public string DhcpHostIpWifi2 { get; set; }
		public string DhcpStartIpWifi2 { get; set; }
		public string DhcpEndIpWifi2 { get; set; }
		public string DhcpTimeWifi2 { get; set; }

		public string StaIp { get; set; }
		public string StaSsidExt { get; set; }
		public string StaSecurity { get; set; }
		public string StaProtocol { get; set; }
		public string StaPassword { get; set; }
		public bool IsDeleted { get; set; }
		public DateTime TimingCreate { get; set; }
		public DateTime TimingUpdate { get; set; }
		public DateTime TimingDelete { get; set; }
	}

    public class GetWifiQueryHandler : IRequestHandler<GetWifiQuery, GetWifiResponse>
    {
        private readonly IWifiRepository _wifiRepository;

        public GetWifiQueryHandler(IWifiRepository wifiRepository)
        {
            _wifiRepository = wifiRepository;
        }

        public async Task<GetWifiResponse> Handle(GetWifiQuery request, CancellationToken cancellationToken)
        {
            var entity = await _wifiRepository.BGetByImeiAsync(request.Imei);
            var result = WifiMapper.Mapper.Map<GetWifiResponse>(entity);
            return result;

        }
    }
}
