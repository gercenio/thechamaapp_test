using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace TheChamaApp.Infra.Data.Interfaces
{
    public interface IUnitOfWork
    {
        IDapperContexto Context { get; }
        IDbTransaction Transaction { get; }
        IDbTransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Snapshot);
        void Commit();
        void Rollback();
    }
}
