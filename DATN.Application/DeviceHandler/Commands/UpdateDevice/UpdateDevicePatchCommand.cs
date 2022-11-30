using DATN.Application.Mapper;
using DATN.Application.Models;
using DATN.Core.Entities;
using DATN.Infastructure.Repositories.DeviceRepository;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.DeviceHandler.Commands.UpdateDevice
{
	public class UpdateDevicePatchCommand : IRequest<BResult>
	{
		public UpdateDevicePatchCommand(int id, JsonPatchDocument requestPatch)
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

	public class UpdateDevicePatchCommandHandler : IRequestHandler<UpdateDevicePatchCommand, BResult>
	{
		private readonly IDeviceRepository _deviceRepository;
	
		public UpdateDevicePatchCommandHandler(IDeviceRepository deviceRepository)
		{
			_deviceRepository = deviceRepository;
			
		}

		public async Task<BResult> Handle(UpdateDevicePatchCommand request, CancellationToken cancellationToken)
		{
			//var entity = WifiMapper.Mapper.Map<Wifi>(request);
			
			await _deviceRepository.BUpdateTPatchAsync(request.Id, request.RequestPatch);
			return BResult.Success();
		}
	}
}
