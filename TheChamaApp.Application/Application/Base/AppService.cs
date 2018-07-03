using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using TheChamaApp.Application.IApplication.Base;
using TheChamaApp.Domain.Interfaces.Service.Base;

namespace TheChamaApp.Application.Application.Base
{
    public class AppServiceBase<TEntity> : IDisposable, IAppServiceBase<TEntity> where TEntity : class
    {
        #region # Private members
        private Component component = new Component();
        private bool disposed = false;
        #endregion

        #region # Private Property
        private readonly IService<TEntity> _serviceBase;
        #endregion

        #region # Constructor
        public AppServiceBase(IService<TEntity> serviceBase)
        {
            _serviceBase = serviceBase;
        }
        #endregion

        #region # Methods
        public void Add(TEntity _obj)
        {
            _serviceBase.Add(_obj);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                    component.Dispose();

                disposed = true;
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _serviceBase.GetAll();
        }

        public TEntity GetById(int id)
        {
            return _serviceBase.GetById(id);
        }

        public void Remove(TEntity _obj)
        {
            _serviceBase.Remove(_obj);
        }

        public void Update(TEntity _obj)
        {
            _serviceBase.Update(_obj);
        }

        public void Detach(TEntity _obj)
        {
            _serviceBase.Detach(_obj);
        }

        public void Attach(TEntity _obj)
        {
            _serviceBase.Attach(_obj);
        }


        #endregion
    }
}
