using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Domain.Interfaces.Repository;

namespace TheChamaApp.Domain.Services
{
    public class ApplicationRoleService : Base.Service<Entities.ApplicationRole>
    {
        private readonly IApplicationRoleRepository _Repository;

        public ApplicationRoleService(IApplicationRoleRepository repository) : base(repository)
        {
            _Repository = repository;
        }
    }
}
