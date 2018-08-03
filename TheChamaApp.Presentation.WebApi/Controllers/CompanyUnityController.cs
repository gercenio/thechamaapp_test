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
    //[Produces("application/json")]
    //[Route("api/CompanyUnity")]
    [Route("api/[controller]")]
    public class CompanyUnityController : BaseController
    {
        #region # Propriedades

        private readonly ICompanyUnityApplication _ICompanyUnityApplication;
        private readonly ICompanyApplication _ICompanyApplication;
        private readonly ICompanyAddressApplication _ICompanyAddressApplication;
        private readonly ICompanyContactApplication _ICompanyContactApplication;
        private readonly IStateApplication _IStateApplication;

        #endregion

        #region # Constructor

        public CompanyUnityController(ICompanyUnityApplication companyUnityApplication
            , ICompanyApplication companyApplication
            , ICompanyAddressApplication companyAddressApplication
            , ICompanyContactApplication companyContactApplication
            , IStateApplication stateApplication)
        {
            _ICompanyUnityApplication = companyUnityApplication;
            _ICompanyApplication = companyApplication;
            _ICompanyAddressApplication = companyAddressApplication;
            _ICompanyContactApplication = companyContactApplication;
            _IStateApplication = stateApplication;
        }

        #endregion

        #region # Actions

        /// <summary>
        /// Cadastra uma unidade por empresa
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize("Bearer")]
        public IActionResult Post([FromBody]Domain.Entities.CompanyUnity Entity)
        {
            using (Service.CompanyBusiness.CompanyService CompanyBO = new Service.CompanyBusiness.CompanyService(_ICompanyApplication, _ICompanyAddressApplication, _ICompanyContactApplication, _ICompanyUnityApplication,_IStateApplication))
            {
                CompanyBO.IncluirUnidade(Entity, out Mensagem);
            }
            return Ok(Mensagem);
        }

        /// <summary>
        /// Obtem uma lista de unidades por empresa
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        [HttpGet("{CompanyId}")]
        [Authorize("Bearer")]
        public IActionResult Get(int CompanyId)
        {
            using (Service.CompanyBusiness.CompanyService CompanyBO = new Service.CompanyBusiness.CompanyService(_ICompanyApplication, _ICompanyAddressApplication, _ICompanyContactApplication, _ICompanyUnityApplication,_IStateApplication))
            {
                return Ok(CompanyBO.ObterUnidades(CompanyId));
            }
        }

        /// <summary>
        /// Deleta uma unidades
        /// </summary>
        /// <param name="CompanyUnityId"></param>
        // DELETE api/CompanyUnity/5
        [HttpDelete("{CompanyUnityId}")]
        [Authorize("Bearer")]
        public void Delete(int CompanyUnityId)
        {
            using (Service.CompanyBusiness.CompanyService CompanyBO = new Service.CompanyBusiness.CompanyService(_ICompanyApplication, _ICompanyAddressApplication, _ICompanyContactApplication, _ICompanyUnityApplication,_IStateApplication))
            {
                CompanyBO.ExcluirUnidade(CompanyUnityId, out Mensagem);
            }
        }

        /// <summary>
        /// Altera uma Unidade
        /// </summary>
        /// <param name="CompanyUnityId"></param>
        /// <param name="Entity"></param>
        /// <returns></returns>
        [HttpPut("{CompanyId}")]
        [Authorize("Bearer")]
        public IActionResult Put(int CompanyUnityId, [FromBody]Domain.Entities.CompanyUnity Entity)
        {
            using (Service.CompanyBusiness.CompanyService CompanyBO = new Service.CompanyBusiness.CompanyService(_ICompanyApplication, _ICompanyAddressApplication, _ICompanyContactApplication, _ICompanyUnityApplication, _IStateApplication))
            {
                try
                {
                    CompanyBO.AlterarUnidade(CompanyUnityId,Entity,out Mensagem);
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