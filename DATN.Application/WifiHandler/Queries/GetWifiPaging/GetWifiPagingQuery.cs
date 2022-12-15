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

namespace DATN.Application.WifiHandler.Queries.GetWifiPaging
{
    public class GetWifiPagingQuery : IRequest<BResult<BPaging<GetWifiPagingResponse>>>
    {
        public int Skip { get; set; }
        public int PageSize { get; set; }
    }
    public class GetWifiPagingResponse
    {
		public string Imei { get; set; }
		public int WifiOpen { get; set; }
		public int WifiMode { get; set; }
		public int CurrentAp { get; set; }
		public int WifiNat { get; set; }

		public string SsidWifi1 { get; set; }
		public int AuthTypeWifi1 { get; set; }
		public int EncryptModeWifi1 { get; set; }
		public string AuthPwdWifi1 { get; set; }
		public int ClientCountWifi1 { get; set; }
		public int BroadCastWifi1 { get; set; }
		public int IsolationWifi1 { get; set; }
		public string MacAddressWifi1 { get; set; }
		public int ChannelModeWifi1 { get; set; }
		public int ChannelWifi1 { get; set; }
		public string DhcpHostIpWifi1 { get; set; }
		public string DhcpStartIpWifi1 { get; set; }
		public string DhcpEndIpWifi1 { get; set; }
		public string DhcpTimeWifi1 { get; set; }

		public string SsidWifi2 { get; set; }
		public int AuthTypeWifi2 { get; set; }
		public int EncryptModeWifi2 { get; set; }
		public string AuthPwdWifi2 { get; set; }
		public int ClientCountWifi2 { get; set; }
		public int BroadCastWifi2 { get; set; }
		public int IsolationWifi2 { get; set; }
		public string MacAddressWifi2 { get; set; }
		public int ChannelModeWifi2 { get; set; }
		public int ChannelWifi2 { get; set; }
		public string DhcpHostIpWifi2 { get; set; }
		public string DhcpStartIpWifi2 { get; set; }
		public string DhcpEndIpWifi2 { get; set; }
		public string DhcpTimeWifi2 { get; set; }

		public string StaIp { get; set; }
		public string StaSsidExt { get; set; }
		public int StaSecurity { get; set; }
		public int StaProtocol { get; set; }
		public string StaPassword { get; set; }
		public bool IsDeleted { get; set; }
		public DateTime TimingCreate { get; set; }
		public DateTime TimingUpdate { get; set; }
		public DateTime TimingDelete { get; set; }

	}
    public class GetWifiPagingQueryHandler : IRequestHandler<GetWifiPagingQuery, BResult<BPaging<GetWifiPagingResponse>>>
    {
        private readonly IWifiRepository _wifiRepository;

        public GetWifiPagingQueryHandler(IWifiRepository wifiRepository)
        {
            _wifiRepository = wifiRepository;
        }
        public async Task<BResult<BPaging<GetWifiPagingResponse>>> Handle(GetWifiPagingQuery request, CancellationToken cancellationToken)
        {
            var entities = await _wifiRepository.BGetPagingAsync(request.Skip, request.PageSize);
            var items = WifiMapper.Mapper.Map<List<GetWifiPagingResponse>>(entities);
            var total = await _wifiRepository.BGetTotalAsync();

			var result = new BPaging<GetWifiPagingResponse>()
            {
                Items = items,

                TotalItems = total,
            };
            return BResult<BPaging<GetWifiPagingResponse>>.Success(result);
        }
    }
}
