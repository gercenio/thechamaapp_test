using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Domain.Core.Events;

namespace TheChamaApp.Infra.Data.Repository.EventSourcing
{
    public interface IEventStoreRepository 
    {
        void Store(StoredEvent theEvent);
        IList<StoredEvent> All(Guid aggregateId);
    }
}
