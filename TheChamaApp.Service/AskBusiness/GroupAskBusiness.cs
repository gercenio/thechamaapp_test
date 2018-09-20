using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Application.IApplication;
using System.Linq;

namespace TheChamaApp.Service.AskBusiness
{
    public class GroupAskBusiness: Base.ServiceBase
    {
        #region # Propriedades
        private readonly IGroupAskApplication _IGroupAskApplication;
        #endregion

        #region # Constructor
        public GroupAskBusiness(IGroupAskApplication groupAskApplication)
        {
            _IGroupAskApplication = groupAskApplication;
        }
        #endregion

        #region # Methods

        /// <summary>
        /// Obtem uma lista de todos os grupos
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Domain.Entities.GroupAsk> ObtemTodos()
        {
            return _IGroupAskApplication.GetAll();
        }

        /// <summary>
        /// Obtem um grupo
        /// </summary>
        /// <param name="GroupAskId"></param>
        /// <returns></returns>
        public Domain.Entities.GroupAsk Obter(int GroupAskId)
        {
            return _IGroupAskApplication.GetAll().Where(m => m.GroupAskId == GroupAskId).Single();
        }

        #endregion
    }
}
