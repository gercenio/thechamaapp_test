using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Domain.Core.Events;
using TheChamaApp.Infra.Data.Contexto;
using System.Linq;

namespace TheChamaApp.Infra.Data.Repository.EventSourcing
{
    
    public class EventStoreSQLRepository : IEventStoreRepository
    {
        private readonly Contexto.TheChamaAppContext _DbContext;

        public EventStoreSQLRepository(TheChamaAppContext context)
        {
            _DbContext = context;
        }

        public IList<StoredEvent> All(Guid aggregateId)
        {
            return (from e in _DbContext.StoredEvent where e.AggregateId == aggregateId select e).ToList();
        }

        public void Store(StoredEvent theEvent)
        {
            _DbContext.StoredEvent.Add(theEvent);
            _DbContext.SaveChanges();
        }

        public void Dispose()
        {
            _DbContext.Dispose();
        }

    }
}
