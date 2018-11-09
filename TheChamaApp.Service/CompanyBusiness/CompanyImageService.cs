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
            Mensagem = string.Empty;
            try
            {
                var ImageList = _ICompanyImageApplication.GetAll().Where(m => m.CompanyId == Entity.CompanyId).ToList();
                if (ImageList.Count == 0)
                {
                    _ICompanyImageApplication.Add(Entity);
                    Mensagem = Entity.CompanyImageId.ToString();
                }
                
            }
            catch (Exception Ex)
            {
                Mensagem = string.Format("Error:{0}", Ex.Message);
            }
            return Entity;
        }

        /// <summary>
        /// Atualiza a imagem de um produto
        /// </summary>
        /// <param name="CompanyImageId"></param>
        /// <param name="Entity"></param>
        /// <param name="Mensagem"></param>
        /// <returns></returns>
        public Domain.Entities.CompanyImage Alterar(int CompanyImageId, Domain.Entities.CompanyImage Entity, out string Mensagem)
        {
            Mensagem = string.Empty;
            try
            {
                var ImageList = _ICompanyImageApplication.GetAll().Where(m => m.CompanyImageId == CompanyImageId).ToList();
                if (ImageList.Count > 0)
                {
                    Entity.CompanyImageId = CompanyImageId;
                    _ICompanyImageApplication.Update(Entity);
                    Mensagem = "Done";
                }
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

        /// <summary>
        /// Realiza a exclusão de uma imagem de empresa do sistema
        /// </summary>
        /// <param name="CompanyImageId"></param>
        /// <param name="Mensagem"></param>
        public void Excluir(int CompanyImageId, out string Mensagem)
        {
            Mensagem = string.Empty;
            try
            {
                var CompanyImageEntity = _ICompanyImageApplication.GetAll().Where(m => m.CompanyImageId == CompanyImageId).Single();
                if (CompanyImageEntity != null)
                {
                    _ICompanyImageApplication.Remove(CompanyImageEntity);
                    Mensagem = "Done";
                }
            }
            catch (Exception Ex)
            {
                Mensagem = string.Format("Error:{0}", Ex.Message);
            }
        }

        #endregion
    }
}
