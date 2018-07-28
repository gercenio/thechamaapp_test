using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Repository;
using TheChamaApp.Domain.Interfaces.Service;

namespace TheChamaApp.Domain.Services
{
    public class AskService : Base.Service<Ask>, IAskService
    {
        private readonly IAskRepository _IRepository;

        public AskService(IAskRepository repository) : base(repository)
        {
            _IRepository = repository;
        }
    }
}
