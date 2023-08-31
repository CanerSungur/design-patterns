using UnityEngine;

namespace DesignPatterns.Singleton
{
    public abstract class SingletonBase<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance = null;
        private static readonly object _lock = new object();

        public static T Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        Debug.Log("Singleton instance is null. Trying to find it...");
                        _instance = FindObjectOfType<T>();

                        if (_instance == null)
                        {
                            Debug.Log("Couldn't find Singleton instance. Creating new one.");

                            GameObject singletonObject = new GameObject("Singleton_Object");
                            _instance = singletonObject.AddComponent<T>();
                            DontDestroyOnLoad(singletonObject);
                        }
                    }

                    return _instance;
                }
            }
        }
    }
}
