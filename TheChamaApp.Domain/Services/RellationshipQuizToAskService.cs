using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Repository;
using TheChamaApp.Domain.Interfaces.Service;

namespace TheChamaApp.Domain.Services
{
    public class RellationshipQuizToAskService : Base.Service<RellationshipQuizToAsk>, IRellationshipQuizToAskService
    {
        #region # Propriedades
        private readonly IRellationshipQuizToAskRepository _Repository;
        #endregion

        #region # Constructor
        public RellationshipQuizToAskService(IRellationshipQuizToAskRepository repository) :base(repository)
        {
            _Repository = repository;
        }
        #endregion
    }
}
