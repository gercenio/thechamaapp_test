using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheChamaApp.Application.IApplication;
using TheChamaApp.Presentation.WebApi.Extension;

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

        /*
        [HttpGet(Name ="GetByPage")]
        [Authorize("Bearer")]
        public async Task<IActionResult> GetByPage(int? page = null,
int pageSize = 10, string orderBy = nameof(Domain.Entities.Company.CompanyId), bool ascending = true)
        {
            if (page == null)
                return Ok(_ICompanyApplication.GetAll());

            var employees = await CreatePagedResults<Domain.Entities.Company, Domain.Entities.Company>
                (_ICompanyApplication.GetAll().AsQueryable(), page.Value, pageSize, orderBy, ascending);
            return Ok(employees);
        }*/

        /// <summary>
        /// Creates a paged set of results.
        /// </summary>
        /// <typeparam name="T">The type of the source IQueryable.</typeparam>
        /// <typeparam name="TReturn">The type of the returned paged results.</typeparam>
        /// <param name="queryable">The source IQueryable.</param>
        /// <param name="page">The page number you want to retrieve.</param>
        /// <param name="pageSize">The size of the page.</param>
        /// <param name="orderBy">The field or property to order by.</param>
        /// <param name="ascending">Indicates whether or not 
        /// the order should be ascending (true) or descending (false.)</param>
        /// <returns>Returns a paged set of results.</returns>
        protected async Task<PagedResults<TReturn>> CreatePagedResults<T, TReturn>(
            IQueryable<T> queryable,
            int page,
            int pageSize,
            string orderBy,
            bool ascending)
        {
            var skipAmount = pageSize * (page - 1);

            var projection = queryable
                .OrderByPropertyOrField(orderBy, ascending)
                .Skip(skipAmount)
                .Take(pageSize).ProjectTo<TReturn>();

            var totalNumberOfRecords = await queryable.CountAsync();
            var results = await projection.ToListAsync();

            var mod = totalNumberOfRecords % pageSize;
            var totalPageCount = (totalNumberOfRecords / pageSize) + (mod == 0 ? 0 : 1);

            var nextPageUrl =
            page == totalPageCount
                ? null
                : Url?.Link("DefaultApi", new
                {
                    page = page + 1,
                    pageSize,
                    orderBy,
                    ascending
                });

            return new PagedResults<TReturn>
            {
                Results = results,
                PageNumber = page,
                PageSize = results.Count,
                TotalNumberOfPages = totalPageCount,
                TotalNumberOfRecords = totalNumberOfRecords,
                NextPageUrl = nextPageUrl
            };
        }


        #endregion

    }
}