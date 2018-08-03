using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Application.IApplication;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Service;

namespace TheChamaApp.Application.Application
{
    public class RellationshipQuestionsToAskApplication : Base.AppServiceBase<RellationshipQuestionsToAsk>, IRellationshipQuestionsToAskApplication
    {
        public readonly IRellationshipQuestionsToAskService _Service;

        public RellationshipQuestionsToAskApplication(IRellationshipQuestionsToAskService service) : base(service)
        {
            _Service = service;
        }

    }
}
