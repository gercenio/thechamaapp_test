using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Application.IApplication;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Service;

namespace TheChamaApp.Application.Application
{
    public class RellationshipEvaluatedToUpEvaluatedApplication : Base.AppServiceBase<RellationshipEvaluatedToUpEvaluated>, IRellationshipEvaluatedToUpEvaluatedApplication
    {
        private readonly IRellationshipEvaluatedToUpEvaluatedService _Service;

        public RellationshipEvaluatedToUpEvaluatedApplication(IRellationshipEvaluatedToUpEvaluatedService service) : base(service)
        {
            _Service = service;
        }
    }
}
