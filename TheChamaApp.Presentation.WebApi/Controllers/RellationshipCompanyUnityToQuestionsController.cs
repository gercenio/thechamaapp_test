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
    public class RellationshipCompanyUnityToQuestionsController : BaseController
    {
        #region # Propriedades
        private readonly IRellationshipCompanyUnityToQuestionsApplication _IRellationshipCompanyUnityToQuestionsApplication;
        #endregion

        #region # Constructor
        public RellationshipCompanyUnityToQuestionsController(IRellationshipCompanyUnityToQuestionsApplication rellationshipCompanyUnityToQuestionsApplication)
        {
            _IRellationshipCompanyUnityToQuestionsApplication = rellationshipCompanyUnityToQuestionsApplication;
        }
        #endregion

        #region # Actions

        [Authorize("Bearer")]
        public IActionResult Post([FromBody]Domain.Entities.Questions Entity)
        {
            try
            {

            }
            catch (Exception Ex)
            {
                return BadRequest(Ex);
            }
            return Ok(Mensagem);
        }
        #endregion

    }
}