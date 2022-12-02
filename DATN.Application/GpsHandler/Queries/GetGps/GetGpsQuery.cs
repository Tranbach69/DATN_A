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
        public int Id { get; set; }

        public GetGpsQuery(int id)
        {
            Id = id;
        }
    }
    public class GetGpsResponse
    {
        public int Id { get; set; }
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

    public class GetGpsQueryHandler : IRequestHandler<GetGpsQuery, GetGpsResponse>
    {
        private readonly IGpsRepository _GpsRepository;

        public GetGpsQueryHandler(IGpsRepository gpsRepository)
        {
            _GpsRepository = gpsRepository;
        }

        public async Task<GetGpsResponse> Handle(GetGpsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _GpsRepository.BGetByIdAsync(request.Id);
            var result = GpsMapper.Mapper.Map<GetGpsResponse>(entity);
            return result;

        }
    }
}
