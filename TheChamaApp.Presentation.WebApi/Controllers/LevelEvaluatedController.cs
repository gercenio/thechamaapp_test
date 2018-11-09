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
    public class LevelEvaluatedController : BaseController
    {
        #region # Propriedades
        private readonly ILevelEvaluatedApplication _ILevelEvaluatedApplication;
        #endregion

        #region # Constructor
        public LevelEvaluatedController(ILevelEvaluatedApplication levelEvaluatedApplication)
        {
            _ILevelEvaluatedApplication = levelEvaluatedApplication;
        }
        #endregion

        #region # Actions

        /// <summary>
        /// Realiza o cadastro de um tipo de avaliado(departamento/setor)
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize("Bearer")]
        public IActionResult Post([FromBody]Domain.Entities.LevelEvaluated Entity)
        {

            using (TheChamaApp.Service.EvaluatedBusiness.LevelEvaluatedService LevelBO = new Service.EvaluatedBusiness.LevelEvaluatedService(_ILevelEvaluatedApplication))
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        LevelBO.Incluir(Entity, out Mensagem);
                        return Ok(Mensagem);
                    }
                    else
                    {
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
        /// Realiza a atualização de um departamento / setor
        /// </summary>
        /// <param name="LevelEvaluatedId"></param>
        /// <param name="Entity"></param>
        /// <returns></returns>
        [HttpPut("{LevelEvaluatedId}")]
        [Authorize("Bearer")]
        public IActionResult Put(int LevelEvaluatedId, [FromBody]Domain.Entities.LevelEvaluated Entity)
        {
            using (TheChamaApp.Service.EvaluatedBusiness.LevelEvaluatedService LevelBO = new Service.EvaluatedBusiness.LevelEvaluatedService(_ILevelEvaluatedApplication))
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        LevelBO.Alterar(LevelEvaluatedId, Entity, out Mensagem);
                        return Ok(Mensagem);
                    }
                    else {
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
        /// Exclui um registro
        /// </summary>
        /// <param name="LevelEvaluatedId"></param>
        [HttpDelete("{LevelEvaluatedId}")]
        [Authorize("Bearer")]
        public void Delete(int LevelEvaluatedId)
        {
            using (TheChamaApp.Service.EvaluatedBusiness.LevelEvaluatedService LevelBO = new Service.EvaluatedBusiness.LevelEvaluatedService(_ILevelEvaluatedApplication))
            {
                LevelBO.Excluir(LevelEvaluatedId, out Mensagem);
            }
        }

        /// <summary>
        /// Obtem uma lista de departamentos / setor
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize("Bearer")]
        public IActionResult Get()
        {
            using (TheChamaApp.Service.EvaluatedBusiness.LevelEvaluatedService LevelBO = new Service.EvaluatedBusiness.LevelEvaluatedService(_ILevelEvaluatedApplication))
            {
                try
                {
                    return Ok(LevelBO.ObterTodos());
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