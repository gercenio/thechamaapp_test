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
    public class ResultQuestionsController : BaseController
    {
        #region # Propriedades
        private readonly IResultQuestionsApplication _IResultQuestionsApplication;
        #endregion

        #region # Constructor
        public ResultQuestionsController(IResultQuestionsApplication resultQuestionsApplication)
        {
            _IResultQuestionsApplication = resultQuestionsApplication;
        }
        #endregion

        #region # Actions

        /// <summary>
        /// Grava um resultado de avaliação
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize("Bearer")]
        public IActionResult Post([FromBody]Domain.Entities.ResultQuestions Entity)
        {

            using (TheChamaApp.Service.QuestionsBusiness.ResultQuestionsService ResultBO = new Service.QuestionsBusiness.ResultQuestionsService(_IResultQuestionsApplication))
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        ResultBO.Incluir(Entity, out Mensagem);
                        return Ok(Mensagem);
                    }
                    else
                    {
                        Mensagem = ModelState.IsValid.ToString();
                        return Ok(Mensagem);
                    }

                }
                catch (Exception Ex)
                {
                    return BadRequest(Ex);
                }
            }
        }

        /// <summary>
        /// Realiza a alteração de um questionario de respostas
        /// </summary>
        /// <param name="ResultQuestionsId"></param>
        /// <param name="Entity"></param>
        /// <returns></returns>
        [HttpPut]
        [Authorize("Bearer")]
        public IActionResult Put(int ResultQuestionsId, [FromBody]Domain.Entities.ResultQuestions Entity)
        {
            using (TheChamaApp.Service.QuestionsBusiness.ResultQuestionsService ResultBO = new Service.QuestionsBusiness.ResultQuestionsService(_IResultQuestionsApplication))
            {
                try
                {
                    ResultBO.Alterar(ResultQuestionsId, Entity, out Mensagem);
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