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

        /// <summary>
        /// Realiza o relacionamento entre unidade e questionario
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize("Bearer")]
        public IActionResult Post([FromBody]Domain.Entities.RellationshipCompanyUnityToQuestions Entity)
        {
            using (TheChamaApp.Service.QuestionsBusiness.RellationshipCompanyUnityToQuestionsService UnityToQuestionsBO = new Service.QuestionsBusiness.RellationshipCompanyUnityToQuestionsService(_IRellationshipCompanyUnityToQuestionsApplication))
            {
                try
                {
                    UnityToQuestionsBO.Incluir(Entity, out Mensagem);
                }
                catch (Exception Ex)
                {
                    return BadRequest(Ex);
                }
            }
            return Ok(Mensagem);
        }

        /// <summary>
        /// Atualiza os dados de um relacionamento
        /// </summary>
        /// <param name="RellationshipCompanyUnityToQuestionsId"></param>
        /// <param name="Entity"></param>
        /// <returns></returns>
        [HttpPut]
        [Authorize("Bearer")]
        public IActionResult Put(int RellationshipCompanyUnityToQuestionsId
            ,[FromBody]Domain.Entities.RellationshipCompanyUnityToQuestions Entity)
        {
            using (TheChamaApp.Service.QuestionsBusiness.RellationshipCompanyUnityToQuestionsService UnityToQuestionsBO = new Service.QuestionsBusiness.RellationshipCompanyUnityToQuestionsService(_IRellationshipCompanyUnityToQuestionsApplication))
            {
                try
                {
                    UnityToQuestionsBO.Alterar(RellationshipCompanyUnityToQuestionsId, Entity, out Mensagem);
                }
                catch (Exception Ex)
                {

                    return BadRequest(Ex);
                }
                return Ok(Mensagem);
            }
        }

        /// <summary>
        /// Obtem uma relacionamento
        /// </summary>
        /// <param name="RellationshipCompanyUnityToQuestionsId"></param>
        /// <returns></returns>
        [HttpGet("{RellationshipCompanyUnityToQuestionsId}")]
        [Authorize("Bearer")]
        public IActionResult Get(int RellationshipCompanyUnityToQuestionsId)
        {
            using (TheChamaApp.Service.QuestionsBusiness.RellationshipCompanyUnityToQuestionsService UnityToQuestionsBO = new Service.QuestionsBusiness.RellationshipCompanyUnityToQuestionsService(_IRellationshipCompanyUnityToQuestionsApplication))
            {
                return Ok(UnityToQuestionsBO.Obter(RellationshipCompanyUnityToQuestionsId));
            }
        }

        /// <summary>
        /// Deleta um relacionamento
        /// </summary>
        /// <param name="RellationshipCompanyUnityToQuestionsId"></param>
        [HttpDelete("RellationshipCompanyUnityToQuestionsId")]
        [Authorize("Bearer")]
        public void Delete(int RellationshipCompanyUnityToQuestionsId)
        {
            using (TheChamaApp.Service.QuestionsBusiness.RellationshipCompanyUnityToQuestionsService UnityToQuestionsBO = new Service.QuestionsBusiness.RellationshipCompanyUnityToQuestionsService(_IRellationshipCompanyUnityToQuestionsApplication))
            {
                UnityToQuestionsBO.Excluir(RellationshipCompanyUnityToQuestionsId);
            }
        }

        #endregion

    }
}