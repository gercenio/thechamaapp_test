using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheChamaApp.Application.IApplication;

namespace TheChamaApp.Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
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

        /// <summary>
        /// Realiza a inclusão de uma relacionamento entre perguntas e respostas
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize("Bearer")]
        public IActionResult Post([FromBody]Domain.Entities.RellationshipQuestionsToAsk Entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (TheChamaApp.Service.QuestionsBusiness.RellationshipQuestionsToAskService RellationshipBO = new Service.QuestionsBusiness.RellationshipQuestionsToAskService(_IRellationshipQuestionsToAskApplication))
                    {
                        RellationshipBO.Incluir(Entity, out Mensagem);
                    }
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

        /// <summary>
        /// Realiza a alteração no relacionamento entre Perguntas e respostas
        /// </summary>
        /// <param name="RellationshipQuestionsToAskId"></param>
        /// <param name="Entity"></param>
        /// <returns></returns>
        [HttpPut]
        [Authorize("Bearer")]
        public IActionResult Put(int RellationshipQuestionsToAskId, [FromBody]Domain.Entities.RellationshipQuestionsToAsk Entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (TheChamaApp.Service.QuestionsBusiness.RellationshipQuestionsToAskService RellationshipBO = new Service.QuestionsBusiness.RellationshipQuestionsToAskService(_IRellationshipQuestionsToAskApplication))
                    {
                        RellationshipBO.Alterar(RellationshipQuestionsToAskId, Entity, out Mensagem);
                    }
                }
                else
                {
                    Mensagem = "invalid data !!!";
                }
                return Ok(Mensagem);
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex);
            }
        }

        [HttpDelete]
        [Authorize("Bearer")]
        public IActionResult Delete(int RellationshipQuestionsToAskId)
        {
            try
            {
                using (TheChamaApp.Service.QuestionsBusiness.RellationshipQuestionsToAskService RellationshipBO = new Service.QuestionsBusiness.RellationshipQuestionsToAskService(_IRellationshipQuestionsToAskApplication))
                {
                    RellationshipBO.Delete(RellationshipQuestionsToAskId,out Mensagem);
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
