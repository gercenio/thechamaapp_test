using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Application.IApplication;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Service;

namespace TheChamaApp.Application.Application
{
    public class QuestionsApplication : Base.AppServiceBase<Questions>, IQuestionsApplication
    {
        private readonly IQuestionsService _Service;

        public QuestionsApplication(IQuestionsService service) : base(service)
        {
            _Service = service;
        }
    }
}
