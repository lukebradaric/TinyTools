using UnityEngine;

namespace TinyTools.Generics
{
    public class Singleton<T> : MonoBehaviour where T : Component
    {
        private static T _instance;
        public static T Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<T>();
                return _instance;
            }
        }

        protected virtual void Awake()
        {
            if (_instance == null)
                _instance = this as T;
            else if (_instance != this as T)
            {
                Debug.LogWarning($"More than one instance of {typeof(T).Name}! Destroying.");
                Destroy(gameObject);
            }
        }
    }
}
