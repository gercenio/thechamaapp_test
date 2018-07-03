using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using TheChamaApp.Domain.Interfaces.Repository.Base;
using TheChamaApp.Domain.Interfaces.Service.Base;

namespace TheChamaApp.Domain.Services.Base
{
    
    public class Service<TEnity> : IDisposable, IRepository<TEnity> where TEnity : class
    {

        #region # Property readonly
        private readonly IRepository<TEnity> _repository;
        #endregion

        #region # Constructor
        public Service(IRepository<TEnity> repository)
        {
            _repository = repository;
        }
        #endregion

        #region # Methods
        public void Add(TEnity _obj)
        {
            _repository.Add(_obj);
        }

        public IEnumerable<TEnity> GetAll()
        {
            return _repository.GetAll();
        }

        public TEnity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Remove(TEnity _obj)
        {
            _repository.Remove(_obj);
        }

        public void Update(TEnity _obj)
        {
            _repository.Update(_obj);
        }

        public void Detach(TEnity _obj)
        {
            _repository.Detach(_obj);
        }

        public void Attach(TEnity _obj)
        {
            _repository.Attach(_obj);
        }

        #endregion

        #region # IDisposable Members

        private Component component = new Component();
        private bool disposed = false;

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

        #endregion
    }
}
