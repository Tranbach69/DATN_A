using DATN.Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DATN.Infastructure.Repositories.EmailRepository.EmailService;

namespace DATN.Infastructure.Repositories.EmailRepository
{
    public interface IEmailService
    {
        Task SendEmailAsync(string toEmail, string subject, List<IFormFile> attachments, string body);
        Task ForgotPassWordAsync(string toEmail, string body);

    }
}
