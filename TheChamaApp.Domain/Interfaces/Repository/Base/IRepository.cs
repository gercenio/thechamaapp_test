using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace TheChamaApp.Domain.Interfaces.Repository.Base
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity _obj);
        void Update(TEntity _obj);
        void Remove(TEntity _obj);
        void Dispose();
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        void Detach(TEntity _obj);
        void Attach(TEntity _obj);
    }
}
