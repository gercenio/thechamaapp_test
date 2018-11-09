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
    public class RellationshipQuizToEvaluatedController : BaseController
    {
        #region # Propriedades

        private readonly IRellationshipQuizToEvaluatedApplication _IRellationshipQuizToEvaluatedApplication;
        private readonly IEvaluatedApplication _IEvaluatedApplication;
        private readonly IRellationshipEvaluatedToUpEvaluatedApplication _IRellationshipEvaluatedToUpEvaluatedApplication;
        private readonly IQuizApplication _IQuizApplication;

        #endregion

        #region # Constructor

        public RellationshipQuizToEvaluatedController(IRellationshipQuizToEvaluatedApplication rellationshipQuizToEvaluatedApplication
            , IEvaluatedApplication evaluatedApplication
            , IRellationshipEvaluatedToUpEvaluatedApplication evaluatedToUpEvaluatedApplication
            , IQuizApplication quizApplication)
        {
            _IRellationshipQuizToEvaluatedApplication = rellationshipQuizToEvaluatedApplication;
            _IEvaluatedApplication = evaluatedApplication;
            _IRellationshipEvaluatedToUpEvaluatedApplication = evaluatedToUpEvaluatedApplication;
            _IQuizApplication = quizApplication;
        }

        #endregion

        #region # Actions

        /// <summary>
        /// Obtem uma lista de formularios por Avaliado
        /// </summary>
        /// <param name="EvaluatedId"></param>
        /// <returns></returns>
        [HttpGet("{EvaluatedId}")]
        [Authorize("Bearer")]
        public IActionResult Get(int EvaluatedId)
        {
            using (Service.EvaluatedBusiness.RellationshipQuizToEvaluatedService RellationBO = new Service.EvaluatedBusiness.RellationshipQuizToEvaluatedService(_IRellationshipQuizToEvaluatedApplication, _IRellationshipEvaluatedToUpEvaluatedApplication, _IEvaluatedApplication, _IQuizApplication))
            {
                try
                {
                    return Ok(RellationBO.ObterTodos(EvaluatedId));
                }
                catch (Exception Ex)
                {
                    return BadRequest(Ex);
                }
            }
        }

        /// <summary>
        /// Realiza a exclusão de um registro passando o ID
        /// </summary>
        /// <param name="RellationshipQuizToEvaluatedId"></param>
        /// <returns></returns>
        [HttpDelete("{RellationshipQuizToEvaluatedId}")]
        [Authorize("Bearer")]
        public IActionResult Delete(int RellationshipQuizToEvaluatedId)
        {
            using (Service.EvaluatedBusiness.RellationshipQuizToEvaluatedService RellationBO = new Service.EvaluatedBusiness.RellationshipQuizToEvaluatedService(_IRellationshipQuizToEvaluatedApplication, _IRellationshipEvaluatedToUpEvaluatedApplication, _IEvaluatedApplication, _IQuizApplication))
            {
                try
                {
                    RellationBO.Excluir(RellationshipQuizToEvaluatedId, out Mensagem);
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