using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Repository;
using TheChamaApp.Domain.Interfaces.Service;

namespace TheChamaApp.Domain.Services
{
    public class LoginService : Base.Service<Login>, ILoginService
    {
        #region # Propriedades
        private readonly ILoginRepository _Repository;
        #endregion

        #region # Constructor
        public LoginService(ILoginRepository repository) : base(repository)
        {
            _Repository = repository;
        }
        #endregion
    }
}
