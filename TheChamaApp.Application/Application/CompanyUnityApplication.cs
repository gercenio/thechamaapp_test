using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Application.IApplication;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Service;

namespace TheChamaApp.Application.Application
{
    public class CompanyUnityApplication : Base.AppServiceBase<CompanyUnity>, ICompanyUnityApplication
    {
        private readonly ICompanyUnityService _Service;

        public CompanyUnityApplication(ICompanyUnityService company) : base(company)
        {
            _Service = company;
        }
    }
}
