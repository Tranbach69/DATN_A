using DATN.Application.Models;
using DATN.Infastructure.Repositories.AccountRepository;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.AccountHandler.Commands.UpdateAccount
{
    public class UpdateAccountCommand : IRequest<BResult>
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }

    public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand, BResult>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UpdateAccountCommandHandler(IAccountRepository accountRepository, IHttpContextAccessor httpContextAccessor)
        {
            _accountRepository = accountRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<BResult> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            var currentUserIdLogged = Int32.Parse(_httpContextAccessor.HttpContext.User.FindFirst(BClaimType.Id)?.Value);
            var user = await _accountRepository.BFistOrDefaultAsync(a => a.Id == currentUserIdLogged && a.Password == request.OldPassword);
            if (user == null)
            {
                return BResult.Failure("Mật khẩu cũ không chính xác");
            }
            await _accountRepository.ChangePassword(currentUserIdLogged, request.OldPassword, request.NewPassword);
            return BResult.Success();
        }
    }
}
