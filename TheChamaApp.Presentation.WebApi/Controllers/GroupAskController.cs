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
    public class GroupAskController : BaseController
    {
        #region # Prorpriedades

        private readonly IGroupAskApplication _IGroupAskApplication;
        private readonly IRellationshipQuizToAskApplication _IRellationshipQuizToAskApplication;

        #endregion

        #region # Constructor
        public GroupAskController(IGroupAskApplication groupAskApplication
            , IRellationshipQuizToAskApplication rellationshipQuizToAskApplication)
        {
            _IGroupAskApplication = groupAskApplication;
            _IRellationshipQuizToAskApplication = rellationshipQuizToAskApplication;
        }
        #endregion

        #region # Methods

        /// <summary>
        /// Obtem uma lista de todos os grupos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize("Bearer")]
        public IActionResult Get()
        {
            using (TheChamaApp.Service.AskBusiness.GroupAskBusiness GroupBO = new Service.AskBusiness.GroupAskBusiness(_IGroupAskApplication,_IRellationshipQuizToAskApplication))
            {
                try
                {
                    return Ok(GroupBO.ObtemTodos());
                }
                catch (Exception Ex)
                {
                    return BadRequest(Ex);
                }
            }
        }

        /// <summary>
        /// Realiza inclusão de um group
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize("Bearer")]
        public IActionResult Post([FromBody]Domain.Entities.GroupAsk Entity)
        {

            try
            {
                using (TheChamaApp.Service.AskBusiness.GroupAskBusiness GroupBO = new Service.AskBusiness.GroupAskBusiness(_IGroupAskApplication, _IRellationshipQuizToAskApplication))
                {
                    return Ok(GroupBO.Incluir(Entity, out Mensagem));
                }
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex);
            }
        }

        /// <summary>
        /// Realiza uma alteração
        /// </summary>
        /// <param name="GroupAskId"></param>
        /// <param name="Entity"></param>
        /// <returns></returns>
        [HttpPut("{GroupAskId}")]
        [Authorize("Bearer")]
        public IActionResult Put(int GroupAskId, [FromBody]Domain.Entities.GroupAsk Entity)
        {
            try
            {
                using (TheChamaApp.Service.AskBusiness.GroupAskBusiness GroupBO = new Service.AskBusiness.GroupAskBusiness(_IGroupAskApplication, _IRellationshipQuizToAskApplication))
                {
                    GroupBO.Alterar(GroupAskId, Entity, out Mensagem);
                    return Ok(Mensagem);
                }
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex);
            }
        }

        /// <summary>
        /// Realiza a exclusão de um registro
        /// </summary>
        /// <param name="GroupAskId"></param>
        /// <returns></returns>
        [HttpDelete("{GroupAskId}")]
        [Authorize("Bearer")]
        public IActionResult Delete(int GroupAskId)
        {

            try
            {
                using (TheChamaApp.Service.AskBusiness.GroupAskBusiness GroupBO = new Service.AskBusiness.GroupAskBusiness(_IGroupAskApplication, _IRellationshipQuizToAskApplication))
                {
                    GroupBO.Excluir(GroupAskId, out Mensagem);
                    return Ok(Mensagem);
                }
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex);
            }
        }

        /// <summary>
        /// Obtem um passando o ID
        /// </summary>
        /// <param name="GroupAskId"></param>
        /// <returns></returns>
        [HttpGet("{GroupAskId}")]
        [Authorize("Bearer")]
        public IActionResult Get(int GroupAskId)
        {

            using (TheChamaApp.Service.AskBusiness.GroupAskBusiness GroupBO = new Service.AskBusiness.GroupAskBusiness(_IGroupAskApplication,_IRellationshipQuizToAskApplication))
            {
                try
                {
                    return Ok(GroupBO.Obter(GroupAskId));
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