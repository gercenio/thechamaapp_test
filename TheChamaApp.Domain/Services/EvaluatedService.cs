using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Repository;
using TheChamaApp.Domain.Interfaces.Service;

namespace TheChamaApp.Domain.Services
{
    public class EvaluatedService : Base.Service<Evaluated>, IEvaluatedService
    {
        #region # Propriedades
        private readonly IEvaluatedRepository _Repository;
        #endregion

        #region # Constructor
        public EvaluatedService(IEvaluatedRepository repository) : base(repository)
        {
            _Repository = repository;
        }
        #endregion
    }
}
