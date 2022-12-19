using DATN.Application.Mapper;
using DATN.Application.Models;
using DATN.Core.Entities;
using DATN.Infastructure.Repositories.Lte4gRepository;
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

namespace DATN.Application.Lte4gHandler.Commands.UpdateLte4g
{
	public class UpdateLte4gPatchCommand : IRequest<BResult>
	{
		public UpdateLte4gPatchCommand(string imei, JsonPatchDocument requestPatch)
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

	public class UpdateLte4gPatchCommandHandler : IRequestHandler<UpdateLte4gPatchCommand, BResult>
	{
		private readonly ILte4gRepository _lte4gRepository;
	
		public UpdateLte4gPatchCommandHandler(ILte4gRepository lte4gRepository)
		{
			_lte4gRepository = lte4gRepository;
			
		}

		public async Task<BResult> Handle(UpdateLte4gPatchCommand request, CancellationToken cancellationToken)
		{
			var imei = request.Imei;
			string key = request.RequestPatch.Operations[0].path;
			string afterKey = char.ToUpper(key.First()) + key.Substring(1).ToLower();
			var value = request.RequestPatch.Operations[0].value;

			const int PORT_NO = 3023;
			const string SERVER_IP = "localhost";
			string lte4gPackage = "{\"Imei\":\"" + imei + "\",\"Index\":0,\"" + afterKey + "\":\"" + value + "\"}";
			//---data to send to the server---
			string textToSend = lte4gPackage;
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
			if (textReciveFromServer == "success1")
			{
				var result = await _lte4gRepository.BUpdateTPatchImeiAsync(request.Imei, request.RequestPatch);
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
