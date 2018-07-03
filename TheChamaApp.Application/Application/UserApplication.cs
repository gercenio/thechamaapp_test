using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Application.IApplication;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Service;

namespace TheChamaApp.Application.Application
{
    public class UserApplication : Base.AppServiceBase<User>, IUserApplication
    {
        #region # Private Members
        private readonly IUserService _Service;
        #endregion

        public UserApplication(IUserService service) : base(service)
        {
            _Service = service;
        }
    }
}
