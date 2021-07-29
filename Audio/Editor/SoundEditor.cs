using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace TinyTools.Audio
{
    [CustomEditor(typeof(Sound))]
    [CanEditMultipleObjects]
    public class SoundEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Play"))
            {
                Sound sound = (Sound)target;
                sound.Play();
            }
        }
    }
}
