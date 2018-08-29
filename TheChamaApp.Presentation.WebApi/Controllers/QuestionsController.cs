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
    /// Realiza o cadastro de um questionario
    /// </summary>
    [Route("api/[controller]")]
    public class QuestionsController : BaseController
    {
        #region # Propriedades
        private readonly IQuestionsApplication _IQuestionApplication;
        #endregion

        #region # Constructor
        public QuestionsController(IQuestionsApplication questionsApplication)
        {
            _IQuestionApplication = questionsApplication;
        }
        #endregion

        #region # Actions

        /// <summary>
        /// Realiza o cadastro de uma pergunta
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize("Bearer")]
        public IActionResult Post([FromBody]Domain.Entities.Questions Entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (TheChamaApp.Service.QuestionsBusiness.QuestionsService QuestionsBO = new Service.QuestionsBusiness.QuestionsService(_IQuestionApplication))
                    {
                        var Result = QuestionsBO.IncluirOuAlterar(Entity, out Mensagem);
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
        /// Obtem uma lista de perguntas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize("Bearer")]
        public IActionResult Get()
        {
            try
            {
                var List = _IQuestionApplication.GetAll();
                return Ok(List);
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex);
            }

        }

        /// <summary>
        /// Detela uma pergunta
        /// </summary>
        /// <param name="QuestionsId"></param>
        /// <returns></returns>
        [HttpDelete("{QuestionsId}")]
        [Authorize("Bearer")]
        public IActionResult Delete(int QuestionsId)
        {
            using (TheChamaApp.Service.QuestionsBusiness.QuestionsService QuestionsBO = new Service.QuestionsBusiness.QuestionsService(_IQuestionApplication))
            {
                QuestionsBO.Excluir(QuestionsId, out Mensagem);
            }
            return Ok(Mensagem);
        }

        /// <summary>
        /// Obtem uma pergunta
        /// </summary>
        /// <param name="QuestionsId"></param>
        /// <returns></returns>
        [HttpGet("{QuestionsId}")]
        [Authorize("Bearer")]
        public IActionResult Get(int QuestionsId)
        {
            using (TheChamaApp.Service.QuestionsBusiness.QuestionsService QuestionsBO = new Service.QuestionsBusiness.QuestionsService(_IQuestionApplication))
            {
                return Ok(QuestionsBO.Obter(QuestionsId));
            }
        }

        /// <summary>
        /// Realiza a alteração de um questionario
        /// </summary>
        /// <param name="QuestionsId"></param>
        /// <param name="Entity"></param>
        /// <returns></returns>
        [HttpPut("{QuestionsId}")]
        [Authorize("Bearer")]
        public IActionResult Put(int QuestionsId, [FromBody]Domain.Entities.Questions Entity)
        {
            using (TheChamaApp.Service.QuestionsBusiness.QuestionsService QuestionsBO = new Service.QuestionsBusiness.QuestionsService(_IQuestionApplication))
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        QuestionsBO.Alterar(QuestionsId, Entity, out Mensagem);
                    }
                        
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