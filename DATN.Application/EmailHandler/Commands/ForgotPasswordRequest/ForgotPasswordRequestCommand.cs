using DATN.Application.Models;
using DATN.Infastructure.Repositories.DeviceRepository;
using DATN.Infastructure.Repositories.EmailRepository;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.EmailHandler.Commands.ForgotPasswordRequest
{
    public class ForgotPasswordRequestCommand : IRequest<BResult>
    {
        public string ToEmail { get; set; }
    }
    public class EmailRequestCommandHandler : IRequestHandler<ForgotPasswordRequestCommand, BResult>
    {
        private readonly IEmailService _emailService;
        private readonly IDeviceRepository _deviceRepository;


        public EmailRequestCommandHandler(IEmailService emailService, IDeviceRepository deviceRepository)
        {
            _emailService = emailService;
            _deviceRepository = deviceRepository;

        }
        public async Task<BResult> Handle(ForgotPasswordRequestCommand request, CancellationToken cancellationToken)
        {
            var checkEmail = _deviceRepository.ChangePasswordAsync(request.ToEmail);
            string afterCheckEmail = checkEmail.Result;
            if(afterCheckEmail== "không tồn tại Email")
            {
                return BResult.Failure("Email không tồn tại,kiểm tra lại Email");

            }
            if (afterCheckEmail == "không tồn tại Imei")
            {
                return BResult.Failure("Imei không tồn tại");
            }
            try
            {
                await _emailService.ForgotPassWordAsync(request.ToEmail, afterCheckEmail);
                return BResult.Success();
            }
            catch (Exception ex)
            {

                return BResult.Failure(ex.ToString());
            }
        }
    }
}
