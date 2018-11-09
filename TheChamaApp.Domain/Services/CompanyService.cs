using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Dapper;
using TheChamaApp.Domain.Interfaces.Repository;
using TheChamaApp.Domain.Interfaces.Service;
using TheChamaApp.Domain.ViewModel;

namespace TheChamaApp.Domain.Services
{
    public class CompanyService : Base.Service<Company> , ICompanyService
    {
        #region Propriedades

        private readonly ICompanyRepository _Repository;
        private readonly ICompanyDapperRepository _ICompanyDapperRepository;

        #endregion

        #region # Constructor
        public CompanyService(ICompanyRepository repository
            , ICompanyDapperRepository companyDapperRepository ) : base(repository)
        {
            _Repository = repository;
            _ICompanyDapperRepository = companyDapperRepository;
        }
        #endregion

        #region # Methods
        /// <summary>
        /// Retorna o resumo
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        public IEnumerable<CompanyQuizResultViewModel> GetAllQuizResult(int CompanyId) {

            return _ICompanyDapperRepository.GetAllQuizResult(CompanyId);
        }
        #endregion
    }
}
