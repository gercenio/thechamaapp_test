using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Application.IApplication;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Service;

namespace TheChamaApp.Application.Application
{
    public class RellationshipCompanyUnityToQuizApplication : Base.AppServiceBase<RellationshipCompanyUnityToQuiz>, IRellationshipCompanyUnityToQuizApplication
    {
        private readonly IRellationshipCompanyUnityToQuizService _Service;

        public RellationshipCompanyUnityToQuizApplication(IRellationshipCompanyUnityToQuizService service) : base(service)
        {
            _Service = service;
        }

    }
}
