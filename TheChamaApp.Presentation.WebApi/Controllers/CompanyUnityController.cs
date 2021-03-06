﻿using System;
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
    public class CompanyUnityController : BaseController
    {
        #region # Propriedades

        private readonly ICompanyUnityApplication _ICompanyUnityApplication;
        private readonly ICompanyApplication _ICompanyApplication;
        private readonly ICompanyAddressApplication _ICompanyAddressApplication;
        private readonly ICompanyContactApplication _ICompanyContactApplication;
        private readonly IStateApplication _IStateApplication;
        private readonly ICompanyTypeApplication _ICompanyTypeApplication;
        private readonly ICompanyImageApplication _ICompanyImageApplication;
        private readonly IEvaluatedApplication _IEvaluatedApplication;

        #endregion

        #region # Constructor

        public CompanyUnityController(ICompanyUnityApplication companyUnityApplication
            , ICompanyApplication companyApplication
            , ICompanyAddressApplication companyAddressApplication
            , ICompanyContactApplication companyContactApplication
            , IStateApplication stateApplication
            , ICompanyTypeApplication companyTypeApplication
            , ICompanyImageApplication companyImageApplication
            , IEvaluatedApplication evaluatedApplication)
        {
            _ICompanyUnityApplication = companyUnityApplication;
            _ICompanyApplication = companyApplication;
            _ICompanyAddressApplication = companyAddressApplication;
            _ICompanyContactApplication = companyContactApplication;
            _IStateApplication = stateApplication;
            _ICompanyTypeApplication = companyTypeApplication;
            _ICompanyImageApplication = companyImageApplication;
            _IEvaluatedApplication = evaluatedApplication;
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
            using (Service.CompanyBusiness.CompanyService CompanyBO = new Service.CompanyBusiness.CompanyService(_ICompanyApplication, _ICompanyAddressApplication, _ICompanyContactApplication, _ICompanyUnityApplication,_IStateApplication,_ICompanyTypeApplication, _ICompanyImageApplication, _IEvaluatedApplication))
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
        [HttpGet("{CompanyUnityId}")]
        [Authorize("Bearer")]
        public IActionResult Get(int CompanyUnityId)
        {
            using (Service.CompanyBusiness.CompanyService CompanyBO = new Service.CompanyBusiness.CompanyService(_ICompanyApplication, _ICompanyAddressApplication, _ICompanyContactApplication, _ICompanyUnityApplication,_IStateApplication,_ICompanyTypeApplication, _ICompanyImageApplication, _IEvaluatedApplication))
            {
                return Ok(CompanyBO.ObterUnidades(CompanyUnityId));
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
            using (Service.CompanyBusiness.CompanyService CompanyBO = new Service.CompanyBusiness.CompanyService(_ICompanyApplication, _ICompanyAddressApplication, _ICompanyContactApplication, _ICompanyUnityApplication,_IStateApplication,_ICompanyTypeApplication, _ICompanyImageApplication, _IEvaluatedApplication))
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
            using (Service.CompanyBusiness.CompanyService CompanyBO = new Service.CompanyBusiness.CompanyService(_ICompanyApplication, _ICompanyAddressApplication, _ICompanyContactApplication, _ICompanyUnityApplication, _IStateApplication,_ICompanyTypeApplication, _ICompanyImageApplication, _IEvaluatedApplication))
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