using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheChamaApp.Application.IApplication;

namespace TheChamaApp.Presentation.WebApi.Controllers
{
    public class AnswerController : BaseController
    {
        #region # Propriedades
        private readonly IAnswerApplication _IAnswerApplication;
        #endregion

        #region # Constructor
        public AnswerController(IAnswerApplication answerApplication)
        {
            _IAnswerApplication = answerApplication;
        }
        #endregion

        #region # Actions

        /// <summary>
        /// Realiza a inclusão de uma resposta
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize("Bearer")]
        public IActionResult Post([FromBody]Domain.Entities.Answer Entity)
        {
            using (TheChamaApp.Service.AnswerBusiness.AnswerService AnswerBO = new Service.AnswerBusiness.AnswerService(_IAnswerApplication))
            {
                try
                {
                    AnswerBO.Incluir(Entity,out Mensagem);
                }
                catch (Exception Ex)
                {
                    return BadRequest(Ex);
                }
                return Ok(Mensagem);
            }
        }

        #endregion

    }
}
