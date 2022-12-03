using DATN.Application.Mapper;
using DATN.Infastructure.Repositories.GpsRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.GpsHandler.Queries.GetGpsByImei
{
    public class GetGpsByImeiQuery : IRequest<GetGpsByImeiResponse>
    {
        public string Imei { get; set; }

        public GetGpsByImeiQuery(string imei)
        {
            Imei = imei;
        }
    }
    public class GetGpsByImeiResponse
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

    public class GetGpsQueryHandler : IRequestHandler<GetGpsByImeiQuery, GetGpsByImeiResponse>
    {
        private readonly IGpsRepository _gpsRepository;

        public GetGpsQueryHandler(IGpsRepository gpsRepository)
        {
            _gpsRepository = gpsRepository;
        }

        public async Task<GetGpsByImeiResponse> Handle(GetGpsByImeiQuery request, CancellationToken cancellationToken)
        {
            var entity = await _gpsRepository.BGetByImeiAsync(request.Imei);
            var result = GpsMapper.Mapper.Map<GetGpsByImeiResponse>(entity);
            return result;

        }
    }
}
