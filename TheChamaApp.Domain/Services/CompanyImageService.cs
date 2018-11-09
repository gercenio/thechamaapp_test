using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Repository;
using TheChamaApp.Domain.Interfaces.Service;

namespace TheChamaApp.Domain.Services
{
    public class CompanyImageService : Base.Service<CompanyImage>, ICompanyImageService
    {
        #region # Propriedades
        private readonly ICompanyImageRepository _Repository;
        #endregion

        #region # Constructor
        public CompanyImageService(ICompanyImageRepository repository) : base(repository)
        {
            _Repository = repository;
        }
        #endregion
    }
}
