using System;
using System.Collections.Generic;
using System.Text;

namespace EntitiesTests
{
    public class Singleton<T> where T : new()
    {
        private Singleton() { }

        public static void Init()
        {
            _Instance = default(T);
        }

        private static T _Instance = default(T);
        public static T Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new T();
                }

                return _Instance;
            }
        }
    }
}
