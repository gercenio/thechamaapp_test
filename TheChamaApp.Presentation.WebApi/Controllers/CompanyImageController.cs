using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheChamaApp.Application.IApplication;

namespace TheChamaApp.Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class CompanyImageController : BaseController
    {
        #region # Propriedades
        private readonly ICompanyImageApplication _ICompanyImageApplication;
        #endregion

        #region # Constructor
        public CompanyImageController(ICompanyImageApplication companyImageApplication)
        {
            _ICompanyImageApplication = companyImageApplication;
        }
        #endregion
    }
}
