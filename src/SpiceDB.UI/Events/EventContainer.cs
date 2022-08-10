using System;
using System.Collections.Generic;
using System.Linq;

namespace SpiceDB.UI.Events
{
    public static class EventContainer
    {
        public static Dictionary<EventType, List<Action<EventArg>>> eventMap = new Dictionary<EventType, List<Action<EventArg>>>();
        public static Dictionary<EventType, List<Func<EventArg, Task>>> asyncEventMap = new Dictionary<EventType, List<Func<EventArg, Task>>>();

        public static void SubscribeEvent(EventType eventName, Action<EventArg> eventHandler)
        {
            List<Action<EventArg>> evenHandlers = new List<Action<EventArg>>();

            if (eventMap.ContainsKey(eventName))
            {
                evenHandlers = eventMap[eventName];
            }

            evenHandlers.Add(eventHandler);
            eventMap[eventName] = evenHandlers;
        }

        public static void SubscribeEvent(EventType eventName, Func<EventArg, Task> eventHandler)
        {
            var evenHandlers = new List<Func<EventArg, Task>>();

            if (eventMap.ContainsKey(eventName))
            {
                evenHandlers = asyncEventMap[eventName];
            }

            evenHandlers.Add(eventHandler);
            asyncEventMap[eventName] = evenHandlers;
        }

        public static void UnSubscribeEvent(EventType eventName, Action<EventArg> eventHandler)
        {
            var evenHandlers = new List<Action<EventArg>>();

            if (eventMap.ContainsKey(eventName))
            {
                evenHandlers = eventMap[eventName];
            }

            evenHandlers.Remove(eventHandler);
            eventMap[eventName] = evenHandlers;
        }

        public static void UnSubscribeEvent(EventType eventName, Func<EventArg, Task> eventHandler)
        {
            var asyncEvenHandlers = new List<Func<EventArg, Task>>();

            if (asyncEventMap.ContainsKey(eventName))
            {
                asyncEvenHandlers = asyncEventMap[eventName];
            }

            asyncEvenHandlers.Remove(eventHandler);
            asyncEventMap[eventName] = asyncEvenHandlers;
        }

        public static void PublishEvent(EventType eventName)
        {
            PublishEvent(eventName, null);
        }
        public static void PublishEvent(EventType eventName, EventArg parameter)
        {
            if (eventMap.ContainsKey(eventName))
            {
                ExecuteHandlers(eventMap[eventName], parameter);
            }
        }

        public static async Task PublishEventAsync(EventType eventName)
        {
            await PublishEventAsync(eventName, null);
        }
        public static async Task PublishEventAsync(EventType eventName, EventArg parameter)
        {
            if (asyncEventMap.ContainsKey(eventName))
            {
                await ExecuteHandlersAsync(asyncEventMap[eventName], parameter);
            }
        }

        private static void ExecuteHandlers(List<Action<EventArg>> evenHandlers, EventArg parameter)
        {
            foreach (var action in evenHandlers)
            {
                action(parameter);
            }
        }

        private static async Task ExecuteHandlersAsync(List<Func<EventArg, Task>> evenHandlers, EventArg parameter)
        {
            foreach (var action in evenHandlers)
            {
                await action(parameter);
            }
        }

        public static void UnSubscribeAll(object target)
        {
            UnAllSubscribeActions(target);
            UnAllSubscribeAsyncActions(target);
        }

        private static void UnAllSubscribeAsyncActions(object target)
        {
            var keys = asyncEventMap.Keys.ToList();
            foreach (var key in keys)
            {
                var asyncEvenHandlers = asyncEventMap[key];
                var asyncAcctions = asyncEvenHandlers.FindAll(x => ReferenceEquals(target, x.Target));
                foreach (var asyncAction in asyncAcctions)
                {
                    UnSubscribeEvent(key, asyncAction);
                }
            }
        }

        private static void UnAllSubscribeActions(object target)
        {
            var keys = eventMap.Keys.ToList();
            foreach (var key in keys)
            {
                var evenHandlers = eventMap[key];
                var actions = evenHandlers.FindAll(x => ReferenceEquals(target, x.Target));
                foreach (var action in actions)
                {
                    UnSubscribeEvent(key, action);
                }
            }
        }
    }
}
