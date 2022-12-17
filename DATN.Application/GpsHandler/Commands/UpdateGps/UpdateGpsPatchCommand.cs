using DATN.Application.Mapper;
using DATN.Application.Models;
using DATN.Core.Entities;
using DATN.Infastructure.Repositories.GpsRepository;
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

namespace DATN.Application.GpsHandler.Commands.UpdateGps
{
	public class UpdateGpsPatchCommand : IRequest<BResult>
	{
		public UpdateGpsPatchCommand(string imei, JsonPatchDocument requestPatch)
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

	public class UpdateGpsPatchCommandHandler : IRequestHandler<UpdateGpsPatchCommand, BResult>
	{
		private readonly IGpsRepository _gpsRepository;
	
		public UpdateGpsPatchCommandHandler(IGpsRepository gpsRepository )
		{
			_gpsRepository = gpsRepository;
			
		}

		public async Task<BResult> Handle(UpdateGpsPatchCommand request, CancellationToken cancellationToken)
		{
			var imei = request.Imei;
			string key = request.RequestPatch.Operations[0].path;
			string afterKey = char.ToUpper(key.First()) + key.Substring(1).ToLower();
			var value = request.RequestPatch.Operations[0].value;

			const int PORT_NO = 3023;
			const string SERVER_IP = "localhost";
			
			string gpsPackage = "{\"Index\":3,\"Imei\":\"" + imei + "\",\"" + afterKey + "\":\"" + value + "\"}";
			//---data to send to the server---
			string textToSend = gpsPackage;
			//---create a TCPClient object at the IP and port no.---
			TcpClient client = new TcpClient(SERVER_IP, PORT_NO);
			NetworkStream nwStream = client.GetStream();
			byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(textToSend);
			//---send the text---
			nwStream.Write(bytesToSend, 0, bytesToSend.Length);
	

			// nhan phai hoi tu server
			byte[] bytesToRead = new byte[client.ReceiveBufferSize];
			int bytesRead = nwStream.Read(bytesToRead, 0, client.ReceiveBufferSize);
			var textReciveFromServer = Encoding.ASCII.GetString(bytesToRead, 0, bytesRead);
			if (textReciveFromServer == "success3")
			{
				var result = await _gpsRepository.BUpdateTPatchImeiAsync(request.Imei, request.RequestPatch);
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
