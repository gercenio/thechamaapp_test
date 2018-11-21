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
    public class RellationshipCompanyUnityToQuizController : BaseController
    {
        #region # Propriedades

        private readonly IRellationshipCompanyUnityToQuizApplication _IRellationshipCompanyUnityToQuizApplication;
        private readonly IQuizApplication _IQuizApplication;
        private readonly IRellationshipQuizToEvaluatedApplication _IRellationshipQuizToEvaluatedApplication;
        private readonly IRellationshipEvaluatedToUpEvaluatedApplication _IRellationshipEvaluatedToUpEvaluatedApplication;
        private readonly IEvaluatedApplication _IEvaluatedApplication;

        #endregion

        #region # Constructor
        public RellationshipCompanyUnityToQuizController(IRellationshipCompanyUnityToQuizApplication rellationshipCompanyUnityToQuizApplication
            , IQuizApplication quizApplication
            , IRellationshipQuizToEvaluatedApplication rellationshipQuizToEvaluated
            , IRellationshipEvaluatedToUpEvaluatedApplication rellationshipEvaluatedToUpEvaluatedApplication
            , IEvaluatedApplication evaluatedApplication)
        {
            _IRellationshipCompanyUnityToQuizApplication = rellationshipCompanyUnityToQuizApplication;
            _IQuizApplication = quizApplication;
            _IRellationshipCompanyUnityToQuizApplication = rellationshipCompanyUnityToQuizApplication;
            _IRellationshipEvaluatedToUpEvaluatedApplication = rellationshipEvaluatedToUpEvaluatedApplication;
            _IEvaluatedApplication = evaluatedApplication;
            _IRellationshipQuizToEvaluatedApplication = rellationshipQuizToEvaluated;
        }
        #endregion

        #region # Actions

        /// <summary>
        /// Realiza a inclusão de uma pergunta
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize("Bearer")]
        public IActionResult Post([FromBody]Domain.Entities.RellationshipCompanyUnityToQuiz Entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (TheChamaApp.Service.QuizBusiness.RellationshipCompanyUnityToQuizService RellationBO = new Service.QuizBusiness.RellationshipCompanyUnityToQuizService(_IRellationshipCompanyUnityToQuizApplication,_IQuizApplication, _IRellationshipQuizToEvaluatedApplication,_IRellationshipEvaluatedToUpEvaluatedApplication,_IEvaluatedApplication))
                    {
                        RellationBO.Incluir(Entity, out Mensagem);
                    }
                }
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex);
            }
            return Ok(Mensagem);
        }

        /// <summary>
        /// Realiza a exclusão de um registro
        /// </summary>
        /// <param name="RellationshipCompanyUnityToQuizId"></param>
        /// <returns></returns>
        [HttpDelete("{RellationshipCompanyUnityToQuizId}")]
        [Authorize("Bearer")]
        public IActionResult Delete(int RellationshipCompanyUnityToQuizId)
        {
            try
            {
                using (TheChamaApp.Service.QuizBusiness.RellationshipCompanyUnityToQuizService RellationBO = new Service.QuizBusiness.RellationshipCompanyUnityToQuizService(_IRellationshipCompanyUnityToQuizApplication, _IQuizApplication, _IRellationshipQuizToEvaluatedApplication, _IRellationshipEvaluatedToUpEvaluatedApplication, _IEvaluatedApplication))
                {
                    RellationBO.Excluir(RellationshipCompanyUnityToQuizId,out Mensagem);
                }
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex);
            }
            return Ok(Mensagem);
        }

        /// <summary>
        /// Obtem uma lista de relacionamentos por unidade
        /// </summary>
        /// <param name="CompanyUnityId"></param>
        /// <returns></returns>
        [HttpGet("ByCompanyUnity/{CompanyUnityId}")]
        [Authorize("Bearer")]
        public IActionResult Get(int CompanyUnityId)
        {
            try
            {
                using (TheChamaApp.Service.QuizBusiness.RellationshipCompanyUnityToQuizService RellationBO = new Service.QuizBusiness.RellationshipCompanyUnityToQuizService(_IRellationshipCompanyUnityToQuizApplication, _IQuizApplication, _IRellationshipQuizToEvaluatedApplication, _IRellationshipEvaluatedToUpEvaluatedApplication, _IEvaluatedApplication))
                {
                    return Ok(RellationBO.ObterByCompanyUnityId(CompanyUnityId));
                }
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex);
            }
        }

        /// <summary>
        /// Realiza a alteração
        /// </summary>
        /// <param name="RellationshipCompanyUnityToQuizId"></param>
        /// <param name="Entity"></param>
        /// <returns></returns>
        [HttpPut("{RellationshipCompanyUnityToQuizId}")]
        [Authorize("Bearer")]
        public IActionResult Put(int RellationshipCompanyUnityToQuizId, [FromBody]Domain.Entities.RellationshipCompanyUnityToQuiz Entity) {
            try
            {
                using (TheChamaApp.Service.QuizBusiness.RellationshipCompanyUnityToQuizService RellationBO = new Service.QuizBusiness.RellationshipCompanyUnityToQuizService(_IRellationshipCompanyUnityToQuizApplication, _IQuizApplication, _IRellationshipQuizToEvaluatedApplication, _IRellationshipEvaluatedToUpEvaluatedApplication, _IEvaluatedApplication))
                {
                    return Ok(RellationBO.Alterar(RellationshipCompanyUnityToQuizId,Entity,out Mensagem));
                }
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex);
            }
        }

        /// <summary>
        /// Obtem uma lista de relacionamento
        /// </summary>
        /// <param name="RellationshipCompanyUnityToQuizId"></param>
        /// <returns></returns>
        [HttpGet("{RellationshipCompanyUnityToQuizId}")]
        [Authorize("Bearer")]
        public IActionResult Get(string RellationshipCompanyUnityToQuizId)
        {
            try
            {
                using (TheChamaApp.Service.QuizBusiness.RellationshipCompanyUnityToQuizService RellationBO = new Service.QuizBusiness.RellationshipCompanyUnityToQuizService(_IRellationshipCompanyUnityToQuizApplication, _IQuizApplication, _IRellationshipQuizToEvaluatedApplication, _IRellationshipEvaluatedToUpEvaluatedApplication, _IEvaluatedApplication))
                {
                    return Ok(RellationBO.Obter(Convert.ToInt32(RellationshipCompanyUnityToQuizId)));
                }
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex);
            }
        }

        #endregion
    }
}