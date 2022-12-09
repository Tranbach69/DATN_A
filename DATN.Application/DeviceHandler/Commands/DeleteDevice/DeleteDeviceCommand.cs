using DATN.Application.Models;
using DATN.Infastructure.Repositories.DeviceRepository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.DeviceHandler.Commands.DeleteDevice
{
    public class DeleteDeviceCommand : IRequest<BResult>
    {
        public string Imei { get; set; }

        public DeleteDeviceCommand(string imei)
        {
            Imei = imei;
        }
    }

    public class DeleteDeviceCommandHandler : IRequestHandler<DeleteDeviceCommand, BResult>
    {
        private readonly IDeviceRepository _deviceRepository;

        public DeleteDeviceCommandHandler(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public async Task<BResult> Handle(DeleteDeviceCommand request, CancellationToken cancellationToken)
        {
            var result = await _deviceRepository.BDeleteByImeiAsync(request.Imei);
            if (result == null) { 
                return BResult.Failure("imei không tồn tại");
            }
            return BResult.Success();
        }
    }
}
