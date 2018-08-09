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

        /// <summary>
        /// Atualiza uma resposta
        /// </summary>
        /// <param name="AnswerId"></param>
        /// <param name="Entity"></param>
        /// <returns></returns>
        [HttpPut]
        [Authorize("Bearer")]
        public IActionResult Put(int AnswerId, [FromBody]Domain.Entities.Answer Entity)
        {
            using (TheChamaApp.Service.AnswerBusiness.AnswerService AnswerBO = new Service.AnswerBusiness.AnswerService(_IAnswerApplication))
            {
                try
                {
                    AnswerBO.Alterar(AnswerId, Entity, out Mensagem);
                }
                catch (Exception Ex)
                {

                    return BadRequest(Ex);
                }
                return Ok(Mensagem);
            }
        }

        /// <summary>
        /// Deleta uma resposta
        /// </summary>
        /// <param name="AnswerId"></param>
        /// <returns></returns>
        [HttpDelete("{AnswerId}")]
        [Authorize("Bearer")]
        public IActionResult Delete(int AnswerId)
        {
            using (TheChamaApp.Service.AnswerBusiness.AnswerService AnswerBO = new Service.AnswerBusiness.AnswerService(_IAnswerApplication))
            {
                try
                {
                    AnswerBO.Deletar(AnswerId, out Mensagem);
                }
                catch (Exception Ex)
                {
                    return BadRequest(Ex);
                }
                return Ok(Mensagem);
            }
        }

        /// <summary>
        /// Obtem uma resposta
        /// </summary>
        /// <param name="AnswerId"></param>
        /// <returns></returns>
        [HttpGet("{AnswerId}")]
        [Authorize("Bearer")]
        public IActionResult Get(int AnswerId)
        {
            using (TheChamaApp.Service.AnswerBusiness.AnswerService AnswerBO = new Service.AnswerBusiness.AnswerService(_IAnswerApplication))
            {
                try
                {
                    return Ok(AnswerBO.Obter(AnswerId));
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
