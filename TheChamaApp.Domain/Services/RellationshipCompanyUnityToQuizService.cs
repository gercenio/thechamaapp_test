using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Repository;
using TheChamaApp.Domain.Interfaces.Service;

namespace TheChamaApp.Domain.Services
{
    public class RellationshipCompanyUnityToQuizService : Base.Service<RellationshipCompanyUnityToQuiz>, IRellationshipCompanyUnityToQuizService
    {
        private readonly IRellationshipCompanyUnityToQuizRepository _Repository;

        public RellationshipCompanyUnityToQuizService(IRellationshipCompanyUnityToQuizRepository repository) : base(repository)
        {
            _Repository = repository;
        }

    }
}
