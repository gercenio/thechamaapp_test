using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Application.IApplication;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Service;

namespace TheChamaApp.Application.Application
{
    public class AnswerApplication : Base.AppServiceBase<Answer>, IAnswerApplication
    {
        private readonly IAnswerService _Service;

        public AnswerApplication(IAnswerService service) : base(service)
        {
            _Service = service;
        }

    }
}
