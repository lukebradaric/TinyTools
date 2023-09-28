using System.Collections.Generic;
using TinyTools.Core;
using UnityEditor;
using UnityEngine;

namespace TinyTools.Editor
{
    internal static class TinyToolsSettingsEditor
    {
        internal static TinyToolsSettings GetOrCreateSettings()
        {
            TinyToolsSettings settings = AssetDatabase.LoadAssetAtPath<TinyToolsSettings>(TinyToolsConstants.SettingsFilePath);

            if (settings == null)
            {
                if (!AssetDatabase.IsValidFolder(TinyToolsConstants.SettingsFolderPath))
                {
                    AssetDatabase.CreateFolder("Assets", TinyToolsConstants.SettingsFolder);
                }

                settings = ScriptableObject.CreateInstance<TinyToolsSettings>();
                AssetDatabase.CreateAsset(settings, TinyToolsConstants.SettingsFilePath);
                AssetDatabase.SaveAssets();
            }

            return settings;
        }

        [SettingsProvider]
        public static SettingsProvider CreateTinyToolsSettingsProvider()
        {
            HashSet<string> propertyNames = new HashSet<string>();
            var settings = new SerializedObject(GetOrCreateSettings());
            SerializedProperty property = settings.GetIterator();
            while (property.NextVisible(true))
            {
                propertyNames.Add(property.name);
            }

            SettingsProvider provider = new SettingsProvider(TinyToolsConstants.ProjectSettingsPath, SettingsScope.Project)
            {
                label =TinyToolsConstants.Name,
                guiHandler = (searchContext) =>
                {
                    foreach (string propertyName in propertyNames)
                    {
                        EditorGUILayout.PropertyField(settings.FindProperty(propertyName));
                    }
                    settings.ApplyModifiedProperties();
                },
                keywords = propertyNames
            };

            return provider;
        }
    }
}
