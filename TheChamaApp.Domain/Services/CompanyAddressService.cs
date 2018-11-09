using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Repository;
using TheChamaApp.Domain.Interfaces.Service;

namespace TheChamaApp.Domain.Services
{
    public class CompanyAddressService : Base.Service<CompanyAddress>, ICompanyAddressService
    {
        #region Propriedades
        private readonly ICompanyAddressRepository _Repository;
        #endregion

        #region # Constructor
        public CompanyAddressService(ICompanyAddressRepository repository) : base(repository)
        {
            _Repository = repository;
        }
        #endregion

    }
}
