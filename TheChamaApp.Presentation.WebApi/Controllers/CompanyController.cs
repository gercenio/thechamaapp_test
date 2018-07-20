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


    [Route("api/[controller]")]
    public class CompanyController : Controller
    {
        #region # Propriedades

        private readonly ICompanyApplication _ICompanyApplication;

        #endregion

        #region # Constructor

        public CompanyController(ICompanyApplication companyApplication)
        {
            _ICompanyApplication = companyApplication;
        }

        #endregion

        #region # Actions

        [HttpGet]
        [Authorize("Bearer")]
        public IActionResult Get()
        {
            var List = _ICompanyApplication.GetAll();
            return Ok(List);
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize("Bearer")]
        public IActionResult Post([FromBody]Domain.Entities.Company Entity)
        {
            return Ok();
        }
        #endregion

    }
}