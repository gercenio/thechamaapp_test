using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Application.IApplication;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Service;

namespace TheChamaApp.Application.Application
{
    public class CompanyImageApplication : Base.AppServiceBase<CompanyImage>, ICompanyImageApplication
    {
        private readonly ICompanyImageService _Service;

        public CompanyImageApplication(ICompanyImageService service) :base(service)
        {
            _Service = service;
        }
    }
}
