using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Application.IApplication;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Service;

namespace TheChamaApp.Application.Application
{
    public class StateApplication : Base.AppServiceBase<State>, IStateApplication
    {
        #region # Propriedades

        private readonly IStateService _Service;

        #endregion

        #region # Constructor

        public StateApplication(IStateService service) : base(service) {

            _Service = service;
        }

        #endregion

    }
}
