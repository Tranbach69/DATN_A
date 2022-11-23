using DATN.Application.Models;
using DATN.Infastructure.Repositories.DeviceRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.DeviceHandler.Commands.DeleteDevice
{
    public class DeleteDeviceCommand : IRequest<BResult>
    {
        public int Id { get; set; }

        public DeleteDeviceCommand(int id)
        {
            Id = id;
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
            await _deviceRepository.BDeleteByIdAsync(request.Id);
            return BResult.Success();
        }
    }
}
