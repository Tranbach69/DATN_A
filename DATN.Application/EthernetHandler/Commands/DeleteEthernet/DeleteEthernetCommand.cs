using DATN.Application.Models;
using DATN.Infastructure.Repositories.EthernetRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.EthernetHandler.Commands.DeleteEthernet
{
    public class DeleteEthernetCommand : IRequest<BResult>
    {
        public string Imei { get; set; }

        public DeleteEthernetCommand(string imei)
        {
            Imei = imei;
        }
    }

    public class DeleteEthernetCommandHandler : IRequestHandler<DeleteEthernetCommand, BResult>
    {
        private readonly IEthernetRepository _EthernetRepository;

        public DeleteEthernetCommandHandler(IEthernetRepository ethernetRepository)
        {
            _EthernetRepository = ethernetRepository;
        }

        public async Task<BResult> Handle(DeleteEthernetCommand request, CancellationToken cancellationToken)
        {
            var result = await _EthernetRepository.BDeleteByImeiAsync(request.Imei);
            if (result == null)
            {
                return BResult.Failure("imei không tồn tại");
            }
            return BResult.Success();
        }
    }
}
