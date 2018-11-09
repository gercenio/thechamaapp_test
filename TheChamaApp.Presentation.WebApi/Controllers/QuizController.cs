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
    public class QuizController : BaseController
    {

        #region # Propriedades

        private readonly IQuizApplication _IQuizApplication;
        private readonly IRellationshipQuizToAskApplication _IRellationshipQuizToAskApplication;
        private readonly IAskApplication _IAskApplication;
        private readonly IRellationshipAskToAnswerApplication _IRellationshipAskToAnswerApplication;
        private readonly IGroupAskApplication _IGroupAskApplication;
        private readonly IAnswerApplication _IAnswerApplication;

        #endregion

        #region # Constructor
        public QuizController(IQuizApplication quizApplication
            , IRellationshipQuizToAskApplication rellationshipQuizToAskApplication
            , IAskApplication askApplication
            , IRellationshipAskToAnswerApplication rellationshipAskToAnswerApplication
            , IGroupAskApplication groupAskApplication
            , IAnswerApplication answerApplication)
        {
            _IQuizApplication = quizApplication;
            _IRellationshipQuizToAskApplication = rellationshipQuizToAskApplication;
            _IAskApplication = askApplication;
            _IRellationshipAskToAnswerApplication = rellationshipAskToAnswerApplication;
            _IGroupAskApplication = groupAskApplication;
            _IAnswerApplication = answerApplication;
        }
        #endregion

        #region # Actions

        /// <summary>
        /// Realiza a inclusão de um questão
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize("Bearer")]
        public IActionResult Post([FromBody]Domain.Entities.Quiz Entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (TheChamaApp.Service.QuizBusiness.QuizService QuizBO = new Service.QuizBusiness.QuizService(_IQuizApplication, _IRellationshipQuizToAskApplication, _IAskApplication, _IRellationshipAskToAnswerApplication,_IGroupAskApplication,_IAnswerApplication))
                    {

                        QuizBO.Incluir(Entity, out Mensagem);
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
        /// Realiza a alteração
        /// </summary>
        /// <param name="QuizId"></param>
        /// <param name="Entity"></param>
        /// <returns></returns>
        [HttpPut("{QuizId}")]
        [Authorize("Bearer")]
        public IActionResult Put(int QuizId,[FromBody]Domain.Entities.Quiz Entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (TheChamaApp.Service.QuizBusiness.QuizService QuizBO = new Service.QuizBusiness.QuizService(_IQuizApplication, _IRellationshipQuizToAskApplication, _IAskApplication, _IRellationshipAskToAnswerApplication,_IGroupAskApplication,_IAnswerApplication))
                    {
                        QuizBO.Alterar(QuizId, Entity, out Mensagem);
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
        /// Realiza deleção de uma questão
        /// </summary>
        /// <param name="QuizId"></param>
        [HttpDelete("{QuizId}")]
        [Authorize("Bearer")]
        public IActionResult Delete(int QuizId)
        {
            
            try
            {
                using (TheChamaApp.Service.QuizBusiness.QuizService QuizBO = new Service.QuizBusiness.QuizService(_IQuizApplication, _IRellationshipQuizToAskApplication, _IAskApplication, _IRellationshipAskToAnswerApplication,_IGroupAskApplication,_IAnswerApplication))
                {
                    QuizBO.Excluir(QuizId, out Mensagem);
                 
                }
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex);
            }
            return Ok(Mensagem);
        }

        /// <summary>
        /// Obtem uma lista de questões
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize("Bearer")]
        public IActionResult Get()
        {
            try
            {
                using (TheChamaApp.Service.QuizBusiness.QuizService QuizBO = new Service.QuizBusiness.QuizService(_IQuizApplication, _IRellationshipQuizToAskApplication, _IAskApplication, _IRellationshipAskToAnswerApplication,_IGroupAskApplication,_IAnswerApplication))
                {
                    return Ok(QuizBO.ObterTodos());
                }
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex);
            }
        }

        /// <summary>
        /// Obtem uma lista por descrição
        /// </summary>
        /// <param name="Description"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Description/{Description}")]
        [Authorize("Bearer")]
        public IActionResult Get(string Description)
        {
            try
            {
                using (TheChamaApp.Service.QuizBusiness.QuizService QuizBO = new Service.QuizBusiness.QuizService(_IQuizApplication, _IRellationshipQuizToAskApplication, _IAskApplication, _IRellationshipAskToAnswerApplication,_IGroupAskApplication,_IAnswerApplication))
                {
                    return Ok(QuizBO.ObterByDescription(Description));
                }
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex);
            }
        }

        /// <summary>
        /// Obtem um questionario passando o ID
        /// </summary>
        /// <param name="QuizId"></param>
        /// <returns></returns>
        [HttpGet("{QuizId}")]
        [Authorize("Bearer")]
        public IActionResult Get(int QuizId)
        {
            try
            {
                using (TheChamaApp.Service.QuizBusiness.QuizService QuizBO = new Service.QuizBusiness.QuizService(_IQuizApplication, _IRellationshipQuizToAskApplication, _IAskApplication, _IRellationshipAskToAnswerApplication,_IGroupAskApplication,_IAnswerApplication))
                {
                    return Ok(QuizBO.Obter(QuizId));
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