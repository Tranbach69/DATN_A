using DATN.Application.Mapper;
using DATN.Application.Models;
using DATN.Core.Entities;
using DATN.Infastructure.Repositories.StationWifiRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.StationWifiHandler.Commands.CreateStationWifi
{
	public class CreateStationWifiCommand : IRequest<BResult>
	{
		public string Imei { get; set; }
		public string StaIp { get; set; }
		public string StaSsidExt { get; set; }
		public string StaSecurity { get; set; }
		public string StaProtocol { get; set; }
		public int StaPassword { get; set; }
		public bool IsDeleted { get; set; }
		public DateTime TimingCreate { get; set; }
		public DateTime TimingUpdate { get; set; }
		public DateTime TimingDelete { get; set; }
	}
	public class CreateStationWifiCommandHandler : IRequestHandler<CreateStationWifiCommand, BResult>
	{
		private readonly IStationWifiRepository _stationWifiRepository;

		public CreateStationWifiCommandHandler(IStationWifiRepository stationWifiRepository)
		{
            _stationWifiRepository = stationWifiRepository;
		}

		public async Task<BResult> Handle(CreateStationWifiCommand request, CancellationToken cancellationToken)
		{
			var entity = StationWifiMapper.Mapper.Map<StationWifi>(request);
			await _stationWifiRepository.BAddAsync(entity);
			return BResult.Success();
		}
	}
}
