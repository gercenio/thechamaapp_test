using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TheChamaApp.Application.IApplication;
using TheChamaApp.Infra.CrossCutting.Util;

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
        [HttpGet("{EvaluatedId}")]
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
        [HttpPut("{EvaluatedId}")]
        [Authorize("Bearer")]
        public IActionResult Put(int EvaluatedId, [FromBody]Domain.Entities.Evaluated Entity)
        {
            using (TheChamaApp.Service.EvaluatedBusiness.EvaluatedService EvaluetedBO = new Service.EvaluatedBusiness.EvaluatedService(_IEvaluatedApplication, _ICompanyUnityApplication, _ILevelEvaluatedApplication))
            {
                try
                {
                    EvaluetedBO.Alterar(EvaluatedId, Entity, out Mensagem);
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
        /// Localiza um avaliado (colaborador), passando a unidade e a descrição do mesmo
        /// </summary>
        /// <param name="CompanyUnityId"></param>
        /// <param name="Description"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Description/{CompanyUnityId}/{Description}")]
        [Authorize("Bearer")]
        public IQueryable<Domain.Entities.Evaluated> GetByDescription(int CompanyUnityId,string Description)
        {
            using (TheChamaApp.Service.EvaluatedBusiness.EvaluatedService EvaluetedBO = new Service.EvaluatedBusiness.EvaluatedService(_IEvaluatedApplication, _ICompanyUnityApplication, _ILevelEvaluatedApplication))
            {
                return EvaluetedBO.ObterByDescription(CompanyUnityId,Description).AsQueryable();
            }
        }

        /// <summary>
        /// Realiza a busca paginada dos dados
        /// </summary>
        /// <param name="CompanyUnityId"></param>
        /// <param name="pagingparametermodel"></param>
        /// <returns></returns>
        [HttpGet("ByCompanyUnity/{CompanyUnityId}")]
        [Authorize("Bearer")]
        public IEnumerable<Domain.Entities.Evaluated> Get(int CompanyUnityId,[FromQuery]PagingParameterModel pagingparametermodel)
        {
            using (TheChamaApp.Service.EvaluatedBusiness.EvaluatedService EvaluetedBO = new Service.EvaluatedBusiness.EvaluatedService(_IEvaluatedApplication, _ICompanyUnityApplication, _ILevelEvaluatedApplication))
            {
                var source = EvaluetedBO.ObterTodosPorUnidade(CompanyUnityId).AsQueryable();

                // Get's No of Rows Count   
                int count = source.Count();

                // Parameter is passed from Query string if it is null then it default Value will be pageNumber:1  
                int CurrentPage = pagingparametermodel.pageNumber;

                // Parameter is passed from Query string if it is null then it default Value will be pageSize:20  
                int PageSize = pagingparametermodel.pageSize;

                // Display TotalCount to Records to User  
                int TotalCount = count;

                // Calculating Totalpage by Dividing (No of Records / Pagesize)  
                int TotalPages = (int)Math.Ceiling(count / (double)PageSize);

                // Returns List of Customer after applying Paging   
                var items = source.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();

                // if CurrentPage is greater than 1 means it has previousPage  
                var previousPage = CurrentPage > 1 ? "Yes" : "No";

                // if TotalPages is greater than CurrentPage means it has nextPage  
                var nextPage = CurrentPage < TotalPages ? "Yes" : "No";

                // Object which we are going to send in header   
                var paginationMetadata = new
                {
                    totalCount = TotalCount,
                    pageSize = PageSize,
                    currentPage = CurrentPage,
                    totalPages = TotalPages,
                    previousPage,
                    nextPage
                };

                // Setting Header  
                HttpContext.Response.Headers.Add("Paging-Headers", JsonConvert.SerializeObject(paginationMetadata));
                // Returing List of Customers Collections  
                return items;
            }
        }

        #endregion

    }
}