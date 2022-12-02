using DATN.Application.Mapper;
using DATN.Application.Models;
using DATN.Core.Entities;
using DATN.Infastructure.Repositories.AccountRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.AccountHandler.Commands.CreateAccount
{
	public class CreateAccountCommand : IRequest<BResult>
	{
		public string UserName { get; set; }
		public string Password { get; set; }
		public string Permission { get; set; }

	}
	public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, BResult>
	{
		private readonly IAccountRepository _accRepository;

		public CreateAccountCommandHandler(IAccountRepository accRepository)
		{
			_accRepository = accRepository;
		}

		public async Task<BResult> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
		{
			var entity = AccountMapper.Mapper.Map<Account>(request);
			await _accRepository.BAddAsync(entity);
			return BResult.Success();
		}
	}
}
