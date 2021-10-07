using UnityEngine;

namespace TinyTools.Extensions
{
    public abstract class Singleton<T> : MonoBehaviour where T : Component
    {
        public static T instance;
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = GameObject.FindObjectOfType<T>();
                    if (instance == null)
                        Debug.LogError($"Could not find instance of {typeof(T).ToString()}!");
                }
                return instance;
            }
        }
    }
}
