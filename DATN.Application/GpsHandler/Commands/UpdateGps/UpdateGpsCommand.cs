using DATN.Application.Mapper;
using DATN.Application.Models;
using DATN.Core.Entities;
using DATN.Infastructure.Repositories.GpsRepository;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.GpsHandler.Commands.UpdateGps
{
    public class UpdateGpsCommand : IRequest<BResult>
    {
        public int Id { get; set; }
        public string MacAddress { get; set; }
        public int GpsOfDeviceId { get; set; }
        public string DoubleLatitude { get; set; }
        public string DoubleLongitude { get; set; }
        public string DoubleAltitude { get; set; }
        public string FloatSpeed { get; set; }
        public string FloatAccuracy { get; set; }
        public string Time { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime TimingCreate { get; set; }
        public DateTime TimingUpdate { get; set; }
        public DateTime TimingDelete { get; set; }
    }

    public class UpdateGpsCommandHandler : IRequestHandler<UpdateGpsCommand, BResult>
    {
        private readonly IGpsRepository _gpsRepository;

        public UpdateGpsCommandHandler(IGpsRepository gpsRepository)
        {
            _gpsRepository = gpsRepository;
        }

        public async Task<BResult> Handle(UpdateGpsCommand request, CancellationToken cancellationToken)
        {
            var entity = GpsMapper.Mapper.Map<Gps>(request);
            await _gpsRepository.BUpdateAsync(entity);
            return BResult.Success();
        }
    }
}
