using System;
using UnityEngine;

namespace TinyTools.ScriptableEvents
{
    [CreateAssetMenu(menuName = "TinyTools/ScriptableEvents/VoidScriptableEvent")]
    public class VoidScriptableEvent : ScriptableEvent<Type>
    {
        public void Raise()
        {
            base.Raise(null);
        }
    }
}
