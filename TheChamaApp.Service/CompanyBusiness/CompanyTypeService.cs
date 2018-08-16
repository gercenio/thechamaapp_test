using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Application.IApplication;
using System.Linq;

namespace TheChamaApp.Service.CompanyBusiness
{
    public class CompanyTypeService : Base.ServiceBase
    {
        #region # Propriedades
        private readonly ICompanyTypeApplication _ICompanyTypeApplication;
        #endregion

        #region # Constructor
        public CompanyTypeService(ICompanyTypeApplication companyTypeApplication)
        {
            _ICompanyTypeApplication = companyTypeApplication;
        }
        #endregion

        #region # Actions

        /// <summary>
        /// Realiza a inclusão de um registro
        /// </summary>
        /// <param name="Entity"></param>
        /// <param name=""></param>
        /// <returns></returns>
        public Domain.Entities.CompanyType Incluir(Domain.Entities.CompanyType Entity, out string Mensagem)
        {
            try
            {
                _ICompanyTypeApplication.Add(Entity);
                Mensagem = Entity.CompanyTypeId.ToString();
                Mensagem = "Done";
            }
            catch (Exception Ex)
            {
                Mensagem = string.Format("Error:{0}", Ex.Message);
            }
            return Entity;
        }

        /// <summary>
        /// Realiza a alteração de um registro
        /// </summary>
        /// <param name="CompanyTypeId"></param>
        /// <param name="Entity"></param>
        /// <param name="Mensagem"></param>
        /// <returns></returns>
        public Domain.Entities.CompanyType Alterar(int CompanyTypeId, Domain.Entities.CompanyType Entity, out string Mensagem)
        {
            try
            {
                var Orginal = _ICompanyTypeApplication.GetAll().Where(m => m.CompanyTypeId == CompanyTypeId).Single();
                if (Orginal != null)
                {
                    Entity.CompanyTypeId = CompanyTypeId;
                    _ICompanyTypeApplication.Update(Entity);
                    Mensagem = "Done";
                }
                else {
                    Mensagem = "Invalid data !!!";
                }
            }
            catch (Exception Ex)
            {
                Mensagem = string.Format("Error:{0}", Ex.Message);
            }
            return Entity;
        }

        /// <summary>
        /// Excluir um registro
        /// </summary>
        /// <param name="CompanyTypeId"></param>
        public void Excluir(int CompanyTypeId)
        {
            try
            {
                var Orginal = _ICompanyTypeApplication.GetAll().Where(m => m.CompanyTypeId == CompanyTypeId).Single();
                if (Orginal != null)
                {
                    _ICompanyTypeApplication.Remove(Orginal);
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }

        /// <summary>
        /// Obtem uma lista de Tipos de empresas
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Domain.Entities.CompanyType> ObterTodos()
        {
            return _ICompanyTypeApplication.GetAll();
        }

        #endregion
    }
}
