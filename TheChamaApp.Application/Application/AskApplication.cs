using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Application.IApplication;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Service;

namespace TheChamaApp.Application.Application
{
    public class AskApplication : Base.AppServiceBase<Ask>, IAskApplication
    {
        private readonly IAskService _Service;

        public AskApplication(IAskService service) : base(service)
        {
            _Service = service;
        }
    }
}
