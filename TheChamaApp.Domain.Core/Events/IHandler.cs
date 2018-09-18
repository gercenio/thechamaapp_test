using System;
using System.Collections.Generic;
using System.Text;

namespace TheChamaApp.Domain.Core.Events
{
    public interface IHandler<in T> where T : Message
    {
        void Handle(T message);

    }
}
