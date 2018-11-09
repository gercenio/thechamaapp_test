using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Application.IApplication;
using System.Linq;

namespace TheChamaApp.Service.AccessBusiness
{
    public class LoginService : Base.ServiceBase
    {
        #region # Propriedades
        private readonly ILoginApplication _ILoginApplication;
        private readonly ICompanyUnityApplication _ICompanyUnityApplication;
        #endregion

        #region # Constructor
        public LoginService(ILoginApplication loginApplication
            , ICompanyUnityApplication companyUnityApplication)
        {
            _ILoginApplication = loginApplication;
            _ICompanyUnityApplication = companyUnityApplication;
        }
        #endregion

        #region # Methods

        /// <summary>
        /// Realiza a inclusão de um novo login
        /// </summary>
        /// <param name="Entity"></param>
        /// <param name="Mensagem"></param>
        /// <returns></returns>
        public Domain.Entities.Login Incluir(Domain.Entities.Login Entity, out string Mensagem)
        {
            Mensagem = string.Empty;
            try
            {
                if (Entity.Type == Domain.Util.LoginType.People && Entity.CompanyUnityId > 0)
                {
                    var CompanyUnityList = _ICompanyUnityApplication.GetAll().Where(m => m.CompanyUnityId == Entity.CompanyUnityId).ToList();
                    if (CompanyUnityList.Count == 0)
                    {
                        Mensagem = "Unity not found, check data !!!";
                    }
                    if (string.IsNullOrEmpty(Mensagem))
                    {
                        _ILoginApplication.Add(Entity);
                        Mensagem = Entity.LoginId.ToString();
                    }
                }
                else {
                    _ILoginApplication.Add(Entity);
                    Mensagem = Entity.LoginId.ToString();
                }
            }
            catch (Exception Ex)
            {
                Mensagem = string.Format("Erro:{0}", Ex.Message);
            }
            return Entity;
        }

        /// <summary>
        /// Realiza a alteração de um login
        /// </summary>
        /// <param name="LoginId"></param>
        /// <param name="Entity"></param>
        /// <param name="Mensagem"></param>
        /// <returns></returns>
        public Domain.Entities.Login Alterar(int LoginId, Domain.Entities.Login Entity, out string Mensagem)
        {
            Mensagem = string.Empty;
            try
            {
                var Original = _ILoginApplication.GetAll().Where(m => m.LoginId == LoginId).ToList();
                if (Original.Count > 0)
                {
                    Entity.LoginId = LoginId;
                    _ILoginApplication.Update(Entity);
                    Mensagem = "Done";
                }
            }
            catch (Exception Ex)
            {
                Mensagem = string.Format("Erro:{0}", Ex.Message);
            }
            return Entity;
        }

        /// <summary>
        /// Realiza a exclusão de um login
        /// </summary>
        /// <param name="LoginId"></param>
        public void Excluir(int LoginId, out string Mensagem)
        {
            Mensagem = string.Empty;
            try
            {
                var Original = _ILoginApplication.GetAll().Where(m => m.LoginId == LoginId).ToList();
                if (Original.Count > 0)
                {
                    _ILoginApplication.Remove(Original[0]);
                    Mensagem = "Done";
                }
            }
            catch (Exception Ex)
            {
                Mensagem = string.Format("Erro:{0}", Ex.Message);
            }
        }

        /// <summary>
        /// Obtem um login passando o Id do mesmo
        /// </summary>
        /// <param name="LoginId"></param>
        /// <returns></returns>
        public Domain.Entities.Login Obter(int LoginId)
        {
            
            var Entity = _ILoginApplication.GetAll().Where(m => m.LoginId == LoginId).Single();
            try
            {
                if (Entity.Type == Domain.Util.LoginType.People)
                {
                    Entity.Unity = _ICompanyUnityApplication.GetAll().Where(m => m.CompanyUnityId == Entity.CompanyUnityId).Single();
                }
                
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return Entity;
        }

        /// <summary>
        /// Obtem uma lista de login do sistema
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Domain.Entities.Login> ObterTodos()
        {
            List<Domain.Entities.Login> lista = new List<Domain.Entities.Login>();
            foreach (var User in _ILoginApplication.GetAll())
            {
                lista.Add(this.Obter(User.LoginId));
            }
            return lista;
        }

      
        #endregion

    }
}
