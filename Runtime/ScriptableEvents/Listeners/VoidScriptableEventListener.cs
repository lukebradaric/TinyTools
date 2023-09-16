using UnityEngine;
using UnityEngine.Events;

namespace TinyTools.ScriptableEvents
{
    public class VoidScriptableEventListener : MonoBehaviour
    {
        [SerializeField] private VoidScriptableEvent _scriptableEvent;
        [SerializeField] protected UnityEvent _onRaised;

        private void OnEnable()
        {
            _scriptableEvent.AddListener(this.OnRaised);
        }

        public virtual void OnRaised(object obj)
        {
            _onRaised.Invoke();
        }
    }
}
