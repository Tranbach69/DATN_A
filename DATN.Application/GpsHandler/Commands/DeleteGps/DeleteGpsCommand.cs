using DATN.Application.Models;
using DATN.Infastructure.Repositories.GpsRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.GpsHandler.Commands.DeleteGps
{
    public class DeleteGpsCommand : IRequest<BResult>
    {
        public string Imei { get; set; }

        public DeleteGpsCommand(string imei)
        {
            Imei = imei;
        }
    }

    public class DeleteGpsCommandHandler : IRequestHandler<DeleteGpsCommand, BResult>
    {
        private readonly IGpsRepository _GpsRepository;

        public DeleteGpsCommandHandler(IGpsRepository gpsRepository)
        {
            _GpsRepository = gpsRepository;
        }

        public async Task<BResult> Handle(DeleteGpsCommand request, CancellationToken cancellationToken)
        {
            var result = await _GpsRepository.BDeleteByImeiAsync(request.Imei);
            if (result == null)
            {
                return BResult.Failure("imei không tồn tại");
            }
            return BResult.Success();
        }
    }
}
