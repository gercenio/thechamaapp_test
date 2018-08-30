using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Application.IApplication;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using System.ComponentModel;

namespace TheChamaApp.Service.EvaluatedBusiness
{
    public class EvaluatedService : Base.ServiceBase
    {
        #region # Propriedades
        private readonly IEvaluatedApplication _IEvaluatedApplication;
        private readonly ICompanyUnityApplication _ICompanyUnityApplication;
        #endregion

        #region # Constructor
        public EvaluatedService(IEvaluatedApplication evaluated
            , ICompanyUnityApplication companyUnityApplication)
        {
            _IEvaluatedApplication = evaluated;
            _ICompanyUnityApplication = companyUnityApplication;
        }
        #endregion

        #region # Methods

        /// <summary>
        /// Realiza a inclusão de um novo registro
        /// </summary>
        /// <param name="Entity"></param>
        /// <param name="Mensagem"></param>
        /// <returns></returns>
        public Domain.Entities.Evaluated Incluir(Domain.Entities.Evaluated Entity, out string Mensagem)
        {
            try
            {
                var UnityList = _ICompanyUnityApplication.GetAll().Where(m => m.CompanyUnityId == Entity.CompanyUnityId).ToList();
                if (UnityList.Count > 0)
                {
                    _IEvaluatedApplication.Add(Entity);
                    Mensagem = Entity.EvaluatedId.ToString();
                }
                else {
                    Mensagem = "Unity is not found !!!";
                }
                    
            }
            catch (Exception Ex)
            {
                Mensagem = string.Format("Erro:{0}", Ex.Message);
            }
            return Entity;
        }

        /// <summary>
        /// Realiza a alteração de um registro
        /// </summary>
        /// <param name="Entity"></param>
        /// <param name="Mensagem"></param>
        public void Alterar(Domain.Entities.Evaluated Entity, out string Mensagem)
        {
            Mensagem = string.Empty;
            try
            {
                var OriginalList = _IEvaluatedApplication.GetAll().Where(m => m.EvaluatedId == Entity.EvaluatedId).ToList();
                if (OriginalList.Count > 0) {
                    _IEvaluatedApplication.Update(Entity);
                    Mensagem = "Done";
                }
            }
            catch (Exception Ex)
            {
                Mensagem = string.Format("Erro:{0}", Ex.Message);
            }
        }

        /// <summary>
        /// Realiza a exclusão de um registro
        /// </summary>
        /// <param name="EvaluatedId"></param>
        /// <param name="Mensagem"></param>
        public void Excluir(int EvaluatedId, out string Mensagem)
        {
            Mensagem = string.Empty;
            try
            {
                var Orginal = _IEvaluatedApplication.GetAll().Where(m => m.EvaluatedId == EvaluatedId).Single();
                if (Orginal != null) {
                    _IEvaluatedApplication.Remove(Orginal);
                    Mensagem = "Done";
                }
                
            }
            catch (Exception Ex)
            {
                Mensagem = string.Format("Erro:{0}", Ex.Message);
            }
        }

        /// <summary>
        /// Obtem uma avaliado
        /// </summary>
        /// <param name="EvaluatedId"></param>
        /// <returns></returns>
        public Domain.Entities.Evaluated Obter(int EvaluatedId)
        {
            return _IEvaluatedApplication.GetAll().Where(m => m.EvaluatedId == EvaluatedId).Single();
        }

        /// <summary>
        /// Obtem uma lista de avaliados por unidade
        /// </summary>
        /// <param name="CompanyUnityId"></param>
        /// <returns></returns>
        public IEnumerable<Domain.Entities.Evaluated> ObterTodosPorUnidade(int CompanyUnityId)
        {
            return _IEvaluatedApplication.GetAll().Where(m => m.CompanyUnityId == CompanyUnityId).ToList();
        }

        /// <summary>
        /// Realiza a importação de avaliado
        /// </summary>
        /// <param name="lista"></param>
        /// <param name="Mensagem"></param>
        public void Importa(List<Domain.Entities.Evaluated> lista, out string Mensagem)
        {
            Mensagem = string.Empty;
            foreach (var Avaliado in lista)
            {
                this.Incluir(Avaliado,out Mensagem);
            }
        }

        /// <summary>
        /// Obtem um avaliado passando a descrição dele
        /// </summary>
        /// <param name="Description"></param>
        /// <returns></returns>
        public IEnumerable<Domain.Entities.Evaluated> ObterByDescription(string Description)
        {
            List<Domain.Entities.Evaluated> lista = new List<Domain.Entities.Evaluated>();
            foreach (var Avaliado in _IEvaluatedApplication.GetAll().Where(m => m.Description.Contains(Description)).ToList())
            {
                lista.Add(this.Obter(Avaliado.EvaluatedId));
            }
            return lista;
        }

        

        #endregion

        

    }
}
