using DATN.Application.Mapper;
using DATN.Application.Models;
using DATN.Core.Entities;
using DATN.Infastructure.Repositories.Lte4gRepository;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
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
			//var entity = WifiMapper.Mapper.Map<Wifi>(request);
			
			await _lte4gRepository.BUpdateTPatchImeiAsync(request.Imei, request.RequestPatch);
			return BResult.Success();
		}
	}
}
