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
    public class CompanyTypeController : BaseController
    {
        #region # Propriedades
        private readonly ICompanyTypeApplication _ICompanyTypeApplication;
        #endregion

        #region # Constructor
        public CompanyTypeController(ICompanyTypeApplication rellationship)
        {
            _ICompanyTypeApplication = rellationship;
        }
        #endregion

        #region # Actions

        /// <summary>
        /// Cadastra um novo tipo de empresa
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize("Bearer")]
        public IActionResult Post([FromBody]Domain.Entities.CompanyType Entity)
        {
            using (TheChamaApp.Service.CompanyBusiness.CompanyTypeService CompanyTypeBO = new Service.CompanyBusiness.CompanyTypeService(_ICompanyTypeApplication))
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        CompanyTypeBO.Incluir(Entity, out Mensagem);
                        return Ok(Mensagem);
                    }
                    else {
                        Mensagem = "invalid data !!!";
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
        /// Atualiza os dados
        /// </summary>
        /// <param name="CompanyTypeId"></param>
        /// <param name="Entity"></param>
        /// <returns></returns>
        [HttpPut]
        [Authorize("Bearer")]
        public IActionResult Put(int CompanyTypeId, [FromBody]Domain.Entities.CompanyType Entity)
        {
            using (TheChamaApp.Service.CompanyBusiness.CompanyTypeService CompanyTypeBO = new Service.CompanyBusiness.CompanyTypeService(_ICompanyTypeApplication))
            {
                try
                {
                    CompanyTypeBO.Alterar(CompanyTypeId, Entity, out Mensagem);
                    return Ok(Mensagem);
                }
                catch (Exception Ex)
                {
                    return BadRequest(Ex);
                }
            }
        }

        /// <summary>
        /// Retorna uma lista de tipos de empresa
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize("Bearer")]
        public IActionResult Get()
        {
            using (TheChamaApp.Service.CompanyBusiness.CompanyTypeService CompanyTypeBO = new Service.CompanyBusiness.CompanyTypeService(_ICompanyTypeApplication))
            {
                return Ok(CompanyTypeBO.ObterTodos());
            }
                
        }

        /// <summary>
        /// Exclui um registro
        /// </summary>
        /// <param name="CompanyTypeId"></param>
        [HttpDelete]
        [Authorize("Bearer")]
        public void Delete(int CompanyTypeId)
        {
            using (TheChamaApp.Service.CompanyBusiness.CompanyTypeService CompanyTypeBO = new Service.CompanyBusiness.CompanyTypeService(_ICompanyTypeApplication))
            {
                CompanyTypeBO.Excluir(CompanyTypeId);
            }
        }

        #endregion
    }
}