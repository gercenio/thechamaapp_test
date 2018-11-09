using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Application.IApplication;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Service;

namespace TheChamaApp.Application.Application
{
    public class QuizResultApplication : Base.AppServiceBase<QuizResult>, IQuizResultApplication
    {
        private readonly IQuizResultService _Service;

        public QuizResultApplication(IQuizResultService service) : base(service)
        {
            _Service = service;
        }

    }
}
