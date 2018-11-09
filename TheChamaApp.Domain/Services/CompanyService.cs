using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Repository;
using TheChamaApp.Domain.Interfaces.Service;

namespace TheChamaApp.Domain.Services
{
    public class CompanyService : Base.Service<Company> , ICompanyService
    {
        #region Propriedades
        private readonly ICompanyRepository _Repository;
        #endregion

        #region # Constructor
        public CompanyService(ICompanyRepository repository) : base(repository)
        {
            _Repository = repository;
        }
        #endregion
    }
}
