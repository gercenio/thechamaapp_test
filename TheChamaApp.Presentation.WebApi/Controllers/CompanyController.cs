﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TheChamaApp.Application.IApplication;
using TheChamaApp.Infra.CrossCutting.Util;

namespace TheChamaApp.Presentation.WebApi.Controllers
{


    [Route("api/[controller]")]
    public class CompanyController : BaseController
    {
        #region # Propriedades

        private readonly ICompanyApplication _ICompanyApplication;
        private readonly ICompanyAddressApplication _ICompanyAddressApplication;
        private readonly ICompanyContactApplication _ICompanyContactApplication;
        private readonly ICompanyUnityApplication _ICompanyUnityApplication;
        private readonly IStateApplication _IStateApplication;

        #endregion

        #region # Constructor

        public CompanyController(ICompanyApplication companyApplication
            , ICompanyAddressApplication companyAddressApplication
            , ICompanyContactApplication companyContactApplication
            , ICompanyUnityApplication companyUnityApplication
            , IStateApplication stateApplication)
        {
            _ICompanyApplication = companyApplication;
            _ICompanyAddressApplication = companyAddressApplication;
            _ICompanyContactApplication = companyContactApplication;
            _ICompanyUnityApplication = companyUnityApplication;
            _IStateApplication = stateApplication;
        }

        #endregion

        #region # Actions

        /// <summary>
        /// Obtem uma lista de empresas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize("Bearer")]
        public IActionResult Get()
        {
            var List = _ICompanyApplication.GetAll();
            return Ok(List);
        }

        /// <summary>
        /// Cadastro de um Empresa na plataforma
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        // POST api/<controller>
        [HttpPost]
        [Authorize("Bearer")]
        public IActionResult Post([FromBody]Domain.Entities.Company Entity)
        {
            

            try
            {

                if (ModelState.IsValid)
                {
                    using (TheChamaApp.Service.CompanyBusiness.CompanyService CompanyBO = new Service.CompanyBusiness.CompanyService(_ICompanyApplication, _ICompanyAddressApplication, _ICompanyContactApplication, _ICompanyUnityApplication, _IStateApplication))
                    {
                        var Result = CompanyBO.IncluirOuAlterar(Entity, out Mensagem);
                        return Ok(Mensagem);
                    }

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

        /// <summary>
        /// Deleta uma empresa
        /// </summary>
        /// <param name="CompanyUnityId"></param>
        // DELETE api/CompanyUnity/5
        [HttpDelete("{CompanyId}")]
        [Authorize("Bearer")]
        public void Delete(int CompanyId)
        {
            using (Service.CompanyBusiness.CompanyService CompanyBO = new Service.CompanyBusiness.CompanyService(_ICompanyApplication, _ICompanyAddressApplication, _ICompanyContactApplication, _ICompanyUnityApplication, _IStateApplication))
            {
                CompanyBO.Excluir(CompanyId, out Mensagem);
            }
        }

        /// <summary>
        /// Obtem uma empresa
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        [HttpGet("{CompanyId}")]
        [Authorize("Bearer")]
        public IActionResult Get(int CompanyId)
        {
            using (Service.CompanyBusiness.CompanyService CompanyBO = new Service.CompanyBusiness.CompanyService(_ICompanyApplication, _ICompanyAddressApplication, _ICompanyContactApplication, _ICompanyUnityApplication, _IStateApplication))
            {
                return Ok(CompanyBO.Obter(CompanyId));
            }
        }

        /// <summary>
        /// Realiza uma alteração de uma empresa
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <param name="Entity"></param>
        /// <returns></returns>
        [HttpPut("{CompanyId}")]
        [Authorize("Bearer")]
        public IActionResult Put(int CompanyId, [FromBody]Domain.Entities.Company Entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (TheChamaApp.Service.CompanyBusiness.CompanyService CompanyBO = new Service.CompanyBusiness.CompanyService(_ICompanyApplication, _ICompanyAddressApplication, _ICompanyContactApplication, _ICompanyUnityApplication, _IStateApplication))
                    {
                        var Result = CompanyBO.IncluirOuAlterar(CompanyId,Entity, out Mensagem);
                        return Ok(Mensagem);
                    }

                }
                else
                {
                    Mensagem = "invalid data !!!";
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