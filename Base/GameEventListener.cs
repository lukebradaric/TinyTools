using UnityEngine;
using UnityEngine.Events;

namespace GameEvents
{
    public abstract class GameEventListener<T> : MonoBehaviour
    {
        public GameEventSO<T> gameEvent;
        public UnityEvent<T> unityEvent;

        private void OnEnable() => gameEvent.OnInvoke += RaiseEvent;
        private void OnDisable() => gameEvent.OnInvoke -= RaiseEvent;

        private void RaiseEvent(T item) => unityEvent.Invoke(item);
    }
}
