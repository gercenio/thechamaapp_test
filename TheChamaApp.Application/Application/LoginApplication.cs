using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Application.IApplication;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Service;

namespace TheChamaApp.Application.Application
{
    public class LoginApplication : Base.AppServiceBase<Login>, ILoginApplication
    {
        private readonly ILoginService _Service;

        public LoginApplication(ILoginService service) : base(service)
        {
            _Service = service;
        }
    }
}
