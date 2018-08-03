using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using TheChamaApp.Domain.Interfaces.Repository.Base;

namespace TheChamaApp.Infra.Data.Repository.Base
{
    
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        #region Property

        protected Contexto.TheChamaAppContext Db = new Contexto.TheChamaAppContext();
        protected DbSet<TEntity> DbSet = new Contexto.TheChamaAppContext().Set<TEntity>();

        public IDbConnection Conn { get; set; }


        #endregion

        #region # Constructor

        public Repository()
        {

        }

        //public Repository(IDapperContexto context)
        //{
        //    Conn = context.Connection;
        //    InicializaMapperDapper();
        //}

        #endregion

        #region # Dapper

        public static void InicializaMapperDapper()
        {
            //DapperExtensions.DapperExtensions.SetMappingAssemblies(new[] { typeof(PvMapper).Assembly });
            //DapperExtensions.DapperExtensions.SetMappingAssemblies(new[] { typeof(SkuMapper).Assembly });

        }

        #endregion

        #region # Methods

        public void Add(TEntity _obj)
        {
            Db.Set<TEntity>().Add(_obj);
            Db.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Db.Set<TEntity>().AsNoTracking().ToList();
        }

        public TEntity GetById(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public void Remove(TEntity _obj)
        {
            Db.Set<TEntity>().Remove(_obj);
            Db.SaveChanges();
        }

        public void Update(TEntity _obj)
        {
            Db.Entry(_obj).State = EntityState.Modified;

            Db.SaveChanges();
        }

        public void Detach(TEntity _obj)
        {
            Db.Entry(_obj).State = EntityState.Detached;
        }

        public void Attach(TEntity _obj)
        {
            DbSet.Attach(_obj);
        }



        #endregion

        #region # IDisponsable
        
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
