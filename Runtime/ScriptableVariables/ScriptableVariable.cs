using UnityEngine;

namespace TinyTools.ScriptableVariables
{
    public abstract class ScriptableVariable<T> : ScriptableObject
    {
        [SerializeField] private T _value;
        public T Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (_readOnly)
                {
                    Debug.LogWarning($"Tried to set read only value of {name}.");
                    return;
                }

                _value = value;
            }
        }

        [Space]
        [Header("Options")]
        [SerializeField] private bool _readOnly = true;
        [TextArea][SerializeField] private string _description;
    }
}
