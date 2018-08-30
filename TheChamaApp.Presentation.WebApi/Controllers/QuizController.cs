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
        #endregion

        #region # Constructor
        public QuizController(IQuizApplication quizApplication
            , IRellationshipQuizToAskApplication rellationshipQuizToAskApplication
            , IAskApplication askApplication)
        {
            _IQuizApplication = quizApplication;
            _IRellationshipQuizToAskApplication = rellationshipQuizToAskApplication;
            _IAskApplication = askApplication;
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
                    using (TheChamaApp.Service.QuizBusiness.QuizService QuizBO = new Service.QuizBusiness.QuizService(_IQuizApplication, _IRellationshipQuizToAskApplication, _IAskApplication))
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
                    using (TheChamaApp.Service.QuizBusiness.QuizService QuizBO = new Service.QuizBusiness.QuizService(_IQuizApplication, _IRellationshipQuizToAskApplication, _IAskApplication))
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
                using (TheChamaApp.Service.QuizBusiness.QuizService QuizBO = new Service.QuizBusiness.QuizService(_IQuizApplication, _IRellationshipQuizToAskApplication, _IAskApplication))
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
                using (TheChamaApp.Service.QuizBusiness.QuizService QuizBO = new Service.QuizBusiness.QuizService(_IQuizApplication, _IRellationshipQuizToAskApplication, _IAskApplication))
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
                using (TheChamaApp.Service.QuizBusiness.QuizService QuizBO = new Service.QuizBusiness.QuizService(_IQuizApplication, _IRellationshipQuizToAskApplication, _IAskApplication))
                {
                    return Ok(QuizBO.ObterByDescription(Description));
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