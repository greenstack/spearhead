using System;
using System.Collections.Generic;

namespace Spearhead
{
    public class EventManager : IEventManager
    {
        private readonly Dictionary<Type, IEventDispatcher> _dispatchers = new();

        public void RaiseEvent<T>(T battleEvent) where T : IBattleEvent
        {
            _dispatchers[typeof(T)].Dispatch(battleEvent);
        }

        public void RegisterEvent<T>(IEventDispatcher dispatcher) where T : IBattleEvent
        {
            _dispatchers.Add(typeof(T), dispatcher);
        }
    }
}