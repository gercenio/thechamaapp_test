using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Application.IApplication;

namespace TheChamaApp.Service.CompanyBusiness
{
    public class CompanyService
    {
        private readonly ICompanyApplication _ICompanyApplication;
        private readonly ICompanyAddressApplication _ICompanyAddressApplication;


        public CompanyService(ICompanyApplication company
            , ICompanyAddressApplication companyAddress)
        {
            _ICompanyApplication = company;
            _ICompanyAddressApplication = companyAddress;
        }
    }
}
