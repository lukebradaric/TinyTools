using UnityEngine;

namespace TinyTools.Extensions
{
    public class SingletonScriptableObject<T> : ScriptableObject where T : SingletonScriptableObject<T>
    {
        private static T instance;
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    T[] assets = Resources.LoadAll<T>("");
                    if (assets == null || assets.Length < 1)
                    {
                        throw new System.Exception($"Could not find instance of {typeof(T).ToString()} in resources.");
                    }
                    else if (assets.Length > 1)
                    {
                        Debug.LogError($"Found multiple instances of {typeof(T).ToString()} in resources.");
                    }
                    instance = assets[0];
                }
                return instance;
            }
        }
    }
}
