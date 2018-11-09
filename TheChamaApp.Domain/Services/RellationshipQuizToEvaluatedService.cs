using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Repository;
using TheChamaApp.Domain.Interfaces.Service;

namespace TheChamaApp.Domain.Services
{
    public class RellationshipQuizToEvaluatedService : Base.Service<RellationshipQuizToEvaluated> , IRellationshipQuizToEvaluatedService
    {
        private readonly IRellationshipQuizToEvaluatedRepository _Repository;

        public RellationshipQuizToEvaluatedService(IRellationshipQuizToEvaluatedRepository repository) : base(repository) {
            _Repository = repository;
        }
    }
}
