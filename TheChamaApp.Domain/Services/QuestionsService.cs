using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Repository;
using TheChamaApp.Domain.Interfaces.Service;

namespace TheChamaApp.Domain.Services
{
    public class QuestionsService : Base.Service<Questions>, IQuestionsService
    {
        #region # Propriedades
        private readonly IQuestionsRepository _Repository;
        #endregion

        #region # Constructor

        public QuestionsService(IQuestionsRepository repository): base(repository)
        {
            _Repository = repository;
        }

        #endregion
    }
}
