using DATN.Application.Models;
using DATN.Infastructure.Repositories.WifiRepository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.WifiHandler.Commands.DeleteWifi
{
    public class DeleteWifiCommand : IRequest<BResult>
    {
        public string Imei { get; set; }

        public DeleteWifiCommand(string imei)
        {
            Imei = imei;
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
            var result = await _WifiRepository.BDeleteByImeiAsync(request.Imei);
            if (result == null)
            {
                return BResult.Failure("imei không tồn tại");
            }
            return BResult.Success();
        }
    }
}
