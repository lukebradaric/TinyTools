using UnityEngine;
using UnityEditor;

namespace TinyTools.Audio
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(SoundSO))]
    public class SoundSOEditor : Editor
    {
        int tab = 0;
        public override void OnInspectorGUI()
        {
            // Update SO to get latest values
            serializedObject.Update();

            SoundSO sound = (SoundSO)target;

            tab = GUILayout.Toolbar(tab, new string[] { "Base", "3D" });
            EditorGUILayout.Space();
            switch (tab)
            {
                case 0:
                    DrawBaseGUI(sound);
                    break;
                case 1:
                    Draw3DGUI(sound);
                    break;
            }

            EditorGUILayout.Space();

            if (GUILayout.Button("Test Sound"))
                AudioManager.PlaySoundSO(sound, true);

            // Apply all properties to SO
            serializedObject.ApplyModifiedProperties();
        }

        private void DrawBaseGUI(SoundSO sound)
        {
            // Fields
            EditorGUILayout.PropertyField(serializedObject.FindProperty("clip"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("volume"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("pitch"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("useRandomPitch"));

            // If using random pitch, display random pitch slider
            if (sound.useRandomPitch)
                EditorGUILayout.PropertyField(serializedObject.FindProperty("randomPitch"));

            // Loop field (stop all sounds from playing if loop is toggled off)
            SerializedProperty loopProp = serializedObject.FindProperty("loop");
            bool loop = EditorGUILayout.Toggle("Loop", loopProp.boolValue);

            if (!loop && loopProp.boolValue)
                AudioManager.StopSoundSO(sound);
            //AudioManager.StopTestSoundSO(sound);

            loopProp.boolValue = loop;
        }

        private void Draw3DGUI(SoundSO sound)
        {
            //EditorGUILayout.Popup("3D Settings", 0, )
            EditorGUILayout.PropertyField(serializedObject.FindProperty("spatialBlend"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("dopplerLevel"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("spread"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("rollOffMode"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("minDistance"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("maxDistance"));
        }
    }
}
