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
    public class AskController : BaseController
    {
        #region Propriedades
        private readonly IAskApplication _IAskApplication;
        #endregion

        #region # Constructor

        public AskController(IAskApplication askApplication)
        {
            _IAskApplication = askApplication;
        }
        #endregion

        #region # Actions

        /// <summary>
        /// Realiza a inclusão ou a alteração de uma resposta
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize("Bearer")]
        public IActionResult Post([FromBody]Domain.Entities.Ask Entity)
        {
            using (TheChamaApp.Service.AskBusiness.AskService AskBO = new Service.AskBusiness.AskService(_IAskApplication))
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        AskBO.IncluirOuAlterar(Entity,out Mensagem);
                    }
                    else {
                        Mensagem = "Invalid data !!!";
                    }
                }
                catch (Exception Ex)
                {
                    return BadRequest(Ex);
                }
                return Ok(Mensagem);
            }
        }

        /// <summary>
        /// Obtem uma lista de respostas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize("Bearer")]
        public IActionResult Get()
        {
            using (TheChamaApp.Service.AskBusiness.AskService AskBO = new Service.AskBusiness.AskService(_IAskApplication))
            {
                try
                {
                    return Ok(_IAskApplication.GetAll());
                }
                catch (Exception Ex)
                {
                    return BadRequest(Ex);
                }
            }
        }

        /// <summary>
        /// Obtem uma resposta
        /// </summary>
        /// <param name="AskId"></param>
        /// <returns></returns>
        [HttpGet("{AskId}")]
        [Authorize("Bearer")]
        public IActionResult Get(int AskId)
        {
            using (TheChamaApp.Service.AskBusiness.AskService AskBO = new Service.AskBusiness.AskService(_IAskApplication))
            {
                try
                {
                    return Ok(AskBO.Obter(AskId));
                }
                catch (Exception Ex)
                {
                    return BadRequest(Ex);
                }
            }
        }

        [HttpDelete("{AskId}")]
        [Authorize("Bearer")]
        public void Delete(int AskId)
        {
            using (TheChamaApp.Service.AskBusiness.AskService AskBO = new Service.AskBusiness.AskService(_IAskApplication))
            {
                AskBO.Excluir(AskId, out Mensagem);       
            }
        }

        #endregion

    }
}