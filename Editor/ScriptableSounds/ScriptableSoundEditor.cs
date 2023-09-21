using UnityEditor;
using UnityEngine;

namespace TinyTools.ScriptableSounds.Editor
{
    [CustomEditor(typeof(ScriptableSound), true)]
    [CanEditMultipleObjects]
    public class ScriptableSoundEditor : UnityEditor.Editor
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
