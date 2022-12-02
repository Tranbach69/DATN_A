using DATN.Application.Mapper;
using DATN.Application.Models;
using DATN.Core.Entities;
using DATN.Infastructure.Repositories.StationWifiRepository;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.StationWifiHandler.Commands.UpdateStationWifi
{
	public class UpdateStationWifiPatchCommand : IRequest<BResult>
	{
		public UpdateStationWifiPatchCommand(int id, JsonPatchDocument requestPatch)
		{
			Id = id;
			RequestPatch = requestPatch;
		}
		public int Id { get; set; }
		public JsonPatchDocument RequestPatch { get;  set; }
		//public string Op { get; set; }
		//public string Path { get; set; }
		//public string Value { get; set; }
	}

	public class UpdateStationWifiPatchCommandHandler : IRequestHandler<UpdateStationWifiPatchCommand, BResult>
	{
		private readonly IStationWifiRepository _stationWifiRepository;
	
		public UpdateStationWifiPatchCommandHandler(IStationWifiRepository stationWifiRepository)
		{
			_stationWifiRepository = stationWifiRepository;
			
		}

		public async Task<BResult> Handle(UpdateStationWifiPatchCommand request, CancellationToken cancellationToken)
		{
			//var entity = WifiMapper.Mapper.Map<Wifi>(request);
			
			await _stationWifiRepository.BUpdateTPatchAsync(request.Id, request.RequestPatch);
			return BResult.Success();
		}
	}
}
