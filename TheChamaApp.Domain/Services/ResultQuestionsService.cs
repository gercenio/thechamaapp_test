using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Repository;
using TheChamaApp.Domain.Interfaces.Service;

namespace TheChamaApp.Domain.Services
{
    public class ResultQuestionsService : Base.Service<ResultQuestions>, IResultQuestionsService
    {
        #region # Propriedades
        private readonly IResultQuestionsRepository _Repository;
        #endregion

        #region # Constructor
        public ResultQuestionsService(IResultQuestionsRepository repository) : base(repository)
        {
            _Repository = repository;
        }
        #endregion
    }
}
