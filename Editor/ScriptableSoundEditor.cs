using TinyTools.ScriptableSounds;
using UnityEditor;
using UnityEngine;

namespace TinyTools.Editor
{
    [CustomEditor(typeof(ScriptableSound), true)]
    [CanEditMultipleObjects]
    internal class ScriptableSoundEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            EditorGUILayout.Space();
            if (GUILayout.Button("Play"))
                ((ScriptableSound)target).PlayEditor();
        }
    }
}
