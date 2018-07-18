using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Repository;
using TheChamaApp.Domain.Interfaces.Service;

namespace TheChamaApp.Domain.Services
{
    public class CompanyContactService : Base.Service<CompanyContact>, ICompanyContactService
    {
        #region # Propriedades
        private readonly ICompanyContactRepository _Repository;
        #endregion

        #region # Constructor
        public CompanyContactService(ICompanyContactRepository repository) : base(repository)
        {
            _Repository = repository;
        }
        #endregion

    }
}
