using DATN.Application.Mapper;
using DATN.Core.Entities;
using DATN.Infastructure.Repositories.GpsRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.GpsHandler.Queries.GetGps
{
    public class GetGpsQuery : IRequest<GetGpsResponse>
    {
        public string Imei { get; set; }

        public GetGpsQuery(string imei)
        {
            Imei = imei;
        }
    }
    public class GetGpsResponse
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

    public class GetGpsQueryHandler : IRequestHandler<GetGpsQuery, GetGpsResponse>
    {
        private readonly IGpsRepository _GpsRepository;

        public GetGpsQueryHandler(IGpsRepository gpsRepository)
        {
            _GpsRepository = gpsRepository;
        }

        public async Task<GetGpsResponse> Handle(GetGpsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _GpsRepository.BGetByImeiAsync(request.Imei);
            var result = GpsMapper.Mapper.Map<GetGpsResponse>(entity);
            return result;

        }
    }
}
