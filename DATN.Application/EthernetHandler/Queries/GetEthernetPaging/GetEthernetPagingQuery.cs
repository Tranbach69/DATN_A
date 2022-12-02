using DATN.Application.Mapper;
using DATN.Application.Models;
using DATN.Infastructure.Repositories.DeviceRepository;
using DATN.Infastructure.Repositories.EthernetRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.EthernetHandler.Queries.GetEthernetPaging
{
    public class GetEthernetPagingQuery : IRequest<BResult<BPaging<GetEthernetPagingResponse>>>
    {
        public int Skip { get; set; }
        public int PageSize { get; set; }
    }
    public class GetEthernetPagingResponse
    {
        public int Id { get; set; }
        public string Imei { get; set; }
        public string DriverType { get; set; }
        public string BringUpdownEn { get; set; }
        public string IpStaticEn { get; set; }
        public string IpAddr { get; set; }
        public string DriverEn { get; set; }
        public string Netmask { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime TimingCreate { get; set; }
        public DateTime TimingUpdate { get; set; }
        public DateTime TimingDelete { get; set; }

    }
    public class GetEthernetPagingQueryHandler : IRequestHandler<GetEthernetPagingQuery, BResult<BPaging<GetEthernetPagingResponse>>>
    {
        private readonly IEthernetRepository _ethernetRepository;

        public GetEthernetPagingQueryHandler(IEthernetRepository ethernetRepository)
        {
            _ethernetRepository = ethernetRepository;
        }
        public async Task<BResult<BPaging<GetEthernetPagingResponse>>> Handle(GetEthernetPagingQuery request, CancellationToken cancellationToken)
        {
            var entities = await _ethernetRepository.BGetPagingAsync(request.Skip, request.PageSize);
            var items = EthernetMapper.Mapper.Map<List<GetEthernetPagingResponse>>(entities);
            var total = await _ethernetRepository.BGetTotalAsync();

            var result = new BPaging<GetEthernetPagingResponse>()
            {
                Items = items,

                TotalItems = total,
            };
            return BResult<BPaging<GetEthernetPagingResponse>>.Success(result);
        }
    }
}
