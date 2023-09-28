#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;

namespace TinyTools.Core
{
    public class TinyToolsSettings : ScriptableObject
    {
        [Space]
        [Header("Sound")]
        [Tooltip("Should there be a limit on how many times one Audio Asset can be played in a second? (Helps to reduce sound clutter)")]
        [SerializeField] private bool _enablePlayRateLimit = false;
        public bool EnablePlayRateLimit => _enablePlayRateLimit;

        [Tooltip("The maximum amount of times an Audio Asset can be played in one second. (Eg. 10 = 10 times per second)")]
        [SerializeField] private float _maxPlayRatePerSecond = 10;
        public float MaxPlayRatePerSecond => _maxPlayRatePerSecond;

        [Tooltip("Time waited after playing audio before it is returned to the pool. (Prevents clipping)")]
        [SerializeField] private float _audioPlaytimeBuffer = 0.15f;
        public float AudioPlaytimeBuffer => _audioPlaytimeBuffer;

        public static TinyToolsSettings LoadSettings()
        {
            TinyToolsSettings settings = Resources.Load<TinyToolsSettings>(nameof(TinyToolsSettings));

#if UNITY_EDITOR
            if (settings == null)
            {
                settings = GetOrCreateSettings();
            }
#endif

            if (settings == null)
            {
                Debug.LogError($"Unable to load TinyToolsSettings! Is the file in the correct path? {TinyToolsConstants.SettingsFilePath}");
            }

            return settings;
        }

#if UNITY_EDITOR
        public static TinyToolsSettings GetOrCreateSettings()
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
#endif
    }
}
