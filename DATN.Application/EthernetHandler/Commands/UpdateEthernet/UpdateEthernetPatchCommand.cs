using DATN.Application.Mapper;
using DATN.Application.Models;
using DATN.Core.Entities;
using DATN.Infastructure.Repositories.EthernetRepository;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.EthernetHandler.Commands.UpdateEthernet
{
	public class UpdateEthernetPatchCommand : IRequest<BResult>
	{
		public UpdateEthernetPatchCommand(string imei, JsonPatchDocument requestPatch)
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

	public class UpdateEthernetPatchCommandHandler : IRequestHandler<UpdateEthernetPatchCommand, BResult>
	{
		private readonly IEthernetRepository _ethernetRepository;
	
		public UpdateEthernetPatchCommandHandler(IEthernetRepository ethernetRepository )
		{
			_ethernetRepository = ethernetRepository;
			
		}

		public async Task<BResult> Handle(UpdateEthernetPatchCommand request, CancellationToken cancellationToken)
		{
			//var entity = EthernetMapper.Mapper.Map<Ethernet>(request);
			
			await _ethernetRepository.BUpdateTPatchImeiAsync(request.Imei, request.RequestPatch);
			return BResult.Success();
		}
	}
}
