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
    /// Obtem os graficos 
    /// </summary>    
    [Route("api/[controller]")]
    public class EvaluatedUtilController : BaseController
    {
        #region # Propriedades
        private readonly IEvaluatedApplication _IEvaluatedApplication;
        private readonly IQuizResultApplication _IQuizResultApplication;
        private readonly IAnswerApplication _IAnswerApplication;
        private readonly IAskApplication _IAskApplication;
        private readonly IGroupAskApplication _IGroupAskApplication;
        private readonly IRellationshipQuizToAskApplication _IRellationshipQuizToAskApplication;
        private readonly IRellationshipCompanyUnityToQuizApplication _IRellationshipCompanyUnityToQuizApplication;
        private readonly IRellationshipEvaluatedToUpEvaluatedApplication _IRellationshipEvaluatedToUpEvaluatedApplication;
        #endregion

        #region # Constructor
        public EvaluatedUtilController(IEvaluatedApplication evaluatedApplication
            , IQuizResultApplication quizResultApplication
            , IAnswerApplication answerApplication
            , IAskApplication askApplication
            , IGroupAskApplication groupAskApplication
            , IRellationshipQuizToAskApplication rellationshipQuizToAskApplication
            , IRellationshipCompanyUnityToQuizApplication rellationshipCompanyUnityToQuizApplication
            , IRellationshipEvaluatedToUpEvaluatedApplication evaluatedToUpEvaluatedApplication)
        {
            _IEvaluatedApplication = evaluatedApplication;
            _IQuizResultApplication = quizResultApplication;
            _IAnswerApplication = answerApplication;
            _IAskApplication = askApplication;
            _IGroupAskApplication = groupAskApplication;
            _IRellationshipQuizToAskApplication = rellationshipQuizToAskApplication;
            _IRellationshipCompanyUnityToQuizApplication = rellationshipCompanyUnityToQuizApplication;
            _IRellationshipEvaluatedToUpEvaluatedApplication = evaluatedToUpEvaluatedApplication;
        }
        #endregion

        #region # Actions

        /// <summary>
        /// Obtem o grafico individual
        /// </summary>
        /// <param name="EvaluatedId"></param>
        /// <returns></returns>
        [HttpGet("{EvaluatedId}")]
        [Authorize("Bearer")]
        public IActionResult Get(int EvaluatedId)
        {
            using (TheChamaApp.Service.ChartBusiness.ChartBaseBusiness ChartBase = new Service.ChartBusiness.ChartBaseBusiness(_IEvaluatedApplication, _IQuizResultApplication, _IRellationshipCompanyUnityToQuizApplication, _IRellationshipEvaluatedToUpEvaluatedApplication, _IAskApplication, _IAnswerApplication,_IGroupAskApplication,_IRellationshipQuizToAskApplication))
            {
                try
                {
                    return Ok(ChartBase.ObterGraficoIndividual(EvaluatedId));
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