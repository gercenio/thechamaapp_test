using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TheChamaApp.Domain.Core.Commands;
using TheChamaApp.Domain.Core.Events;

namespace TheChamaApp.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
