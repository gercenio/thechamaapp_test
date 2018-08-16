using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Repository;
using TheChamaApp.Domain.Interfaces.Service;

namespace TheChamaApp.Domain.Services
{
    public class RellationshipCompanyUnityToQuestionsService : Base.Service<RellationshipCompanyUnityToQuestions>, IRellationshipCompanyUnityToQuestionsService
    {
        #region # Propriedades
        private readonly IRellationshipCompanyUnityToQuestionsRepository _Repository;
        #endregion

        #region # Constructor
        public RellationshipCompanyUnityToQuestionsService(IRellationshipCompanyUnityToQuestionsRepository repository) : base(repository)
        {
            _Repository = repository;
        }
        #endregion
    }
}
