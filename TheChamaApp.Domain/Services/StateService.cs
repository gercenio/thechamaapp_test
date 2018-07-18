using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Repository;
using TheChamaApp.Domain.Interfaces.Service;

namespace TheChamaApp.Domain.Services
{
    public class StateService : Base.Service<State>, IStateService
    {
        #region # Propriedades

        private readonly IStateRepository _Repository;

        #endregion

        #region # Constructor

        public StateService(IStateRepository repository) : base(repository) {
            _Repository = repository;
        }

        #endregion
    }
}
