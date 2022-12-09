using DATN.Application.Mapper;
using DATN.Application.Models;
using DATN.Core.Entities;
using DATN.Infastructure.Repositories.WifiRepository;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
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
			//var entity = WifiMapper.Mapper.Map<Wifi>(request);
			
			await _wifiRepository.BUpdateTPatchImeiAsync(request.Imei, request.RequestPatch);
			return BResult.Success();
		}
	}
}
