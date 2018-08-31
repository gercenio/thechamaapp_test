using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Repository;
using TheChamaApp.Domain.Interfaces.Service;

namespace TheChamaApp.Domain.Services
{
    public class QuizResultService : Base.Service<QuizResult>, IQuizResultService
    {
        #region # Propriedades
        private readonly IQuizResultRepository _Repository;
        #endregion

        #region # Constructor
        public QuizResultService(IQuizResultRepository repository) : base(repository)
        {
            _Repository = repository;
        }
        #endregion

    }
}
