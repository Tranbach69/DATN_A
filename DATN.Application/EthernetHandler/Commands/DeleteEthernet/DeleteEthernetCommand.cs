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
        public int Id { get; set; }

        public DeleteEthernetCommand(int id)
        {
            Id = id;
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
            await _EthernetRepository.BDeleteByIdAsync(request.Id);
            return BResult.Success();
        }
    }
}
