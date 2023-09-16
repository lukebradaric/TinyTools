using System;
using System.Collections.Generic;
using UnityEngine;

namespace TinyTools.ScriptableEvents
{
    public abstract class BaseScriptableEvent<T> : BaseScriptableEvent
    {
        public void Raise(T value)
        {
            for (int i = _listeners.Count - 1; i >= 0; i--)
            {
                _listeners[i].Invoke(value);
            }
        }
    }

    public abstract class BaseScriptableEvent : ScriptableObject
    {
        [TextArea]
        [Tooltip("What is this ScriptableEvent used for?")]
        [SerializeField] private string _description;

        protected readonly List<Action<object>> _listeners = new List<Action<object>>();

        private void OnDisable()
        {
            _listeners.Clear();
        }

        public void AddListener(Action<object> listener)
        {
            _listeners.Add(listener);
        }

        public void RemoveListener(Action<object> listener)
        {
            _listeners.Remove(listener);
        }
    }
}
