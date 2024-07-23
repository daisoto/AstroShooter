using System;
using System.Collections.Generic;
using GameLogic.Interfaces;
using UniRx;

namespace GameLogic
{
    public class EventBus: IEventBus
    {
        private Dictionary<Type, ReactiveCommand<object>> _dictionary = new();

        public void Register(Type eventType)
        {
            _dictionary[eventType] = new();
        }

        public void Dispatch<T>(T evt)
        {
            _dictionary[typeof(T)].Execute(evt);
        }

        public IDisposable Subscribe<T>(Action<T> action)
        {
            return _dictionary[typeof(T)].Subscribe(evt => action.Invoke((T)evt));
        }
    }
}