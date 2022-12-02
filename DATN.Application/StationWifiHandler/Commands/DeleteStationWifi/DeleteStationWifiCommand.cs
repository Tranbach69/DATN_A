using DATN.Application.Models;
using DATN.Infastructure.Repositories.StationWifiRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.StationWifiHandler.Commands.DeleteStationWifi
{
    public class DeleteStationWifiCommand : IRequest<BResult>
    {
        public int Id { get; set; }

        public DeleteStationWifiCommand(int id)
        {
            Id = id;
        }
    }

    public class DeleteStationWifiCommandHandler : IRequestHandler<DeleteStationWifiCommand, BResult>
    {
        private readonly IStationWifiRepository _stationWifiRepository;

        public DeleteStationWifiCommandHandler(IStationWifiRepository stationWifiRepository)
        {
            _stationWifiRepository = stationWifiRepository;
        }

        public async Task<BResult> Handle(DeleteStationWifiCommand request, CancellationToken cancellationToken)
        {
            await _stationWifiRepository.BDeleteByIdAsync(request.Id);
            return BResult.Success();
        }
    }
}
