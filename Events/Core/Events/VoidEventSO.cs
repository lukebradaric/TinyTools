using UnityEngine;
using UnityEngine.Events;

namespace TinyTools.Events
{
    [CreateAssetMenu(menuName = "Game Events/Void Event")]
    public class VoidEventSO : ScriptableObject
    {
        public UnityAction OnInvoke;
        public virtual void Invoke() => OnInvoke?.Invoke();
    }
}