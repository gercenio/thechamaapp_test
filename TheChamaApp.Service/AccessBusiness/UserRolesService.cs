using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Application.Application;
using TheChamaApp.Application.IApplication;

namespace TheChamaApp.Service.AccessBusiness
{
    public class UserRolesService : Base.ServiceBase
    {
        #region # Propriedades
        private readonly IApplicationRoleApplication _RolesApplication;
        #endregion

        #region # Constructor
        public UserRolesService(IApplicationRoleApplication applicationRoleApplication)
        {
            _RolesApplication = applicationRoleApplication;
        }
        #endregion

        #region # Methods

        #endregion
    }
}
