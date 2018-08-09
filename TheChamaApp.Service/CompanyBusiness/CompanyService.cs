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
        private readonly IStateApplication _IStateApplication;
        private readonly ICompanyTypeApplication _ICompanyTypeApplication;

        #endregion

        #region # Constructor

        public CompanyService(ICompanyApplication company
            , ICompanyAddressApplication companyAddress
            , ICompanyContactApplication companyContact
            , ICompanyUnityApplication companyUnityApplication
            , IStateApplication stateApplication
            , ICompanyTypeApplication companyTypeApplication)
        {
            _ICompanyApplication = company;
            _ICompanyAddressApplication = companyAddress;
            _ICompanyContactApplication = companyContact;
            _ICompanyUnityApplication = companyUnityApplication;
            _IStateApplication = stateApplication;
            _ICompanyTypeApplication = companyTypeApplication;
        }

        #endregion

        #region # Methods

        /// <summary>
        /// Realiza a inclusão de uma nova empresa com os dados do endereco
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        public Domain.Entities.Company IncluirOuAlterar(Domain.Entities.Company Entity,out string Mensagem)
        {
            Mensagem = string.Empty;
            try
            {
                var ListCompany = _ICompanyApplication.GetAll().Where(m => m.Document == Entity.Document).ToList();
                if (ListCompany.Count == 0)
                {
                    _ICompanyApplication.Add(Entity);
                    Mensagem = Entity.CompanyId.ToString();
                }
                else {
                    if(Entity.CompanyId > 0)
                    {
                        _ICompanyApplication.Update(Entity);
                        var OriginalAddress = _ICompanyAddressApplication.GetAll().Where(m => m.CompanyId == Entity.CompanyId).ToList();
                        if (OriginalAddress.Count > 0) {
                            Entity.Address.CompanyAddressId = OriginalAddress.First().CompanyAddressId;
                            Entity.Address.CompanyId = Entity.CompanyId;
                            _ICompanyAddressApplication.Update(Entity.Address);
                        }

                        Mensagem = Entity.CompanyId.ToString();
                    }
                }
            }
            catch (Exception Ex)
            {
                Mensagem = string.Format("Erro:{0}",Ex.Message);
            }
            return Entity;

        }

        /// <summary>
        /// Atualiza a empresa
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <param name="Entity"></param>
        /// <param name="Mensagem"></param>
        /// <returns></returns>
        public Domain.Entities.Company IncluirOuAlterar(int CompanyId,Domain.Entities.Company Entity, out string Mensagem)
        {
            Mensagem = string.Empty;
            try
            {
                var CompanyEntity = _ICompanyApplication.GetAll().Where(m => m.CompanyId == CompanyId).Single();
                if (CompanyEntity.CompanyId > 0)
                {
                    Entity.CompanyId = CompanyId;
                    return this.IncluirOuAlterar(Entity, out Mensagem);
                }
                
            }
            catch (Exception Ex)
            {
                Mensagem = string.Format("Erro:{0}", Ex.Message);
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
                    Mensagem = Entity.CompanyUnityId.ToString();
                }
            }
            catch (Exception Ex)
            {

                Mensagem = string.Format("Erro:{0}",Ex.Message);
            }
        }

        /// <summary>
        /// Altera uma Unidade
        /// </summary>
        /// <param name="CompanyUnityId"></param>
        /// <param name="Entity"></param>
        /// <param name="Mensagem"></param>
        public void AlterarUnidade(int CompanyUnityId, Domain.Entities.CompanyUnity Entity,out string Mensagem)
        {
            try
            {
                var UnityOriginal = _ICompanyUnityApplication.GetAll().Where(m => m.CompanyUnityId == CompanyUnityId).Single();
                if (UnityOriginal.CompanyUnityId > 0 || UnityOriginal != null)
                {
                    Entity.CompanyUnityId = CompanyUnityId;
                    Entity.CompanyId = UnityOriginal.CompanyId;
                    _ICompanyUnityApplication.Update(Entity);
                    Mensagem = "Done";
                }
                else {
                    Mensagem = "Dados não localizados, por favor verifique!!";
                }
            }
            catch (Exception Ex)
            {
                Mensagem = string.Format("Erro:{0}", Ex.Message);
            }
        }

        /// <summary>
        /// Obtem uma lista de unidades por empresa
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        public Domain.Entities.CompanyUnity ObterUnidades(int CompanyUnityId)
        {
            return _ICompanyUnityApplication.GetAll().Where(m => m.CompanyUnityId == CompanyUnityId).Single();
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
                    Mensagem = Entity.CompanyContactId.ToString();
                }
            }
            catch (Exception Ex)
            {
                Mensagem = string.Format("Erro:{0}", Ex.Message);
            }
        }

        /// <summary>
        /// Realiza a alteração de um contato
        /// </summary>
        /// <param name="CompanyContactId"></param>
        /// <param name="Entity"></param>
        /// <param name="Mensagem"></param>
        public void AlterarContato(int CompanyContactId, Domain.Entities.CompanyContact Entity, out string Mensagem)
        {
            try
            {
                var ContatoOriginal = _ICompanyContactApplication.GetAll().Where(m => m.CompanyContactId == CompanyContactId).Single();
                if (ContatoOriginal.CompanyContactId > 0 || ContatoOriginal != null)
                {
                    Entity.CompanyContactId = CompanyContactId;
                    Entity.CompanyId = ContatoOriginal.CompanyId;
                    _ICompanyContactApplication.Update(Entity);
                    Mensagem = "Done";
                }
                else {
                    Mensagem = "Dados não localizados, por favor verifique!!";
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
        public Domain.Entities.CompanyContact ObterContatos(int CompanyContactId)
        {
            return _ICompanyContactApplication.GetAll().Where(m => m.CompanyContactId == CompanyContactId).Single();
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

        /// <summary>
        /// Realiza a exclusão de uma empresa
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <param name="Mensagem"></param>
        public void Excluir(int CompanyId, out string Mensagem)
        {
            Mensagem = string.Empty;
            try
            {
                var CompanyEntity = _ICompanyApplication.GetAll().Where(m => m.CompanyId == CompanyId).Single();
                if (CompanyEntity.CompanyId > 0) {

                    #region - Excluindo contatos
                    foreach (var Contato in _ICompanyContactApplication.GetAll().Where(m => m.CompanyId == CompanyId).ToList())
                    {
                        this.ExcluirContato(Contato.CompanyContactId, out Mensagem);
                    }
                    #endregion

                    #region - Excluir Unidade
                    foreach (var Unidade in _ICompanyUnityApplication.GetAll().Where(m => m.CompanyId == CompanyId).ToList())
                    {
                        this.ExcluirUnidade(Unidade.CompanyUnityId, out Mensagem);
                    }
                    #endregion

                    #region - Excluir Endereço
                    var CompanyAddressEntity = _ICompanyAddressApplication.GetAll().Where(m => m.CompanyId == CompanyId).Single();
                    _ICompanyAddressApplication.Remove(CompanyAddressEntity);
                    #endregion

                    _ICompanyApplication.Remove(CompanyEntity);
                    Mensagem = "Done";
                }

            }
            catch (Exception Ex)
            {
                Mensagem = string.Format("Error:{0}",Ex.Message);
            }
        }

        /// <summary>
        /// Busca uma empresa
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        public Domain.Entities.Company Obter(int CompanyId)
        {
            var CompanyEntity = _ICompanyApplication.GetAll().Where(m => m.CompanyId == CompanyId).Single();
            try
            {
                if (CompanyEntity.CompanyId > 0)
                {
                    //Obtendo o endereço
                    CompanyEntity.Unitys = new List<Domain.Entities.CompanyUnity>();
                    CompanyEntity.Contacts = new List<Domain.Entities.CompanyContact>();
                    if (CompanyEntity.CompanyTypeId.HasValue) {
                        CompanyEntity.Type = _ICompanyTypeApplication.GetAll().Where(m => m.CompanyTypeId == CompanyEntity.CompanyTypeId).Single();
                    }
                    if (_ICompanyAddressApplication.GetAll().Where(m => m.CompanyId == CompanyEntity.CompanyId).Count() > 0) {
                        CompanyEntity.Address = _ICompanyAddressApplication.GetAll().Where(m => m.CompanyId == CompanyId).Single();
                    }
                    foreach (var Contato in _ICompanyContactApplication.GetAll().Where(m => m.CompanyId == CompanyId).ToList())
                    {
                        CompanyEntity.Contacts.Add(Contato);
                    }
                    foreach (var Unidade in _ICompanyUnityApplication.GetAll().Where(m => m.CompanyId == CompanyId).ToList())
                    {
                        CompanyEntity.Unitys.Add(Unidade);
                    }
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return CompanyEntity;
        }

        /// <summary>
        /// Obtem uma lista de empresas
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Domain.Entities.Company> ObterTodas()
        {
            List<Domain.Entities.Company> lista = new List<Domain.Entities.Company>();
            foreach (var company in _ICompanyApplication.GetAll())
            {
                lista.Add(this.Obter(company.CompanyId));
            }
            return lista;
        }

        #endregion
    }
}
