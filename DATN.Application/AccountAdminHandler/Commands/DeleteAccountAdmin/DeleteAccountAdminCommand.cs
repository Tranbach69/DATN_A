using DATN.Application.Models;
using DATN.Infastructure.Repositories.AccountAdminRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.AccountAdminHandler.Commands.DeleteAccountAdmin
{
    public class DeleteAccountAdminCommand : IRequest<BResult>
    {
        public int Id { get; set; }

        public DeleteAccountAdminCommand(int id)
        {
            Id = id;
        }
    }

    public class DeleteAccountAdminCommandHandler : IRequestHandler<DeleteAccountAdminCommand, BResult>
    {
        private readonly IAccountAdminRepository _accAdRepository;

        public DeleteAccountAdminCommandHandler(IAccountAdminRepository accAdRepository)
        {
            _accAdRepository = accAdRepository;
        }

        public async Task<BResult> Handle(DeleteAccountAdminCommand request, CancellationToken cancellationToken)
        {
            await _accAdRepository.BDeleteByIdAsync(request.Id);
            return BResult.Success();
        }
    }
}
