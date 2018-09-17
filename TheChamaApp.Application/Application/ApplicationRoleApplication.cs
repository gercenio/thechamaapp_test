using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Domain.Interfaces.Service;

namespace TheChamaApp.Application.Application
{
    public class ApplicationRoleApplication : Base.AppServiceBase<Domain.Entities.ApplicationRole>
    {
        #region # Propriedades
        private readonly IApplicationRoleService _Service;
        #endregion

        #region # Constructor
        public ApplicationRoleApplication(IApplicationRoleService service) : base(service)
        {
            _Service = service;
        }
        #endregion

    }
}
