using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Application.IApplication;
using System.Linq;

namespace TheChamaApp.Service.CompanyBusiness
{
    public class CompanyService : Base.ServiceBase
    {
        #region # Propriedades

        private readonly ICompanyApplication _ICompanyApplication;
        private readonly ICompanyAddressApplication _ICompanyAddressApplication;
        private readonly ICompanyContactApplication _ICompanyContactApplication;
        private readonly ICompanyUnityApplication _ICompanyUnityApplication;

        #endregion

        #region # Constructor

        public CompanyService(ICompanyApplication company
            , ICompanyAddressApplication companyAddress
            , ICompanyContactApplication companyContact
            , ICompanyUnityApplication companyUnityApplication)
        {
            _ICompanyApplication = company;
            _ICompanyAddressApplication = companyAddress;
            _ICompanyContactApplication = companyContact;
            _ICompanyUnityApplication = companyUnityApplication;
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

        /// <summary>
        /// Realiza o cadastro de uma unidade
        /// </summary>
        /// <param name="Entity"></param>
        /// <param name="Mensagem"></param>
        public void IncluirUnidade(Domain.Entities.CompanyUnity Entity, out string Mensagem)
        {
            try
            {
                var EntityCompanyList = _ICompanyApplication.GetAll().Where(m => m.CompanyId == Entity.CompanyId).ToList();
                if (EntityCompanyList.Count == 0)
                {
                    Mensagem = "Empresa nâo encontrada, por favor verifique !!!";
                }
                else
                {
                    _ICompanyUnityApplication.Add(Entity);
                    Mensagem = "Done";
                }
            }
            catch (Exception Ex)
            {

                Mensagem = string.Format("Erro:{0}",Ex.Message);
            }
        }

        /// <summary>
        /// Obtem uma lista de unidades por empresa
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        public IEnumerable<Domain.Entities.CompanyUnity> ObterUnidades(int CompanyId)
        {
            return _ICompanyUnityApplication.GetAll().Where(m => m.CompanyId == CompanyId).ToList();
        }

        /// <summary>
        /// Cadastra um contato para a empresa
        /// </summary>
        /// <param name="Entity"></param>
        /// <param name="Mensagem"></param>
        public void IncluirContato(Domain.Entities.CompanyContact Entity, out string Mensagem)
        {
            try
            {
                var ListCompany = _ICompanyApplication.GetAll().Where(m => m.CompanyId == Entity.CompanyId).ToList();
                if (ListCompany.Count == 0)
                {
                    Mensagem = "Empresa não encontrada, por favor verifique !!!";
                }
                else
                {
                    _ICompanyContactApplication.Add(Entity);
                    Mensagem = "Done";
                }
            }
            catch (Exception Ex)
            {
                Mensagem = string.Format("Erro:{0}", Ex.Message);
            }
        }

        /// <summary>
        /// Obtem uma lista de contatos por empresa
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        public IEnumerable<Domain.Entities.CompanyContact> ObterContatos(int CompanyId)
        {
            return _ICompanyContactApplication.GetAll().Where(m => m.CompanyId == CompanyId).ToList();
        }

        /// <summary>
        /// Realiza a exclusão de uma unidade
        /// </summary>
        /// <param name="CompanyUnityId"></param>
        public void ExcluirUnidade(int CompanyUnityId,out string Mensagem)
        {
            try
            {
                var Entity = _ICompanyUnityApplication.GetAll().Where(m => m.CompanyUnityId == CompanyUnityId).SingleOrDefault();
                if (Entity.CompanyUnityId == 0 || Entity == null)
                {
                    Mensagem = "Unidade não encontrada, por favor verifique !!!";
                }
                else
                {
                    _ICompanyUnityApplication.Remove(Entity);
                    Mensagem = "Done";
                }
                
            }
            catch (Exception Ex)
            {
                Mensagem = string.Format("Erro:{0}", Ex.Message);
            }
        }

        /// <summary>
        /// Excluir um contato
        /// </summary>
        /// <param name="CompanyContactId"></param>
        /// <param name="Mensagem"></param>
        public void ExcluirContato(int CompanyContactId, out string Mensagem)
        {
            try
            {
                var Entity = _ICompanyContactApplication.GetAll().Where(m => m.CompanyContactId == CompanyContactId).SingleOrDefault();
                if (Entity.CompanyContactId == 0 || Entity == null)
                {
                    Mensagem = "Unidade não encontrada, por favor verifique !!!";
                }
                else {
                    _ICompanyContactApplication.Remove(Entity);
                    Mensagem = "Done";
                }
            }
            catch (Exception Ex)
            {
                Mensagem = string.Format("Erro:{0}", Ex.Message);
            }
        }

        #endregion
    }
}
