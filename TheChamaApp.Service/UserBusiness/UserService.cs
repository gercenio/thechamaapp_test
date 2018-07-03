using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Application.IApplication;
using System.Linq;

namespace TheChamaApp.Service.UserBusiness
{
    public class UserService : Base.ServiceBase
    {
        #region # Propriedades
        private readonly IUserApplication _UserApplication;
        #endregion

        #region # Constructor
        public UserService(IUserApplication application)
        {
            _UserApplication = application;
        }
        #endregion

        #region # Methods

        /// <summary>
        /// Get User By Code
        /// </summary>
        /// <param name="UserCode"></param>
        /// <returns></returns>
        public Domain.Entities.User GetByCode(string UserCode)
        {
            return _UserApplication.GetAll().Where(m => m.UserCode == UserCode).Single();
        }

        #endregion
    }
}
