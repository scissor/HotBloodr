using System;
using System.Collections.Generic;

namespace HotBloodr
{
    public static class EventNotifier<T> where T : IHotEvent
    {
        private static List<Action<T>> m_callbacks = new List<Action<T>>();

        public static void Add(Action<T> callback)
        {
            if (!m_callbacks.Contains(callback))
            {
                m_callbacks.Add(callback);
            }
        }

        public static void Remove(Action<T> callback)
        {
            if (m_callbacks.Contains(callback))
            {
                m_callbacks.Remove(callback);
            }
        }

        public static void Notify(T hotEvent)
        {
            foreach (var callback in m_callbacks)
            {
                callback(hotEvent);
            }
        }

        public static void Clear()
        {
            m_callbacks.Clear();
        }
    }
}