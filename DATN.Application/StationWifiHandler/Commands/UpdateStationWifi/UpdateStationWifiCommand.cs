using DATN.Application.Mapper;
using DATN.Application.Models;
using DATN.Core.Entities;
using DATN.Infastructure.Repositories.StationWifiRepository;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.StationWifiHandler.Commands.UpdateStationWifi
{
    public class UpdateStationWifiCommand : IRequest<BResult>
    {
        public int Id { get; set; }
        public string Imei { get; set; }
        public string StaIp { get; set; }
        public string StaSsidExt { get; set; }
        public string StaSecurity { get; set; }
        public string StaProtocol { get; set; }
        public int StaPassword { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime TimingCreate { get; set; }
        public DateTime TimingUpdate { get; set; }
        public DateTime TimingDelete { get; set; }
    }

    public class UpdateStationWifiCommandHandler : IRequestHandler<UpdateStationWifiCommand, BResult>
    {
        private readonly IStationWifiRepository _stationWifiRepository;

        public UpdateStationWifiCommandHandler(IStationWifiRepository stationWifiRepository)
        {
            _stationWifiRepository = stationWifiRepository;
        }

        public async Task<BResult> Handle(UpdateStationWifiCommand request, CancellationToken cancellationToken)
        {
            var entity = WifiMapper.Mapper.Map<StationWifi>(request);
            await _stationWifiRepository.BUpdateAsync(entity);
            return BResult.Success();
        }
    }
}
