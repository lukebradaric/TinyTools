using System.Collections;
using System.Collections.Generic;
using TinyTools.AutoLoad;
using TinyTools.Core;
using TinyTools.Generics;
using UnityEngine;

namespace TinyTools.ScriptableSounds
{
    [AutoLoad]
    internal class ScriptableSoundManager : Singleton<ScriptableSoundManager>
    {
        private static TinyToolsSettings _settings;
        public static TinyToolsSettings Settings
        {
            get
            {
                if (_settings == null)
                    _settings = TinyToolsSettings.LoadSettings();

                return _settings;
            }
        }

        private static ScriptableSoundPool _scriptableSoundPool = new ScriptableSoundPool();

        private static HashSet<ScriptableSound> _playRateLimits = new HashSet<ScriptableSound>();

        protected override void Awake()
        {
            base.Awake();

            if (Settings.EnablePlayRateLimit)
            {
                StartCoroutine(PlayRateLimitCoroutine());
            }
        }

        public static void Release(ScriptableSoundObject scriptableSoundObject)
        {
            _scriptableSoundPool.Release(scriptableSoundObject);
        }

        public static void Play(ScriptableSound scriptableSound, bool editorOnly = false)
        {
            if (scriptableSound == null)
            {
                Debug.LogWarning("Cannot play null ScriptableSound.");
                return;
            }

            if (Settings.EnablePlayRateLimit && !editorOnly)
            {
                // If sound doesn't ignore play rate limit and is found in the current limits, return
                if (!scriptableSound.IgnorePlayRateLimit && _playRateLimits.Contains(scriptableSound))
                {
                    return;
                }

                _playRateLimits.Add(scriptableSound);
            }

            ScriptableSoundObject scriptableSoundObject = editorOnly ? _scriptableSoundPool.GetTemporary() : _scriptableSoundPool.Get();
            scriptableSoundObject.Load(scriptableSound);
            scriptableSoundObject.Play(!editorOnly);
        }

        private IEnumerator PlayRateLimitCoroutine()
        {
            yield return new WaitForSeconds(1 / Settings.MaxPlayRatePerSecond);
            _playRateLimits.Clear();
            StartCoroutine(PlayRateLimitCoroutine());
        }
    }
}
