using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Application.IApplication;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Service;

namespace TheChamaApp.Application.Application
{
    public class RellationshipAskToAnswerApplication : Base.AppServiceBase<RellationshipAskToAnswer>, IRellationshipAskToAnswerApplication
    {
        private readonly IRellationshipAskToAnswerService _Service;

        public RellationshipAskToAnswerApplication(IRellationshipAskToAnswerService service): base(service)
        {
            _Service = service;
        }

    }
}
