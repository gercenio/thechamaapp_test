using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Application.IApplication;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Service;

namespace TheChamaApp.Application.Application
{
    public class RellationshipQuizToEvaluatedApplication : Base.AppServiceBase<RellationshipQuizToEvaluated>, IRellationshipQuizToEvaluatedApplication
    {
        private readonly IRellationshipQuizToEvaluatedService _Service;

        public RellationshipQuizToEvaluatedApplication(IRellationshipQuizToEvaluatedService service) : base(service) {
            _Service = service;
        }

    }
}
