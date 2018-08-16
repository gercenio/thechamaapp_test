using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Repository;
using TheChamaApp.Domain.Interfaces.Service;

namespace TheChamaApp.Domain.Services
{
    public class LevelEvaluatedService : Base.Service<LevelEvaluated>, ILevelEvaluatedService
    {
        #region # Propriedades
        private readonly ILevelEvaluatedRepository _Repository;
        #endregion

        #region # Constructor
        public LevelEvaluatedService(ILevelEvaluatedRepository repository) : base(repository)
        {
            _Repository = repository;
        }
        #endregion

    }
}
