using DATN.Application.Mapper;
using DATN.Application.Models;
using DATN.Core.Entities;
using DATN.Infastructure.Repositories.WifiRepository;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
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
	public class UpdateWifiPatchCommand : IRequest<BResult>
	{
		public UpdateWifiPatchCommand(string imei, JsonPatchDocument requestPatch)
		{
			Imei = imei;
			RequestPatch = requestPatch;
		}
		public string Imei { get; set; }
		public JsonPatchDocument RequestPatch { get;  set; }
		//public string Op { get; set; }
		//public string Path { get; set; }
		//public string Value { get; set; }
	}

	public class UpdateWifiPatchCommandHandler : IRequestHandler<UpdateWifiPatchCommand, BResult>
	{
		private readonly IWifiRepository _wifiRepository;
	
		public UpdateWifiPatchCommandHandler(IWifiRepository wifiRepository )
		{
			_wifiRepository = wifiRepository;
			
		}

		public async Task<BResult> Handle(UpdateWifiPatchCommand request, CancellationToken cancellationToken)
		{

			var imei = request.Imei;
			string key = request.RequestPatch.Operations[0].path;
			string afterKey = char.ToUpper(key.First()) + key.Substring(1);
			var value = request.RequestPatch.Operations[0].value;
			string wifiPackage;
			const int PORT_NO = 3023;
			const string SERVER_IP = "localhost";

    //        if (afterKey == "AuthPwdWifi1" || afterKey == "AuthTypeWifi1" || afterKey == "EncryptModeWifi1" ||afterKey == "ChannelModeWifi1" ||afterKey == "ChannelWifi1" || afterKey == "DhcpHostIpWifi1" || afterKey == "DhcpStartIpWifi1" || afterKey == "DhcpEndIpWifi1" ||afterKey == "DhcpTimeWifi1" ||
				//afterKey == "AuthPwdWifi2" || afterKey == "AuthTypeWifi2" || afterKey == "EncryptModeWifi2" ||afterKey == "ChannelModeWifi2" ||afterKey == "ChannelWifi2" || afterKey == "DhcpHostIpWifi2" || afterKey == "DhcpStartIpWifi2" || afterKey == "DhcpEndIpWifi2" ||afterKey == "DhcpTimeWifi2" ||
				//afterKey == "staSsidExt" || afterKey == "staSecurity" || afterKey == "staProtocol" || afterKey == "staPassword")
    //        {
				//var wifiInfo = await _wifiRepository.BGetByImeiAsync(request.Imei);
				//if(afterKey == "AuthPwdWifi1" || afterKey == "AuthTypeWifi1" || afterKey == "EncryptModeWifi1")
    //            {
				//	wifiPackage = "{\"Index\":0,\"Imei\":\"" + imei + "\",\"" + afterKey + "\":\"" + value + "\"," + "\"AuthTypeWifi1\":\"" + wifiInfo.AuthTypeWifi1 + "\",\"EncryptModeWifi1\":\"" + wifiInfo.EncryptModeWifi1 + "\"}";
				//}else if(afterKey == "AuthPwdWifi2" || afterKey == "AuthTypeWifi2" || afterKey == "EncryptModeWifi2")
    //            {
				//	wifiPackage = "{\"Index\":0,\"Imei\":\"" + imei + "\",\"" + afterKey + "\":\"" + value + "\"," + "\"AuthTypeWifi2\":\"" + wifiInfo.AuthTypeWifi2 + "\",\"EncryptModeWifi2\":\"" + wifiInfo.EncryptModeWifi2 + "\"}";
				//}
				//else if(afterKey == "ChannelModeWifi1" || afterKey == "ChannelWifi1")
    //            {
				//	wifiPackage = "{\"Index\":0,\"Imei\":\"" + imei + "\",\"" + afterKey + "\":\"" + value + "\"," + "\"ChannelModeWifi1\":\"" + wifiInfo.ChannelModeWifi1 + "\",\"ChannelWifi1\":\"" + wifiInfo.ChannelWifi1 + "\"}";
				//}					

    //        }
            //else
            //{

            //}
			wifiPackage = "{\"Index\":0,\"Imei\":\"" + imei + "\",\"" + afterKey + "\":\"" + value + "\"}";
			//---data to send to the server---
			string textToSend = wifiPackage;
			//---create a TCPClient object at the IP and port no.---
			TcpClient client = new TcpClient(SERVER_IP, PORT_NO);
			NetworkStream nwStream = client.GetStream();
			byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(textToSend);
			//---send the text---
			nwStream.Write(bytesToSend, 0, bytesToSend.Length);
			//---read back the text---
			byte[] bytesToRead = new byte[client.ReceiveBufferSize];
			int bytesRead = nwStream.Read(bytesToRead, 0, client.ReceiveBufferSize);
			var textReciveFromServer = Encoding.ASCII.GetString(bytesToRead, 0, bytesRead);
			if (textReciveFromServer == "success0")
			{
				var result = await _wifiRepository.BUpdateTPatchImeiAsync(request.Imei, request.RequestPatch);
				if (result == null)
				{
					return BResult.Failure("không tìm thấy Imei");
				}
				return BResult.Success();
			}
			else if (textReciveFromServer == "Decoding JSON has failed")
			{
				return BResult.Failure("Decoding JSON has failed");
			}
			client.Close();
			return BResult.Failure("Thiết Bị Đang Mất Kết Nối TCP");
		}
	}
}
