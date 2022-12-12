using DATN.Application.Mapper;
using DATN.Application.Models;
using DATN.Core.Entities;
using DATN.Infastructure.Repositories.WifiRepository;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.WifiHandler.Commands.CreateWifi
{
	public class CreateWifiCommand : IRequest<BResult>
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
			var result = await _WifiRepository.BAddAsync(entity);

            if (result != null)
            {           
                return BResult.Success();
            }
            else { 
            return BResult.Failure("Imei không được phép trống");
            
            }
		}
	}
}
