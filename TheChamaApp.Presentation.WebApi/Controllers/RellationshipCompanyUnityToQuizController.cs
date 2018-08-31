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
        #endregion

        #region # Constructor
        public RellationshipCompanyUnityToQuizController(IRellationshipCompanyUnityToQuizApplication rellationshipCompanyUnityToQuizApplication)
        {
            _IRellationshipCompanyUnityToQuizApplication = rellationshipCompanyUnityToQuizApplication;
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
                    using (TheChamaApp.Service.QuizBusiness.RellationshipCompanyUnityToQuizService RellationBO = new Service.QuizBusiness.RellationshipCompanyUnityToQuizService(_IRellationshipCompanyUnityToQuizApplication))
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
                using (TheChamaApp.Service.QuizBusiness.RellationshipCompanyUnityToQuizService RellationBO = new Service.QuizBusiness.RellationshipCompanyUnityToQuizService(_IRellationshipCompanyUnityToQuizApplication))
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

        #endregion
    }
}