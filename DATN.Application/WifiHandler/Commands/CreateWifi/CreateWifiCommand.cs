using DATN.Application.Mapper;
using DATN.Application.Models;
using DATN.Core.Entities;
using DATN.Infastructure.Repositories.WifiRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.WifiHandler.Commands.CreateWifi
{
	public class CreateWifiCommand : IRequest<BResult>
	{
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
	public class CreateWifiCommandHandler : IRequestHandler<CreateWifiCommand, BResult>
	{
		private readonly IWifiRepository _WifiRepository;

		public CreateWifiCommandHandler(IWifiRepository wifiRepository)
		{
			_WifiRepository = wifiRepository;
		}

		public async Task<BResult> Handle(CreateWifiCommand request, CancellationToken cancellationToken)
		{
			var entity = WifiMapper.Mapper.Map<Wifi>(request);
			await _WifiRepository.BAddAsync(entity);
			return BResult.Success();
		}
	}
}
