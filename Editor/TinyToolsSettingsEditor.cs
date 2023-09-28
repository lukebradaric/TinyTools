using System.Collections.Generic;
using TinyTools.Core;
using UnityEditor;

namespace TinyTools.Editor
{
    internal static class TinyToolsSettingsEditor
    {
        [SettingsProvider]
        public static SettingsProvider CreateTinyToolsSettingsProvider()
        {
            HashSet<string> propertyNames = new HashSet<string>();
            var settings = new SerializedObject(TinyToolsSettings.GetOrCreateSettings());
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
