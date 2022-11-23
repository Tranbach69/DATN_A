using DATN.Application.Mapper;
using DATN.Application.Models;
using DATN.Core.Entities;
using DATN.Infastructure.Repositories.AccountAdminRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.AccountAdminHandler.Commands.CreateAccountAdmin
{
	public class CreateAccountAdminCommand : IRequest<BResult>
	{

		
		public string UserName { get; set; }
		public string Password { get; set; }
		
	}
	public class CreateAccountAdminCommandHandler : IRequestHandler<CreateAccountAdminCommand, BResult>
	{
		private readonly IAccountAdminRepository _accAdRepository;

		public CreateAccountAdminCommandHandler(IAccountAdminRepository accAdRepository)
		{
			_accAdRepository = accAdRepository;
		}

		public async Task<BResult> Handle(CreateAccountAdminCommand request, CancellationToken cancellationToken)
		{
			var entity = AccountAdminMapper.Mapper.Map<AccountAdmin>(request);
			await _accAdRepository.BAddAsync(entity);
			return BResult.Success();
		}
	}
}
