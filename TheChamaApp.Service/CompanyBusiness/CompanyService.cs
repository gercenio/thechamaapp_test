using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Application.IApplication;
using System.Linq;

namespace TheChamaApp.Service.CompanyBusiness
{
    public class CompanyService
    {
        #region # Propriedades

        private readonly ICompanyApplication _ICompanyApplication;
        private readonly ICompanyAddressApplication _ICompanyAddressApplication;
        private readonly ICompanyContactApplication _ICompanyContactApplication;

        #endregion

        #region # Constructor

        public CompanyService(ICompanyApplication company
            , ICompanyAddressApplication companyAddress
            , ICompanyContactApplication companyContact)
        {
            _ICompanyApplication = company;
            _ICompanyAddressApplication = companyAddress;
            _ICompanyContactApplication = companyContact;
        }

        #endregion

        #region # Methods

        /// <summary>
        /// Realiza a inclusão de uma nova empresa com os dados do endereco
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        public Domain.Entities.Company Incluir(Domain.Entities.Company Entity,out string Mensagem)
        {

            Mensagem = string.Empty;
            try
            {
                var ListCompany = _ICompanyApplication.GetAll().Where(m => m.Document == Entity.Document).ToList();
                if (ListCompany.Count == 0)
                {
                    _ICompanyApplication.Add(Entity);
                    //Adiciona o endereço
                    Entity.Address.CompanyId = Entity.CompanyId;
                    _ICompanyAddressApplication.Add(Entity.Address);
                    Mensagem = "Done";
                }
            }
            catch (Exception Ex)
            {
                Mensagem = string.Format("Erro:{0}",Ex.Message);
            }

            return Entity;

        }

        #endregion
    }
}
