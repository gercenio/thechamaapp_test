using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheChamaApp.Application.IApplication;

namespace TheChamaApp.Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class CompanyImageController : BaseController
    {
        #region # Propriedades
        private readonly ICompanyImageApplication _ICompanyImageApplication;
        #endregion

        #region # Constructor
        public CompanyImageController(ICompanyImageApplication companyImageApplication)
        {
            _ICompanyImageApplication = companyImageApplication;
        }
        #endregion

        #region # Actions

        /// <summary>
        /// Realiza a inclusão de uma image por empresa
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize("Bearer")]
        public IActionResult Post([FromBody]Domain.Entities.CompanyImage Entity)
        {
            try
            {
                using (TheChamaApp.Service.CompanyBusiness.CompanyImageService CompanyImageBO = new Service.CompanyBusiness.CompanyImageService(_ICompanyImageApplication))
                {
                    CompanyImageBO.Incluir(Entity, out Mensagem);
                    return Ok(Mensagem);
                }
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex);
            }
        }

        /// <summary>
        /// Obtem uma image passando a empresa
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        [HttpGet("{CompanyId}")]
        [Authorize("Bearer")]
        public IActionResult Get(int CompanyId)
        {
            try
            {
                using (TheChamaApp.Service.CompanyBusiness.CompanyImageService CompanyImageBO = new Service.CompanyBusiness.CompanyImageService(_ICompanyImageApplication))
                {
                    return Ok(CompanyImageBO.ObterByCompanyId(CompanyId));
                }
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex);
            }
        }

        /// <summary>
        /// Realiza a alteração de uma imagem
        /// </summary>
        /// <param name="CompanyImageId"></param>
        /// <param name="Entity"></param>
        /// <returns></returns>
        [HttpPut("{CompanyImageId}")]
        [Authorize("Bearer")]
        public IActionResult Put(int CompanyImageId, [FromBody]Domain.Entities.CompanyImage Entity)
        {
            try
            {
                using (TheChamaApp.Service.CompanyBusiness.CompanyImageService CompanyImageBO = new Service.CompanyBusiness.CompanyImageService(_ICompanyImageApplication))
                {
                    CompanyImageBO.Alterar(CompanyImageId, Entity, out Mensagem);
                    return Ok(Mensagem);
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
