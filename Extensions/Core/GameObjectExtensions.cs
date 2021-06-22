using UnityEngine;

namespace TinyTools.Extensions
{
    public static class GameObjectExtensions
    {
        /// <summary>
        /// Return a component after finding it or creating it.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="gameObject"></param>
        /// <returns>Component found/created</returns>
        public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            if (gameObject.TryGetComponent<T>(out T requestedComponent))
                return requestedComponent;

            return gameObject.AddComponent<T>();
        }
    }
}
