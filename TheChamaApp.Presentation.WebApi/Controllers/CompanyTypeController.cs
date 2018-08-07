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
    public class CompanyTypeController : Controller
    {
        #region # Propriedades
        private readonly ICompanyTypeApplication _ICompanyTypeApplication;
        #endregion

        #region # Constructor
        public CompanyTypeController(ICompanyTypeApplication rellationship)
        {
            _ICompanyTypeApplication = rellationship;
        }
        #endregion

        #region # Actions

        /// <summary>
        /// Retorna uma lista de tipos de empresa
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize("Bearer")]
        public IActionResult Get()
        {
            return Ok(_ICompanyTypeApplication.GetAll());
        }

        #endregion
    }
}