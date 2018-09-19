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
    public class RellationshipQuizToAskController : BaseController
    {
        #region # Propriedades
        private readonly IRellationshipQuizToAskApplication _IRellationshipQuizToAskApplication;
        #endregion

        #region # Constructor
        public RellationshipQuizToAskController(IRellationshipQuizToAskApplication rellationshipQuizToAskApplication)
        {
            _IRellationshipQuizToAskApplication = rellationshipQuizToAskApplication;
        }
        #endregion

        #region # Actions

        /// <summary>
        /// Inclusão de novo relacionamento
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize("Bearer")]
        public IActionResult Post([FromBody]Domain.Entities.RellationshipQuizToAsk Entity)
        {
            try
            {
                using (TheChamaApp.Service.QuizBusiness.RellationshipQuizToAskService RellationBO = new Service.QuizBusiness.RellationshipQuizToAskService(_IRellationshipQuizToAskApplication))
                {
                    RellationBO.Incluir(Entity, out Mensagem);
                }
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex);
            }
            return Ok(Mensagem);
        }

        /// <summary>
        /// Realiza a alteração de uma relacionamento
        /// </summary>
        /// <param name="RellationshipQuizToAskId"></param>
        /// <param name="Entity"></param>
        /// <returns></returns>
        [HttpPut("{RellationshipQuizToAskId}")]
        [Authorize("Bearer")]
        public IActionResult Put(int RellationshipQuizToAskId, [FromBody]Domain.Entities.RellationshipQuizToAsk Entity)
        {
            try
            {
                using (TheChamaApp.Service.QuizBusiness.RellationshipQuizToAskService RellationBO = new Service.QuizBusiness.RellationshipQuizToAskService(_IRellationshipQuizToAskApplication))
                {
                    RellationBO.Alterar(RellationshipQuizToAskId, Entity, out Mensagem);
                }
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex);
            }
            return Ok(Mensagem);
        }

        /// <summary>
        /// Realiza a exclusão de um relacionamento
        /// </summary>
        /// <param name="RellationshipQuizToAskId"></param>
        /// <returns></returns>
        [HttpDelete("{RellationshipQuizToAskId}")]
        [Authorize("Bearer")]
        public IActionResult Delete(int RellationshipQuizToAskId)
        {
            try
            {
                using (TheChamaApp.Service.QuizBusiness.RellationshipQuizToAskService RellationBO = new Service.QuizBusiness.RellationshipQuizToAskService(_IRellationshipQuizToAskApplication))
                {
                    RellationBO.Excluir(RellationshipQuizToAskId, out Mensagem);
                }
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