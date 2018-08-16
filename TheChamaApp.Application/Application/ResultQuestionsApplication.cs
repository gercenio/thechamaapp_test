using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Application.IApplication;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Service;

namespace TheChamaApp.Application.Application
{
    public class ResultQuestionsApplication : Base.AppServiceBase<ResultQuestions>, IResultQuestionsApplication
    {
        #region # Propriedades
        private readonly IResultQuestionsService _Service;
        #endregion

        #region # Constructor
        public ResultQuestionsApplication(IResultQuestionsService service) : base(service)
        {
            _Service = service;
        }
        #endregion

    }
}
