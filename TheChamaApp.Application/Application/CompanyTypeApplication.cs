using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Application.IApplication;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Service;

namespace TheChamaApp.Application.Application
{
    public class CompanyTypeApplication : Base.AppServiceBase<CompanyType>, ICompanyTypeApplication
    {
        private readonly ICompanyTypeService _IService;

        public CompanyTypeApplication(ICompanyTypeService service) : base(service)
        {
            _IService = service;
        }
    }
}
