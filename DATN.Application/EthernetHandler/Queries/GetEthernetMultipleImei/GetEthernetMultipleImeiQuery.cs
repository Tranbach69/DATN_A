using DATN.Application.Mapper;
using DATN.Application.Models;
using DATN.Infastructure.Repositories.EthernetRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.EthernetHandler.Queries.GetEthernetByMultipleImei
{
    public class GetEthernetMultipleImeiQuery : IRequest<BResult<BPaging<GetEthernetMultipleImeiResponse>>>
    {
        public string Imei { get; set; }

        public GetEthernetMultipleImeiQuery(string imei)
        {
            Imei = imei;
        }
    }
    public class GetEthernetMultipleImeiResponse
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

    public class GetEthernetMultipleImeiQueryHandler : IRequestHandler<GetEthernetMultipleImeiQuery, BResult<BPaging<GetEthernetMultipleImeiResponse>>>
    {
        private readonly IEthernetRepository _ethernetRepository;

        public GetEthernetMultipleImeiQueryHandler(IEthernetRepository ethernetRepository)
        {
            _ethernetRepository = ethernetRepository;
        }

        public async Task<BResult<BPaging<GetEthernetMultipleImeiResponse>>> Handle(GetEthernetMultipleImeiQuery request, CancellationToken cancellationToken)
        {
            var entity = await _ethernetRepository.BGetMultipleImeiAsync(request.Imei);
            var items = EthernetMapper.Mapper.Map<List<GetEthernetMultipleImeiResponse>>(entity);
            var total = await _ethernetRepository.BGetTotalImeiAsync(request.Imei);
            var result = new BPaging<GetEthernetMultipleImeiResponse>()
            {
                Items = items,
                TotalItems = total,
            };
            return BResult<BPaging<GetEthernetMultipleImeiResponse>>.Success(result);

        }
    }
}
