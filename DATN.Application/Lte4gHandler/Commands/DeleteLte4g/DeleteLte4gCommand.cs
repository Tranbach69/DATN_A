using DATN.Application.Models;
using DATN.Infastructure.Repositories.Lte4gRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.Lte4gHandler.Commands.DeleteLte4g
{
    public class DeleteLte4gCommand : IRequest<BResult>
    {
        public int Id { get; set; }

        public DeleteLte4gCommand(int id)
        {
            Id = id;
        }
    }

    public class DeleteLte4gCommandHandler : IRequestHandler<DeleteLte4gCommand, BResult>
    {
        private readonly ILte4gRepository _Lte4gRepository;

        public DeleteLte4gCommandHandler(ILte4gRepository lte4gRepository)
        {
            _Lte4gRepository = lte4gRepository;
        }

        public async Task<BResult> Handle(DeleteLte4gCommand request, CancellationToken cancellationToken)
        {
            await _Lte4gRepository.BDeleteByIdAsync(request.Id);
            return BResult.Success();
        }
    }
}
