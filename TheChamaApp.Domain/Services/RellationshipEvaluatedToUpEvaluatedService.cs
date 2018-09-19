using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Repository;
using TheChamaApp.Domain.Interfaces.Service;

namespace TheChamaApp.Domain.Services
{
    public class RellationshipEvaluatedToUpEvaluatedService : Base.Service<RellationshipEvaluatedToUpEvaluated>, IRellationshipEvaluatedToUpEvaluatedService
    {
        private readonly IRellationshipEvaluatedToUpEvaluatedRepository _Repository;

        public RellationshipEvaluatedToUpEvaluatedService(IRellationshipEvaluatedToUpEvaluatedRepository repository) : base(repository)
        {
            _Repository = repository;
        }

    }
}
