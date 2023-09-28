using System;
using System.Reflection;
using UnityEngine;

namespace TinyTools.AutoLoad
{
    public class AutoLoadManager
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Load()
        {
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (Type type in assembly.GetTypes())
                {
                    if (type.GetCustomAttributes(typeof(AutoLoadAttribute), true).Length > 0)
                    {
                        // If object already exists, don't load
                        if (UnityEngine.Object.FindObjectOfType(type) != null)
                        {
                            Debug.LogWarning($"{type.Name} already exists.");
                            continue;
                        }

                        // If object is not of MonoBehaviour type, don't load
                        if (!type.IsSubclassOf(typeof(MonoBehaviour)))
                        {
                            Debug.LogError($"{nameof(AutoLoadAttribute)} cannot be applied to non-MonoBehaviour. ({type.Name})");
                            continue;
                        }

                        // Instantiate gameobject
                        GameObject gameObject = new GameObject(type.Name);
                        gameObject.AddComponent(type);

                        // Mark gameObject to not be destroyed
                        GameObject.DontDestroyOnLoad(gameObject);
                    }
                }
            }
        }
    }
}
