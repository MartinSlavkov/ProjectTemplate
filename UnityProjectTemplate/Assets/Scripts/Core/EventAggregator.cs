using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public interface IEvent { }

    public delegate void EventHandler<T>(T evt) where T : IEvent;

    //TODO: pridat register once
    //TODO: register with priority

    public class EventAggregator
    {
        private IDictionary<Type, IList<EventHandler<IEvent>>> handlers;
        private IDictionary<Type, IEvent> eventInstancePool;

        public EventAggregator()
        {
            handlers = new Dictionary<Type, IList<EventHandler<IEvent>>>();
            eventInstancePool = new Dictionary<Type, IEvent>();
        }

        public void Register<T>(EventHandler<T> handler) where T : IEvent
        {
            if (!handlers.ContainsKey(typeof(T)))
            {
                handlers[typeof(T)] = new List<EventHandler<IEvent>>();
            }

            var handlerListNew = handlers[typeof(T)];
            handlerListNew.Add(evt => handler((T)evt));
        }

        public void Unregister<T>(EventHandler<T> handler) where T : IEvent
        {
            IList<EventHandler<IEvent>> handlerList;
            
            if (handlers.TryGetValue(typeof(T), out handlerList))
            {
                handlerList.Remove(handler as EventHandler<IEvent>);
            }
        }

        //TODO - add possibility to trigger just with the type, for events without parameters, to not create instance of the event

        private IEvent GetEventInstance(Type eventType)
        {
            IEvent eventInstance;
            if (!eventInstancePool.TryGetValue(eventType, out eventInstance))
            {
                eventInstance = Activator.CreateInstance(eventType) as IEvent;
                if (eventInstance != null)
                {
                    eventInstancePool.Add(eventType, eventInstance);
                }
            }

            return eventInstance;
        }

        public void Trigger(Type eventType)
        {
            Trigger(GetEventInstance(eventType));
        }

        public void Trigger(IEvent evt)
        {
            IList<EventHandler<IEvent>> handlerList;

            if (handlers.TryGetValue(evt.GetType(), out handlerList))
            {
                foreach (EventHandler<IEvent> handler in handlerList)
                {
                    handler.Invoke(evt);
                }
            }
        }
    }
}
