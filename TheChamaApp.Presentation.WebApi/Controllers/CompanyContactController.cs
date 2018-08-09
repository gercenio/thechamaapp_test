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
    public class CompanyContactController : BaseController
    {
        #region # Propriedades

        private readonly ICompanyApplication _ICompanyApplication;
        private readonly ICompanyAddressApplication _ICompanyAddressApplication;
        private readonly ICompanyContactApplication _ICompanyContactApplication;
        private readonly ICompanyUnityApplication _ICompanyUnityApplication;
        private readonly IStateApplication _IStateApplication;
        private readonly ICompanyTypeApplication _ICompanyTypeApplication;

        #endregion

        #region # Constructor

        public CompanyContactController(ICompanyApplication companyApplication
            , ICompanyAddressApplication companyAddressApplication
            , ICompanyContactApplication companyContactApplication
            , ICompanyUnityApplication companyUnityApplication
            , IStateApplication stateApplication
            , ICompanyTypeApplication companyTypeApplication)
        {
            _ICompanyApplication = companyApplication;
            _ICompanyAddressApplication = companyAddressApplication;
            _ICompanyContactApplication = companyContactApplication;
            _ICompanyUnityApplication = companyUnityApplication;
            _IStateApplication = stateApplication;
            _ICompanyTypeApplication = companyTypeApplication;
        }

        #endregion

        #region # Actions

        [HttpPost]
        [Authorize("Bearer")]
        public IActionResult Post([FromBody]Domain.Entities.CompanyContact Entity)
        {
            using (Service.CompanyBusiness.CompanyService CompanyBO = new Service.CompanyBusiness.CompanyService(_ICompanyApplication, _ICompanyAddressApplication, _ICompanyContactApplication, _ICompanyUnityApplication,_IStateApplication,_ICompanyTypeApplication))
            {
                CompanyBO.IncluirContato(Entity, out Mensagem);
            }
            return Ok(Mensagem);
        }

        /// <summary>
        /// Obtem uma lista de contatos
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        [HttpGet("{CompanyContactId}")]
        [Authorize("Bearer")]
        public IActionResult Get(int CompanyContactId)
        {
            using (Service.CompanyBusiness.CompanyService CompanyBO = new Service.CompanyBusiness.CompanyService(_ICompanyApplication, _ICompanyAddressApplication, _ICompanyContactApplication, _ICompanyUnityApplication,_IStateApplication,_ICompanyTypeApplication))
            {
                return Ok(CompanyBO.ObterContatos(CompanyContactId));
            }
        }

        /// <summary>
        /// Deleta uma unidades
        /// </summary>
        /// <param name="CompanyContactId"></param>
        // DELETE api/CompanyUnity/5
        [HttpDelete("{CompanyContactId}")]
        [Authorize("Bearer")]
        public void Delete(int CompanyContactId)
        {
            using (Service.CompanyBusiness.CompanyService CompanyBO = new Service.CompanyBusiness.CompanyService(_ICompanyApplication, _ICompanyAddressApplication, _ICompanyContactApplication, _ICompanyUnityApplication,_IStateApplication,_ICompanyTypeApplication))
            {
                CompanyBO.ExcluirContato(CompanyContactId, out Mensagem);
            }
        }

        /// <summary>
        /// Realiza a alteracao de um contato
        /// </summary>
        /// <param name="CompanyContactId"></param>
        /// <param name="Entity"></param>
        /// <returns></returns>
        [HttpPut("{CompanyContactId}")]
        [Authorize("Bearer")]
        public IActionResult Put(int CompanyContactId, [FromBody]Domain.Entities.CompanyContact Entity)
        {
            using (Service.CompanyBusiness.CompanyService CompanyBO = new Service.CompanyBusiness.CompanyService(_ICompanyApplication, _ICompanyAddressApplication, _ICompanyContactApplication, _ICompanyUnityApplication, _IStateApplication,_ICompanyTypeApplication))
            {
                try
                {
                    CompanyBO.AlterarContato(CompanyContactId, Entity, out Mensagem);
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