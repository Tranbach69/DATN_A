using DATN.Application.Models;
using DATN.Infastructure.Repositories.EmailRepository;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.EmailHandler.Commands.EmailRequest
{
    public class EmailRequestCommand : IRequest<BResult>
    {
            public string ToEmail { get; set; }
            public string Subject { get; set; }
            public string Body { get; set; }
            public List<IFormFile> Attachments { get; set; }
    }
    public class EmailRequestCommandHandler : IRequestHandler<EmailRequestCommand, BResult>
    {
        private readonly IEmailService _emailService;

        public EmailRequestCommandHandler(IEmailService emailService)
        {
            _emailService = emailService;
   
        }
        public async Task<BResult> Handle(EmailRequestCommand request, CancellationToken cancellationToken)
        {

            try
            {
                await _emailService.SendEmailAsync(request.ToEmail, request.Subject, request.Attachments, request.Body);
                return BResult.Success();
            }
            catch (Exception ex)
            {

                return BResult.Failure(ex.ToString());
            }
        }
    }
}
