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

namespace DATN.Application.GpsHandler.Queries.GetGpsPaging
{
    public class GetGpsPagingQuery : IRequest<BResult<BPaging<GetGpsPagingResponse>>>
    {
        public int Skip { get; set; }
        public int PageSize { get; set; }
    }
    public class GetGpsPagingResponse
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
    public class GetGpsPagingQueryHandler : IRequestHandler<GetGpsPagingQuery, BResult<BPaging<GetGpsPagingResponse>>>
    {
        private readonly IGpsRepository _GpsRepository;

        public GetGpsPagingQueryHandler(IGpsRepository gpsRepository)
        {
            _GpsRepository = gpsRepository;
        }
        public async Task<BResult<BPaging<GetGpsPagingResponse>>> Handle(GetGpsPagingQuery request, CancellationToken cancellationToken)
        {
            var entities = await _GpsRepository.BGetPagingAsync(request.Skip, request.PageSize);
            var items = GpsMapper.Mapper.Map<List<GetGpsPagingResponse>>(entities);
            var total = await _GpsRepository.BGetTotalAsync();

            var result = new BPaging<GetGpsPagingResponse>()
            {
                Items = items,

                TotalItems = total,
            };
            return BResult<BPaging<GetGpsPagingResponse>>.Success(result);
        }
    }
}
