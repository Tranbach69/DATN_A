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
        public int Id { get; set; }

        public DeleteGpsCommand(int id)
        {
            Id = id;
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
            await _GpsRepository.BDeleteByIdAsync(request.Id);
            return BResult.Success();
        }
    }
}
