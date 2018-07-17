using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheChamaApp.Application.IApplication;

namespace TheChamaApp.Presentation.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Company")]
    public class CompanyController : Controller
    {
        private readonly ICompanyApplication _ICompanyApplication;

        public CompanyController(ICompanyApplication companyApplication)
        {
            _ICompanyApplication = companyApplication;
        }

        [HttpGet]
        [Authorize("Bearer")]
        public IEnumerable<Domain.Entities.Company> GetAll()
        {
            return _ICompanyApplication.GetAll();
        }

    }
}