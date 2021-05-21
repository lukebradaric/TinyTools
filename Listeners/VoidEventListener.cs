using UnityEngine;
using UnityEngine.Events;

namespace GameEvents
{
    public class VoidEventListener : MonoBehaviour
    {
        public VoidEventSO gameEvent;
        public UnityEvent unityEvent;

        private void OnEnable() => gameEvent.OnInvoke += RaiseEvent;
        private void OnDisable() => gameEvent.OnInvoke -= RaiseEvent;

        private void RaiseEvent() => unityEvent.Invoke();
    }
}
