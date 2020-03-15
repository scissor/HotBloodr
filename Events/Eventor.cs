using System;
using System.Collections.Generic;

namespace HotBloodr
{
    public static class Eventor
    {
        private static Dictionary<Type, List<Action<IHotEvent>>> m_listeners = new Dictionary<Type, List<Action<IHotEvent>>>();

        public static void Subscribe<T>(Action<T> callback) where T : IHotEvent
        {
            EventNotifier<T>.Add(callback);
        }

        public static void Unsubscribe<T>(Action<T> callback) where T : IHotEvent
        {
            EventNotifier<T>.Remove(callback);
        }

        public static void Notify<T>(T hotEvent) where T : IHotEvent
        {
            EventNotifier<T>.Notify(hotEvent);
        }

        public static void Clear<T>() where T : IHotEvent
        {
            EventNotifier<T>.Clear();
        }
    }
}