using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TheChamaApp.Application.IApplication
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
