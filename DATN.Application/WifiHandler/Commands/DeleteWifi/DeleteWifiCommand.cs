using DATN.Application.Models;
using DATN.Infastructure.Repositories.WifiRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.WifiHandler.Commands.DeleteWifi
{
    public class DeleteWifiCommand : IRequest<BResult>
    {
        public int Id { get; set; }

        public DeleteWifiCommand(int id)
        {
            Id = id;
        }
    }

    public class DeleteWifiCommandHandler : IRequestHandler<DeleteWifiCommand, BResult>
    {
        private readonly IWifiRepository _WifiRepository;

        public DeleteWifiCommandHandler(IWifiRepository wifiRepository)
        {
            _WifiRepository = wifiRepository;
        }

        public async Task<BResult> Handle(DeleteWifiCommand request, CancellationToken cancellationToken)
        {
            await _WifiRepository.BDeleteByIdAsync(request.Id);
            return BResult.Success();
        }
    }
}
