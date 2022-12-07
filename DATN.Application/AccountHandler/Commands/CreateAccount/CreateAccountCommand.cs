﻿using DATN.Application.Mapper;
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
		public int Role { get; set; }
		public string Imei { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		public bool IsDeleted { get; set; }
		public DateTime TimingCreate { get; set; }
		public DateTime TimingUpdate { get; set; }
		public DateTime TimingDelete { get; set; }

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
			var result= await _accRepository.AddAccountAsync(entity);
			if (result == null) {
				if (request.Role > 2)
				{
					return BResult.Failure("quyền không hợp lệ: user:2, admin:1");
				}
				else if (request.Role == 2 && request.Imei == "")
				{
					return BResult.Failure("số Imei của user không được phép để trống ");

				}
				else if (request.Role == 2) { 
					return BResult.Failure("số Imei đã tồn tại ");
				}
				else if (request.Role <2)
				{
					return BResult.Failure("số Imei của admin phải đề trống");
				}
			}

			return BResult.Success();
		}
	}
}
