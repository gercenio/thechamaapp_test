using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Repository;
using TheChamaApp.Domain.Interfaces.Service;

namespace TheChamaApp.Domain.Services
{
    public class RellationshipAskToAnswerService : Base.Service<RellationshipAskToAnswer>, IRellationshipAskToAnswerService
    {
        private readonly IRellationshipAskToAnswerRepository _Repository;

        public RellationshipAskToAnswerService(IRellationshipAskToAnswerRepository repository) : base(repository)
        {
            _Repository = repository;
        }

    }
}
