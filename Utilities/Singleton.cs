using System;
using UnityEngine;

namespace HotBloodr
{
    public class Singleton<T> where T : class
    {
        private static T m_instance;

        public static T I
        {
            get
            {
                if (m_instance == null)
                {
                    m_instance = CreateInstance();
                }

                return m_instance;
            }
        }

        private static T CreateInstance()
        {
            var type = typeof(T);
            return Activator.CreateInstance(type, true) as T;
        }
    }

    public abstract class ResourcesScriptableSingleton<T> : ScriptableObject where T : ResourcesScriptableSingleton<T>
    {
        private static T m_instance;

        public static T I
        {
            get
            {
                if (m_instance == null)
                {
                    m_instance = Resources.Load<T>(typeof(T).Name);
                }

                return m_instance;
            }
        }
    }
}