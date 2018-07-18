using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Application.IApplication;

namespace TheChamaApp.Service.CompanyBusiness
{
    public class CompanyService
    {
        #region # Propriedades

        private readonly ICompanyApplication _ICompanyApplication;
        private readonly ICompanyAddressApplication _ICompanyAddressApplication;
        private readonly ICompanyContactApplication _ICompanyContactApplication;

        #endregion


        #region # Constructor

        public CompanyService(ICompanyApplication company
            , ICompanyAddressApplication companyAddress
            , ICompanyContactApplication companyContact)
        {
            _ICompanyApplication = company;
            _ICompanyAddressApplication = companyAddress;
            _ICompanyContactApplication = companyContact;
        }

        #endregion
    }
}
