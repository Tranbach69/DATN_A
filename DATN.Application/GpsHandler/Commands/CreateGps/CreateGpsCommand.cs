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
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		public double Altitude { get; set; }
		public float Speed { get; set; }
		public float Bearing { get; set; }
		public float Accuracy { get; set; }
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
			var result = await _GpsRepository.BAddAsync(entity);
			if (result == null)
			{
				if (request.Imei == "")
				{
					return BResult.Failure("Imei phải có giá trị");
				}
				else return BResult.Failure("Không Thành Công, Xem Lại Thông Tin Đã nhập: imei có bị trùng không...");

			}
			return BResult.Success();
		}
	}
}
