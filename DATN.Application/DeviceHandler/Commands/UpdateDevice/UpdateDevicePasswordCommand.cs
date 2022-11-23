using DATN.Application.Models;
using DATN.Infastructure.Repositories.DeviceRepository;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.DeviceHandler.Commands.UpdateDevice
{
    public class UpdateDevicePasswordCommand : IRequest<BResult>
    {
      
        public int Id { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }       
    }

    public class UpdateDevicePasswordCommandHandler : IRequestHandler<UpdateDevicePasswordCommand, BResult>
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UpdateDevicePasswordCommandHandler(IDeviceRepository deviceRepository, IHttpContextAccessor httpContextAccessor)
        {
            _deviceRepository = deviceRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<BResult> Handle(UpdateDevicePasswordCommand request, CancellationToken cancellationToken)
        {
            //var currentDeviceIdLogged = Int32.Parse(_httpContextAccessor.HttpContext.User.FindFirst(BClaimType.Id)?.Value);
            //var currentDeviceIdLogged = re;
            var device = await _deviceRepository.BFistOrDefaultAsync(a => a.Id == request.Id && a.Password == request.OldPassword);
			if (device == null)
			{
				return BResult.Failure("Mật khẩu cũ không chính xác");
			}
			await _deviceRepository.ChangePassword(request.Id, request.OldPassword, request.NewPassword);
            return BResult.Success();
        }
    }
}
