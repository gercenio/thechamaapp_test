using System;
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
    public class CompanyUtilController : Controller
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

        public CompanyUtilController(ICompanyApplication companyApplication
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

        /// <summary>
        /// Realiza a busca pagina de empresas
        /// </summary>
        /// <param name="pagingparametermodel"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize("Bearer")]
        public IEnumerable<Domain.Entities.Company> Get([FromQuery]PagingParameterModel pagingparametermodel)
        {

            using (TheChamaApp.Service.CompanyBusiness.CompanyService CompanyBO = new Service.CompanyBusiness.CompanyService(_ICompanyApplication, _ICompanyAddressApplication, _ICompanyContactApplication, _ICompanyUnityApplication, _IStateApplication, _ICompanyTypeApplication))
            {
                var source = CompanyBO.ObterTodas().AsQueryable();

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