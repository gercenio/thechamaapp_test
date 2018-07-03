using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Repository.Base;

namespace TheChamaApp.Domain.Interfaces.Repository
{
    public interface IUserRepository : IRepository<User>
    {
    }
}
