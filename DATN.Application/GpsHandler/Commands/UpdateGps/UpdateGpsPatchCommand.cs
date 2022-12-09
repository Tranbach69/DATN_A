using DATN.Application.Mapper;
using DATN.Application.Models;
using DATN.Core.Entities;
using DATN.Infastructure.Repositories.GpsRepository;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
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
			//var entity = GpsMapper.Mapper.Map<Gps>(request);
			
			await _gpsRepository.BUpdateTPatchImeiAsync(request.Imei, request.RequestPatch);
			return BResult.Success();
		}
	}
}
