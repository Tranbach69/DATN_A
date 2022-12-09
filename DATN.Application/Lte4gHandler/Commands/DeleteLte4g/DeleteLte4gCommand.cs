using DATN.Application.Models;
using DATN.Infastructure.Repositories.Lte4gRepository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.Lte4gHandler.Commands.DeleteLte4g
{
    public class DeleteLte4gCommand : IRequest<BResult>
    {
        public string Imei { get; set; }

        public DeleteLte4gCommand(string imei)
        {
            Imei = imei;
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
            var result = await _Lte4gRepository.BDeleteByImeiAsync(request.Imei);
            if (result == null)
            {
                return BResult.Failure("imei không tồn tại");
            }
            return BResult.Success();
        }
    }
}
