using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Application.IApplication;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Service;

namespace TheChamaApp.Application.Application
{
    public class RellationshipQuizToAskApplication : Base.AppServiceBase<RellationshipQuizToAsk>, IRellationshipQuizToAskApplication
    {
        private readonly IRellationshipQuizToAskService _Service;

        public RellationshipQuizToAskApplication(IRellationshipQuizToAskService service) : base(service)
        {
            _Service = service;
        }
    }
}
