using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Domain.Interfaces.Repository;

namespace TheChamaApp.Domain.Services
{
    public class AnswerService : Base.Service<Entities.Answer>, Interfaces.Service.IAnswerService
    {
        private readonly IAnswerRepository _Repository;

        public AnswerService(IAnswerRepository repository) :base(repository) {
            _Repository = repository;
        }

    }
}
