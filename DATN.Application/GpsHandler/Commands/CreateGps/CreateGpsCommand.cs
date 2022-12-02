using DATN.Application.Mapper;
using DATN.Application.Models;
using DATN.Core.Entities;
using DATN.Infastructure.Repositories.GpsRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.GpsHandler.Commands.CreateGps
{
	public class CreateGpsCommand : IRequest<BResult>
	{
		public string Imei { get; set; }
		public string Latitude { get; set; }
		public string Longitude { get; set; }
		public string Altitude { get; set; }
		public string Speed { get; set; }
		public string Bearing { get; set; }
		public string Accuracy { get; set; }
		public string Time { get; set; }
		public bool IsDeleted { get; set; }
		public DateTime TimingCreate { get; set; }
		public DateTime TimingUpdate { get; set; }
		public DateTime TimingDelete { get; set; }
	}
	public class CreateGpsCommandHandler : IRequestHandler<CreateGpsCommand, BResult>
	{
		private readonly IGpsRepository _GpsRepository;

		public CreateGpsCommandHandler(IGpsRepository gpsRepository)
		{
			_GpsRepository = gpsRepository;
		}

		public async Task<BResult> Handle(CreateGpsCommand request, CancellationToken cancellationToken)
		{
			var entity = GpsMapper.Mapper.Map<Gps>(request);
			await _GpsRepository.BAddAsync(entity);
			return BResult.Success();
		}
	}
}
