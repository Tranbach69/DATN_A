using DATN.Application.Models;
using DATN.Infastructure.Repositories.AccountRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.AccountHandler.Commands.DeleteAccount
{
    public class DeleteAccountCommand : IRequest<BResult>
    {
        public int Id { get; set; }

        public DeleteAccountCommand(int id)
        {
            Id = id;
        }
    }

    public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand, BResult>
    {
        private readonly IAccountRepository _accRepository;

        public DeleteAccountCommandHandler(IAccountRepository accRepository)
        {
            _accRepository = accRepository;
        }

        public async Task<BResult> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            await _accRepository.BDeleteByIdAsync(request.Id);
            return BResult.Success();
        }
    }
}
