using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Application.IApplication;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Service;

namespace TheChamaApp.Application.Application
{
    public class RellationshipCompanyUnityToQuestionsApplication : Base.AppServiceBase<RellationshipCompanyUnityToQuestions>, IRellationshipCompanyUnityToQuestionsApplication
    {
        private readonly IRellationshipCompanyUnityToQuestionsService _Service;

        public RellationshipCompanyUnityToQuestionsApplication(IRellationshipCompanyUnityToQuestionsService service) :base(service)
        {
            _Service = service;
        }

    }
}
