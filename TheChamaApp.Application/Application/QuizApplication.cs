using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Application.IApplication;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Service;

namespace TheChamaApp.Application.Application
{
    public class QuizApplication : Base.AppServiceBase<Quiz>, IQuizApplication
    {
        private readonly IQuizService _Service;

        public QuizApplication(IQuizService service) : base(service)
        {
            _Service = service;
        }
    }
}
