using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public interface IEvent
    {

    }

    public delegate void EventHandler<T>(T evt) where T : IEvent;


    /*public interface IRegisterable
    {
        void RegisterMeWith(EventAggregator aggregator);
        void UnregisterMeFrom(EventAggregator aggregator);
    }*/

    public class EventAggregator
    {

        IDictionary<Type, IList<EventHandler<IEvent>>> handlers;

        IList<EventHandler<IEvent>> handlerList;


        public EventAggregator()
        {
            handlers = new Dictionary<Type, IList<EventHandler<IEvent>>>();
            handlerList = new List<EventHandler<IEvent>>();
        }

        /*public void Register(IRegisterable registerable)
        {
            registerable.RegisterMeWith(this);
        }*/


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
            handlerList.Clear();
            if (handlers.TryGetValue(typeof(T), out handlerList))
            {
                handlerList.Remove(handler as EventHandler<IEvent>);
            }
        }


        //TODO - add possibility to trigger just with the type, for events without parameters, to not create instance of the event
        public void Trigger(IEvent evt)
        {
            handlerList.Clear();
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
