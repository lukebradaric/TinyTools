using UnityEngine;
using UnityEngine.Events;

namespace TinyTools.ScriptableEvents
{
    public abstract class ScriptableEventListener<T, TEvent> : MonoBehaviour where TEvent : ScriptableEvent
    {
        [SerializeField] private TEvent _scriptableEvent;
        [SerializeField] protected UnityEvent<T> _onRaised;

        private void OnEnable()
        {
            _scriptableEvent.AddListener(this.OnRaised);
        }

        public virtual void OnRaised(object value)
        {
            _onRaised.Invoke((T)value);
        }
    }
}
