using DATN.Application.Mapper;
using DATN.Application.Models;
using DATN.Core.Entities;
using DATN.Infastructure.Repositories.Lte4gRepository;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.Lte4gHandler.Commands.UpdateLte4g
{
    public class UpdateLte4gCommand : IRequest<BResult>
    {
        public int Id { get; set; }
        public string Imei { get; set; }
        public string SimStatus { get; set; }
        public string SimIccid { get; set; }
        public string SimImsi { get; set; }
        public string SystemMode { get; set; }
        public string OperationMode { get; set; }
        public string MobileCountryCode { get; set; }
        public string MobileNetworkCode { get; set; }
        public string LocationAreaCode { get; set; }
        public string ServiceCellId { get; set; }
        public string FreqBand { get; set; }
        public string Current4GData { get; set; }
        public string Afrcn { get; set; }
        public string PhoneNumber { get; set; }
        public string Rssi4G { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime TimingCreate { get; set; }
        public DateTime TimingUpdate { get; set; }
        public DateTime TimingDelete { get; set; }
    }

    public class UpdateLte4gCommandHandler : IRequestHandler<UpdateLte4gCommand, BResult>
    {
        private readonly ILte4gRepository _lte4gRepository;

        public UpdateLte4gCommandHandler(ILte4gRepository lte4gRepository)
        {
            _lte4gRepository = lte4gRepository;
        }

        public async Task<BResult> Handle(UpdateLte4gCommand request, CancellationToken cancellationToken)
        {
            var entity = Lte4gMapper.Mapper.Map<Lte4g>(request);
            await _lte4gRepository.BUpdateAsync(entity);
            return BResult.Success();
        }
    }
}
