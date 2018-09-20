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
    /// <summary>
    /// Realiza o relacionamento entre os avaliados e seus superiores
    /// </summary>
    [Route("api/[controller]")]
    public class RellationshipEvaluatedToUpEvaluatedController : BaseController
    {
        #region # Propriedades

        private readonly IRellationshipEvaluatedToUpEvaluatedApplication _RellationshipEvaluatedToUpEvaluatedApplication;

        #endregion

        #region # Constructor

        public RellationshipEvaluatedToUpEvaluatedController(IRellationshipEvaluatedToUpEvaluatedApplication rellationshipEvaluatedToUpEvaluatedApplication)
        {
            _RellationshipEvaluatedToUpEvaluatedApplication = rellationshipEvaluatedToUpEvaluatedApplication;
        }

        #endregion

        #region # Actions

        /// <summary>
        /// Realiza a inclusão dos dados
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize("Bearer")]
        public IActionResult Post([FromBody]Domain.Entities.RellationshipEvaluatedToUpEvaluated Entity)
        {
            
            using (TheChamaApp.Service.EvaluatedBusiness.RellationshipEvaluatedToUpEvaluatedService RellationBO = new Service.EvaluatedBusiness.RellationshipEvaluatedToUpEvaluatedService(_RellationshipEvaluatedToUpEvaluatedApplication))
            {
                try
                {
                    RellationBO.Incluir(Entity, out Mensagem);
                }
                catch (Exception Ex)
                {
                    return BadRequest(Ex);
                }
                return Ok(Mensagem);
            }
        }

        /// <summary>
        /// Realiza a busca dos dados
        /// </summary>
        /// <param name="RellationshipEvaluatedToUpEvaluatedId"></param>
        /// <returns></returns>
        [HttpGet("{EvaluatedId}")]
        [Authorize("Bearer")]
        public IActionResult Get(int EvaluatedId)
        {
            using (TheChamaApp.Service.EvaluatedBusiness.RellationshipEvaluatedToUpEvaluatedService RellationBO = new Service.EvaluatedBusiness.RellationshipEvaluatedToUpEvaluatedService(_RellationshipEvaluatedToUpEvaluatedApplication))
            {
                try
                {
                    return Ok(RellationBO.ObterByEvaluatedId(EvaluatedId));
                }
                catch (Exception Ex)
                {
                    return BadRequest(Ex);
                }
                
            }
        }

        /// <summary>
        /// Realiza a exclusão de dados
        /// </summary>
        /// <param name="RellationshipEvaluatedToUpEvaluatedId"></param>
        /// <returns></returns>
        [HttpDelete("{RellationshipEvaluatedToUpEvaluatedId}")]
        [Authorize("Bearer")]
        public IActionResult Delete(int RellationshipEvaluatedToUpEvaluatedId)
        {
            using (TheChamaApp.Service.EvaluatedBusiness.RellationshipEvaluatedToUpEvaluatedService RellationBO = new Service.EvaluatedBusiness.RellationshipEvaluatedToUpEvaluatedService(_RellationshipEvaluatedToUpEvaluatedApplication))
            {
                try
                {
                    RellationBO.Excluir(RellationshipEvaluatedToUpEvaluatedId, out Mensagem);
                }
                catch (Exception Ex)
                {
                    return BadRequest(Ex);
                }
                return Ok(Mensagem);
            }
        }

        /// <summary>
        /// Realiza as alterações dos dados
        /// </summary>
        /// <param name="RellationshipEvaluatedToUpEvaluatedId"></param>
        /// <param name="Entity"></param>
        /// <returns></returns>
        [HttpPut("{RellationshipEvaluatedToUpEvaluatedId}")]
        [Authorize("Bearer")]
        public IActionResult Put(int RellationshipEvaluatedToUpEvaluatedId, [FromBody]Domain.Entities.RellationshipEvaluatedToUpEvaluated Entity)
        {
            using (TheChamaApp.Service.EvaluatedBusiness.RellationshipEvaluatedToUpEvaluatedService RellationBO = new Service.EvaluatedBusiness.RellationshipEvaluatedToUpEvaluatedService(_RellationshipEvaluatedToUpEvaluatedApplication))
            {
                try
                {
                    RellationBO.Alterar(RellationshipEvaluatedToUpEvaluatedId,Entity, out Mensagem);
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