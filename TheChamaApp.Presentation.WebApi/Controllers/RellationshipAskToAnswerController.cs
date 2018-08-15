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
    public class RellationshipAskToAnswerController : BaseController
    {
        #region # Propriedades
        private readonly IRellationshipAskToAnswerApplication _IRellationshipAskToAnswerApplication;
        #endregion

        #region # Constructor
        public RellationshipAskToAnswerController(IRellationshipAskToAnswerApplication rellationshipAskToAnswerApplication)
        {
            _IRellationshipAskToAnswerApplication = rellationshipAskToAnswerApplication;
        }
        #endregion

        #region # Actions

        /// <summary>
        /// Realiza a inclusão de um relacionamento
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Authorize("Bearer")]
        public IActionResult Post([FromBody]Domain.Entities.RellationshipAskToAnswer Entity)
        {

            using (TheChamaApp.Service.AskBusiness.RellationshipAskToAnswerService RellationBO = new Service.AskBusiness.RellationshipAskToAnswerService(_IRellationshipAskToAnswerApplication))
            {
                try
                {
                    RellationBO.Incluir(Entity, out Mensagem);
                    return Ok(Mensagem);
                }
                catch (Exception Ex)
                {
                    return BadRequest(Ex);
                }
            }
    
        }

        /// <summary>
        /// Realiza a exclusão de um registro
        /// </summary>
        /// <param name="RellationshipAskToAnswerId"></param>
        [HttpDelete]
        [Authorize("Bearer")]
        public IActionResult Delete(int RellationshipAskToAnswerId)
        {
            using (TheChamaApp.Service.AskBusiness.RellationshipAskToAnswerService RellationBO = new Service.AskBusiness.RellationshipAskToAnswerService(_IRellationshipAskToAnswerApplication))
            {
                try
                {
                    RellationBO.Excluir(RellationshipAskToAnswerId, out Mensagem);
                    return Ok(Mensagem);
                }
                catch (Exception Ex)
                {
                    return BadRequest(Ex);
                }
            }
        }

        #endregion
    }
}