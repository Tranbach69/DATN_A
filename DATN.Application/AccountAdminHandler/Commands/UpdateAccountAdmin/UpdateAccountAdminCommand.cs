using DATN.Application.Models;
using DATN.Infastructure.Repositories.AccountAdminRepository;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.AccountAdminHandler.Commands.UpdateAccountAdmin
{
    public class UpdateAccountAdminCommand : IRequest<BResult>
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }

    public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountAdminCommand, BResult>
    {
        private readonly IAccountAdminRepository _accountAdminRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UpdateAccountCommandHandler(IAccountAdminRepository accountAdminRepository, IHttpContextAccessor httpContextAccessor)
        {
            _accountAdminRepository = accountAdminRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<BResult> Handle(UpdateAccountAdminCommand request, CancellationToken cancellationToken)
        {
            var currentUserIdLogged = Int32.Parse(_httpContextAccessor.HttpContext.User.FindFirst(BClaimType.Id)?.Value);
            var user = await _accountAdminRepository.BFistOrDefaultAsync(a => a.Id == currentUserIdLogged && a.Password == request.OldPassword);
            if (user == null)
            {
                return BResult.Failure("Mật khẩu cũ không chính xác");
            }
            await _accountAdminRepository.ChangePassword(currentUserIdLogged, request.OldPassword, request.NewPassword);
            return BResult.Success();
        }
    }
}
