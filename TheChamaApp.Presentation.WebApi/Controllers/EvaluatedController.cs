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
    public class EvaluatedController : BaseController
    {
        #region # Propriedades
        private readonly IEvaluatedApplication _IEvaluatedApplication;
        private readonly ICompanyUnityApplication _ICompanyUnityApplication;
        #endregion

        #region # Constructor
        public EvaluatedController(IEvaluatedApplication evaluatedApplication
            , ICompanyUnityApplication companyUnityApplication)
        {
            _IEvaluatedApplication = evaluatedApplication;
            _ICompanyUnityApplication = companyUnityApplication;
        }
        #endregion

        #region # Methods

        /// <summary>
        /// Realiza o cadastro de um novo avaliado
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize("Bearer")]
        public IActionResult Post([FromBody]Domain.Entities.Evaluated Entity)
        {
            
            using (TheChamaApp.Service.EvaluatedBusiness.EvaluatedService EvaluetedBO = new Service.EvaluatedBusiness.EvaluatedService(_IEvaluatedApplication, _ICompanyUnityApplication))
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        EvaluetedBO.Incluir(Entity, out Mensagem);
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
        /// Obtem um avaliado
        /// </summary>
        /// <param name="EvaluatedId"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize("Bearer")]
        public IActionResult Get(int EvaluatedId)
        {
            using (TheChamaApp.Service.EvaluatedBusiness.EvaluatedService EvaluetedBO = new Service.EvaluatedBusiness.EvaluatedService(_IEvaluatedApplication, _ICompanyUnityApplication))
            {
                try
                {
                    return Ok(EvaluetedBO.Obter(EvaluatedId));
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