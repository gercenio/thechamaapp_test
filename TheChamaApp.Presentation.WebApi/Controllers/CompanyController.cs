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
    public class CompanyController : BaseController
    {
        #region # Propriedades

        private readonly ICompanyApplication _ICompanyApplication;
        private readonly ICompanyAddressApplication _ICompanyAddressApplication;
        private readonly ICompanyContactApplication _ICompanyContactApplication;
        private readonly ICompanyUnityApplication _ICompanyUnityApplication;

        #endregion

        #region # Constructor

        public CompanyController(ICompanyApplication companyApplication
            , ICompanyAddressApplication companyAddressApplication
            , ICompanyContactApplication companyContactApplication
            , ICompanyUnityApplication companyUnityApplication)
        {
            _ICompanyApplication = companyApplication;
            _ICompanyAddressApplication = companyAddressApplication;
            _ICompanyContactApplication = companyContactApplication;
            _ICompanyUnityApplication = companyUnityApplication;
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
            //string Mensagem = string.Empty;
            if (ModelState.IsValid)
            {
                using (TheChamaApp.Service.CompanyBusiness.CompanyService CompanyBO = new Service.CompanyBusiness.CompanyService(_ICompanyApplication,_ICompanyAddressApplication,_ICompanyContactApplication,_ICompanyUnityApplication))
                {
                    var Result = CompanyBO.Incluir(Entity,out Mensagem);
                }
            }
            return Ok(Mensagem);
        }

        
        
        #endregion

    }
}