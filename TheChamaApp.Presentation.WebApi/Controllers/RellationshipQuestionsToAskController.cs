using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheChamaApp.Application.IApplication;

namespace TheChamaApp.Presentation.WebApi.Controllers
{
    public class RellationshipQuestionsToAskController : BaseController
    {
        #region # Propriedades
        private readonly IRellationshipQuestionsToAskApplication _IRellationshipQuestionsToAskApplication;
        #endregion

        #region # Constructor

        public RellationshipQuestionsToAskController(IRellationshipQuestionsToAskApplication rellationshipQuestionsToAskApplication)
        {
            _IRellationshipQuestionsToAskApplication = rellationshipQuestionsToAskApplication;
        }

        #endregion

        #region # Actions

        [HttpPost]
        [Authorize("Bearer")]
        public IActionResult Post([FromBody]Domain.Entities.RellationshipQuestionsToAsk Entity)
        {
            try
            {
                if (ModelState.IsValid)
                {

                }
                else {
                    Mensagem = "invalid data !!!";
                }
                return Ok(Mensagem);
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex);
            }
        }
        #endregion
    }
}
