using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheChamaApp.Application.IApplication;

namespace TheChamaApp.Presentation.WebApi.Controllers
{

    [Route("api/[controller]")]
    public class MailController : Controller
    {
        private readonly IEmailSender _emailSender;

        public MailController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        [HttpPost]
        public async Task TestAction()
        {
            await _emailSender.SendEmailAsync("test@gmail.com", "subject",
                         $"Enter email body here");
        }
    }
}