using UnityEngine;

namespace TinyTools.Extensions
{
    public static class ScriptableObjectExtensions
    {
        /// <summary>
        /// Returns a clone of the ScriptableObject
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="scriptableObject"></param>
        /// <returns></returns>
        public static T GetClone<T>(this T scriptableObject) where T : ScriptableObject
        {
            if (scriptableObject == null)
            {
                Debug.LogError($"ScriptableObject was null. Returning default {typeof(T)} object.");
                return (T)ScriptableObject.CreateInstance(typeof(T));
            }

            T instance = Object.Instantiate(scriptableObject);
            instance.name = scriptableObject.name; // remove (Clone) from name
            return instance;
        }
    }
}
