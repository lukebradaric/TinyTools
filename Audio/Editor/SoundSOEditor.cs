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

            tab = GUILayout.Toolbar(tab, new string[] { "Settings", "3D Settings" });
            EditorGUILayout.Space();
            switch (tab)
            {
                case 0:
                    DrawSettingsGUI(sound);
                    break;
                case 1:
                    Draw3DSettingsGUI();
                    break;
            }

            EditorGUILayout.Space();

            // Draw test sound button
            DrawTestButton(sound);

            // If sound is currently looping, draw stop button
            DrawStopButton(sound);

            // Apply all properties to SO
            serializedObject.ApplyModifiedProperties();
        }

        private void DrawSettingsGUI(SoundSO sound)
        {
            // Draw clip fields
            DrawClip(sound);

            EditorGUILayout.Space();

            // priority field
            EditorGUILayout.PropertyField(serializedObject.FindProperty("priority"));
            DrawSliderLabel("High", "Low");

            // volume & pitch fields
            EditorGUILayout.PropertyField(serializedObject.FindProperty("volume"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("pitch"));

            // pitch variation
            EditorGUILayout.PropertyField(serializedObject.FindProperty("pitchVariation"));
            DrawSliderLabel("None", "1");

            EditorGUILayout.Space();

            // Loop field (stop all sounds from playing if loop is toggled off)
            SerializedProperty loopProp = serializedObject.FindProperty("loop");
            bool loop = EditorGUILayout.Toggle("Loop", loopProp.boolValue);

            // If turned loop off
            if (!loop && loopProp.boolValue)
                AudioManager.StopSoundSO(sound);

            // set loop value (of SoundSO)
            loopProp.boolValue = loop;

            // timeBetweenLoop
            if (loop)
                EditorGUILayout.PropertyField(serializedObject.FindProperty("timeBetweenLoop"));
        }

        private void Draw3DSettingsGUI()
        {
            // Spatial blend
            EditorGUILayout.PropertyField(serializedObject.FindProperty("spatialBlend"));
            DrawSliderLabel("2D", "3D");

            // Fields
            EditorGUILayout.PropertyField(serializedObject.FindProperty("dopplerLevel"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("spread"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("rollOffMode"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("minDistance"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("maxDistance"));
        }

        // Draw list or single clip(s)
        private void DrawClip(SoundSO sound)
        {
            // Start horizontal line
            GUILayout.BeginHorizontal();

            // draw single clip
            if (!sound.useList)
            {
                EditorGUILayout.PropertyField(serializedObject.FindProperty("clip"));
                if (GUILayout.Button("List", GUILayout.Width(50)))
                    sound.useList = true;
            }
            // draw list of clips
            else
            {
                EditorGUILayout.PropertyField(serializedObject.FindProperty("clips"));
                if (GUILayout.Button("Single", GUILayout.Width(50)))
                    sound.useList = false;
            }

            // end horizontal line
            GUILayout.EndHorizontal();
        }

        // Draw a label below a slider field
        private void DrawSliderLabel(string leftLabel, string rightLabel)
        {
            // Get two lines for the control
            Rect position = EditorGUILayout.GetControlRect(false, EditorGUIUtility.singleLineHeight);
            position.x += EditorGUIUtility.labelWidth;

            //54 seems to be the width of the slider's float field
            position.width -= EditorGUIUtility.labelWidth + 54;

            // set style and fontsize of labels
            GUIStyle style = GUI.skin.label;
            style.fontSize = 10;

            style.alignment = TextAnchor.UpperLeft; EditorGUI.LabelField(position, leftLabel, style);
            style.alignment = TextAnchor.UpperRight; EditorGUI.LabelField(position, rightLabel, style);
        }

        // Draws TestSoundSO button
        private void DrawTestButton(SoundSO sound)
        {
            if (GUILayout.Button("Test Sound"))
                AudioManager.PlaySoundSO(sound, true);
        }

        // Draws StopSoundSO button
        private void DrawStopButton(SoundSO sound)
        {
            if (!sound.looping)
                return;

            if (GUILayout.Button("Stop"))
                AudioManager.StopSoundSO(sound);
        }
    }
}
