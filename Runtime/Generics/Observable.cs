using System;
using UnityEngine;

namespace TinyTools.Generics
{
    [Serializable]
    public class Observable<T>
    {
        public Observable()
        {
            _value = default;
        }

        public Observable(T value)
        {
            _value = value;
        }

        [SerializeField] private T _value;
        public T Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (_value.Equals(value))
                {
                    return;
                }

                ValueChanging?.Invoke(_value, value);
                _value = value;
                ValueChanged?.Invoke(_value);
            }
        }

        // When the value has been changed
        public event Action<T> ValueChanged;
        // When the value is going to change (current, new)
        public event Action<T, T> ValueChanging;
    }
}
