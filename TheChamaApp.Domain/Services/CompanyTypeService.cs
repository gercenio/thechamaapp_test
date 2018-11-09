using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Repository;
using TheChamaApp.Domain.Interfaces.Service;

namespace TheChamaApp.Domain.Services
{
    public class CompanyTypeService : Base.Service<CompanyType>, ICompanyTypeService
    {
        private readonly ICompanyTypeRepository _IRepository;

        public CompanyTypeService(ICompanyTypeRepository repository) : base(repository) {
            _IRepository = repository;
        }
    }
}
