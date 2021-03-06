﻿using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Repository;
using TheChamaApp.Domain.Interfaces.Service;

namespace TheChamaApp.Domain.Services
{
    public class QuizService : Base.Service<Quiz>, IQuizService
    {
        #region # Propriedades
        private readonly IQuizRepository _Repository;
        #endregion

        #region # Constructor
        public QuizService(IQuizRepository repository) : base(repository)
        {
            _Repository = repository;
        }
        #endregion
    }
}
