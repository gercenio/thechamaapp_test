using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Repository;
using TheChamaApp.Domain.Interfaces.Service;

namespace TheChamaApp.Domain.Services
{
    public class RellationshipQuestionsToAskService : Base.Service<RellationshipQuestionsToAsk>, IRellationshipQuestionsToAskService
    {
        private readonly IRellationshipQuestionsToAskRepository _Repository;

        public RellationshipQuestionsToAskService(IRellationshipQuestionsToAskRepository repository) : base(repository)
        {
            _Repository = repository;
        }

    }
}
