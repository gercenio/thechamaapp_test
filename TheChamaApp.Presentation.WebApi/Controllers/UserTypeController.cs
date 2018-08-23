using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TheChamaApp.Presentation.WebApi.Controllers
{
    
    [Route("api/[controller]")]
    public class UserTypeController : BaseController
    {

        /// <summary>
        /// Obtem uma lista de Tipos de Usuario
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize("Bearer")]
        public IActionResult Get()
        {
            return Ok(Enum.GetValues(typeof(Domain.Util.LoginType)).Cast<Domain.Util.LoginType>().Select(v => v.ToString()).ToList());
        }
    }
}