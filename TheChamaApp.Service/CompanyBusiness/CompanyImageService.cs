using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Application.IApplication;
using System.Linq;

namespace TheChamaApp.Service.CompanyBusiness
{
    public class CompanyImageService : Base.ServiceBase
    {
        #region # Propriedades
        private readonly ICompanyImageApplication _ICompanyImageApplication;
        #endregion

        #region # Constructor
        public CompanyImageService(ICompanyImageApplication companyImageApplication)
        {
            _ICompanyImageApplication = companyImageApplication;
        }
        #endregion

        #region # Methods

        /// <summary>
        /// Realiza 
        /// </summary>
        /// <param name="Entity"></param>
        /// <param name="Mensagem"></param>
        /// <returns></returns>
        public Domain.Entities.CompanyImage Incluir(Domain.Entities.CompanyImage Entity, out string Mensagem)
        {
            try
            {
                _ICompanyImageApplication.Add(Entity);
                Mensagem = Entity.CompanyImageId.ToString();
            }
            catch (Exception Ex)
            {
                Mensagem = string.Format("Error:{0}", Ex.Message);
            }
            return Entity;
        }

        /// <summary>
        /// Obtem uma imagem passando a empresa
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        public Domain.Entities.CompanyImage ObterByCompanyId(int CompanyId)
        {
            return _ICompanyImageApplication.GetAll().Where(m => m.CompanyId == CompanyId).Single();
        }

        #endregion
    }
}
