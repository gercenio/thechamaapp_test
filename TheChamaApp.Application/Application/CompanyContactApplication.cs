using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Application.IApplication;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Service;

namespace TheChamaApp.Application.Application
{
    public class CompanyContactApplication : Base.AppServiceBase<CompanyContact>, ICompanyContactApplication
    {
        #region # Propriedades
        private readonly ICompanyContactService _Service;
        #endregion

        #region # Constructor

        public CompanyContactApplication(ICompanyContactService company) : base(company)
        {
            _Service = company;
        }

        #endregion

    }
}
