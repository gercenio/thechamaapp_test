using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Application.IApplication;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Service;

namespace TheChamaApp.Application.Application
{
    public class CompanyApplication : Base.AppServiceBase<Company> , ICompanyApplication
    {
        private readonly ICompanyService _Service;

        public CompanyApplication(ICompanyService company) : base(company) {
            _Service = company;
        }
    }
}
