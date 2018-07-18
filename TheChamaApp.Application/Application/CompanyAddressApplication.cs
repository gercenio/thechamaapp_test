using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Application.IApplication;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Service;

namespace TheChamaApp.Application.Application
{
    public class CompanyAddressApplication : Base.AppServiceBase<CompanyAddress> , ICompanyAddressApplication
    {
        private readonly ICompanyAddressService _ICompanyAddressService;

        public CompanyAddressApplication(ICompanyAddressService service) : base(service)
        {
            _ICompanyAddressService = service;
        }
    }
}
