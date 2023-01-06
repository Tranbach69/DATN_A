using DATN.Application.Mapper;
using DATN.Application.Models;
using DATN.Core.Entities;
using DATN.Infastructure.Repositories.GpsRepository;
using MediatR;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.GpsHandler.Commands.UpdateGps
{
    public class UpdateGpsCommand : IRequest<BResult>
    {
        public string Imei { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Altitude { get; set; }
        public float Speed { get; set; }
        public float Bearing { get; set; }
        public float Accuracy { get; set; }
        public string Time { get; set; }

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
            var result = await _gpsRepository.BUpdateAsync(entity);
            if (result == null)
            {
                if (request.Imei == "")
                {
                    return BResult.Failure("Imei phải có giá trị");
                }
                else return BResult.Failure("Imei không tồn tại");

            }
            return BResult.Success();
        }
    }
}
