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
        private readonly ILevelEvaluatedApplication _ILevelEvaluatedApplication;

        #endregion

        #region # Constructor
        public EvaluatedController(IEvaluatedApplication evaluatedApplication
            , ICompanyUnityApplication companyUnityApplication
            , ILevelEvaluatedApplication levelEvaluatedApplication)
        {
            _IEvaluatedApplication = evaluatedApplication;
            _ICompanyUnityApplication = companyUnityApplication;
            _ILevelEvaluatedApplication = levelEvaluatedApplication;
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
            
            using (TheChamaApp.Service.EvaluatedBusiness.EvaluatedService EvaluetedBO = new Service.EvaluatedBusiness.EvaluatedService(_IEvaluatedApplication, _ICompanyUnityApplication, _ILevelEvaluatedApplication))
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
            using (TheChamaApp.Service.EvaluatedBusiness.EvaluatedService EvaluetedBO = new Service.EvaluatedBusiness.EvaluatedService(_IEvaluatedApplication, _ICompanyUnityApplication, _ILevelEvaluatedApplication))
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

        /// <summary>
        /// Atualiza um avaliado
        /// </summary>
        /// <param name="EvaluatedId"></param>
        /// <param name="Entity"></param>
        /// <returns></returns>
        [HttpPut]
        [Authorize("Bearer")]
        public IActionResult Put(int EvaluatedId, [FromBody]Domain.Entities.Evaluated Entity)
        {
            using (TheChamaApp.Service.EvaluatedBusiness.EvaluatedService EvaluetedBO = new Service.EvaluatedBusiness.EvaluatedService(_IEvaluatedApplication, _ICompanyUnityApplication, _ILevelEvaluatedApplication))
            {
                try
                {
                    EvaluetedBO.Alterar(Entity, out Mensagem);
                    return Ok(Mensagem);
                }
                catch (Exception Ex)
                {
                    return BadRequest(Ex);
                }
            }
        }

        /// <summary>
        /// Deleta um avaliado
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{EvaluatedId}")]
        [Authorize("Bearer")]
        public void Delete(int EvaluatedId)
        {
            using (TheChamaApp.Service.EvaluatedBusiness.EvaluatedService EvaluetedBO = new Service.EvaluatedBusiness.EvaluatedService(_IEvaluatedApplication, _ICompanyUnityApplication, _ILevelEvaluatedApplication))
            {
                EvaluetedBO.Excluir(EvaluatedId, out Mensagem);
            }

        }

        /// <summary>
        /// Realiza importação de um arquivo com os colaboradores
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        // POST api/csvtest/import
        [HttpPost]
        [Route("import")]
        [Authorize("Bearer")]
        public async Task<IActionResult> Import([FromBody]List<Domain.Entities.Evaluated> value)
        {
            
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                else
                {
                    using (TheChamaApp.Service.EvaluatedBusiness.EvaluatedService EvaluetedBO = new Service.EvaluatedBusiness.EvaluatedService(_IEvaluatedApplication, _ICompanyUnityApplication, _ILevelEvaluatedApplication))
                    {
                        List<Domain.Entities.Evaluated> data = value;
                        var t1 = Task.Run(() => EvaluetedBO.Importa(data,out Mensagem));
                        await Task.WhenAll(t1);
                        return Ok(Mensagem);
                    }
                   
                    
                }
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex);
            }
        }

        /// <summary>
        /// Localiza um Avaliado passando a descrição
        /// </summary>
        /// <param name="Description"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Description /{Description}")]
        [Authorize("Bearer")]
        public IQueryable<Domain.Entities.Evaluated> GetByDescription(string Description)
        {
            using (TheChamaApp.Service.EvaluatedBusiness.EvaluatedService EvaluetedBO = new Service.EvaluatedBusiness.EvaluatedService(_IEvaluatedApplication, _ICompanyUnityApplication, _ILevelEvaluatedApplication))
            {
                return EvaluetedBO.ObterByDescription(Description).AsQueryable();
            }
        }

        #endregion

    }
}