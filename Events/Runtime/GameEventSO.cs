using UnityEngine;
using UnityEngine.Events;

namespace TinyTools.Events
{
    public abstract class GameEventSO<T> : ScriptableObject
    {
        public UnityAction<T> OnInvoke;
        public virtual void Invoke(T item) => OnInvoke?.Invoke(item);
    }
}
