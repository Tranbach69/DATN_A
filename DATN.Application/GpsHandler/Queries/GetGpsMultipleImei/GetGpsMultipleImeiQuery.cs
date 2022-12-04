using DATN.Application.Mapper;
using DATN.Application.Models;
using DATN.Infastructure.Repositories.GpsRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.GpsHandler.Queries.GetGpsByMultipleImei
{
    public class GetGpsMultipleImeiQuery : IRequest<BResult<BPaging<GetGpsMultipleImeiResponse>>>
    {
        public string Imei { get; set; }

        public GetGpsMultipleImeiQuery(string imei)
        {
            Imei = imei;
        }
    }
    public class GetGpsMultipleImeiResponse
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

    public class GetGpsMultipleImeiQueryHandler : IRequestHandler<GetGpsMultipleImeiQuery, BResult<BPaging<GetGpsMultipleImeiResponse>>>
    {
        private readonly IGpsRepository _gpsRepository;

        public GetGpsMultipleImeiQueryHandler(IGpsRepository gpsRepository)
        {
            _gpsRepository = gpsRepository;
        }

        public async Task<BResult<BPaging<GetGpsMultipleImeiResponse>>> Handle(GetGpsMultipleImeiQuery request, CancellationToken cancellationToken)
        {
            var entity = await _gpsRepository.BGetMultipleImeiAsync(request.Imei);
            var items = GpsMapper.Mapper.Map<List<GetGpsMultipleImeiResponse>>(entity);
            var total = await _gpsRepository.BGetTotalImeiAsync(request.Imei);
            var result = new BPaging<GetGpsMultipleImeiResponse>()
            {
                Items = items,
                TotalItems = total,
            };
            return BResult<BPaging<GetGpsMultipleImeiResponse>>.Success(result);

        }
    }
}
