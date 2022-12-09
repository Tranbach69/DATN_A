using DATN.Application.Mapper;
using DATN.Application.Models;
using DATN.Core.Entities;
using DATN.Infastructure.Repositories.WifiRepository;
using MediatR;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.WifiHandler.Commands.UpdateWifi
{
    public class UpdateWifiCommand : IRequest<BResult>
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
	}

    public class UpdateWifiCommandHandler : IRequestHandler<UpdateWifiCommand, BResult>
    {
        private readonly IWifiRepository _wifiRepository;

        public UpdateWifiCommandHandler(IWifiRepository wifiRepository)
        {
            _wifiRepository = wifiRepository;
        }

        public async Task<BResult> Handle(UpdateWifiCommand request, CancellationToken cancellationToken)
        {
            var entity = WifiMapper.Mapper.Map<Wifi>(request);
            var result = await _wifiRepository.BUpdateAsync(entity);
			if (result == null)
			{
				if (request.Imei == "")
				{
					return BResult.Failure("Imei phải có giá trị");
				}
				else return BResult.Failure("Imei không tồn tại");

			}
			const int PORT_NO = 3023;
			const string SERVER_IP = "localhost";

			string s = "0"+JsonConvert.SerializeObject(request);
			//---data to send to the server---
			string textToSend = s;

			//---create a TCPClient object at the IP and port no.---
			TcpClient client = new TcpClient(SERVER_IP, PORT_NO);
			NetworkStream nwStream = client.GetStream();
			byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(textToSend);

			//---send the text---
			nwStream.Write(bytesToSend, 0, bytesToSend.Length);

			client.Close();

			return BResult.Success();
		}
    }
}
