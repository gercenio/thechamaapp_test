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
    public class QuizResultController : BaseController
    {
        #region # Propriedades
        private readonly IQuizResultApplication _IQuizResultApplication;
        private readonly IAskApplication _IAskApplication;
        private readonly IAnswerApplication _IAnswerApplication;
        private readonly IEvaluatedApplication _IEvaluatedApplication;
        private readonly IQuizApplication _IQuizApplication;
        #endregion

        #region # Constructor
        public QuizResultController(IQuizResultApplication quizResultApplication
            , IAskApplication askApplication
            , IAnswerApplication answerApplication
            , IEvaluatedApplication evaluatedApplication
            , IQuizApplication quizApplication)
        {
            _IQuizResultApplication = quizResultApplication;
            _IAskApplication = askApplication;
            _IAnswerApplication = answerApplication;
            _IEvaluatedApplication = evaluatedApplication;
            _IQuizApplication = quizApplication;
        }
        #endregion

        #region # Actions

        /// <summary>
        /// Realiza a inclusão de uma pesquisa
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize("Bearer")]
        public async Task<IActionResult> Post([FromBody]List<Domain.Entities.QuizResult> Entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (TheChamaApp.Service.QuizBusiness.QuizResultService QuizResultBO = new Service.QuizBusiness.QuizResultService(_IQuizResultApplication, _IAskApplication, _IAnswerApplication, _IEvaluatedApplication, _IQuizApplication))
                    {

                        var t1 = Task.Run(() => QuizResultBO.IncluirTodos(Entity, out Mensagem));
                        await Task.WhenAll(t1);
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
        /// Realiza a atualização de uma resultado
        /// </summary>
        /// <param name="QuizResultId"></param>
        /// <param name="Entity"></param>
        /// <returns></returns>
        [HttpPut("{QuizResultId}")]
        [Authorize("Bearer")]
        public IActionResult Pust(int QuizResultId, [FromBody]Domain.Entities.QuizResult Entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (TheChamaApp.Service.QuizBusiness.QuizResultService QuizResultBO = new Service.QuizBusiness.QuizResultService(_IQuizResultApplication, _IAskApplication, _IAnswerApplication, _IEvaluatedApplication, _IQuizApplication))
                    {
                        QuizResultBO.Alterar(QuizResultId, Entity, out Mensagem);
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
        /// Realiza a exclusão
        /// </summary>
        /// <param name="QuizResultId"></param>
        /// <returns></returns>
        [HttpDelete("{QuizResultId}")]
        [Authorize("Bearer")]
        public IActionResult Delete(int QuizResultId)
        {
            try
            {
                using (TheChamaApp.Service.QuizBusiness.QuizResultService QuizResultBO = new Service.QuizBusiness.QuizResultService(_IQuizResultApplication, _IAskApplication, _IAnswerApplication, _IEvaluatedApplication, _IQuizApplication))
                {
                    QuizResultBO.Excluir(QuizResultId, out Mensagem);
                }      
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex);
            }
            return Ok(Mensagem);
        }

        /// <summary>
        /// Obtem uma lista de pesquisas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize("Bearer")]
        public IActionResult Get()
        {
            using (TheChamaApp.Service.QuizBusiness.QuizResultService QuizResultBO = new Service.QuizBusiness.QuizResultService(_IQuizResultApplication, _IAskApplication, _IAnswerApplication, _IEvaluatedApplication, _IQuizApplication))
            {
               return Ok(QuizResultBO.ObterTodos());
            }
        }

        /// <summary>
        /// Obtem uma pesquisa
        /// </summary>
        /// <param name="QuizResultId"></param>
        /// <returns></returns>
        [HttpGet("{QuizResultId}")]
        [Authorize("Bearer")]
        public IActionResult Get(int QuizResultId)
        {
            using (TheChamaApp.Service.QuizBusiness.QuizResultService QuizResultBO = new Service.QuizBusiness.QuizResultService(_IQuizResultApplication, _IAskApplication, _IAnswerApplication, _IEvaluatedApplication, _IQuizApplication))
            {
                return Ok(QuizResultBO.Obter(QuizResultId));
            }
        }


        #endregion

    }
}