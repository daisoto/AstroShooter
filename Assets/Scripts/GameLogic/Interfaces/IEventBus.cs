using System;

namespace GameLogic.Interfaces
{
    public interface IEventBus
    {
        void Register(Type eventType);
        
        void Dispatch<T>(T evt);

        IDisposable Subscribe<T>(Action<T> action);
    }
}