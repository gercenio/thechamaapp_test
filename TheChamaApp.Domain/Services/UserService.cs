using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Repository;
using TheChamaApp.Domain.Interfaces.Service;

namespace TheChamaApp.Domain.Services
{
    public class UserService : Base.Service<User> , IUserService
    {
        #region # Propriedades
        private readonly IUserRepository _Repository;
        #endregion

        #region # Constructor
        public UserService(IUserRepository repository) : base(repository)
        {
            _Repository = repository;
        }
        #endregion
    }
}
