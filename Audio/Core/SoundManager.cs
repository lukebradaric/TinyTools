using UnityEditor;
using UnityEngine;

namespace TinyTools.Audio
{
    [InitializeOnLoadAttribute]
    public static class SoundManager
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Init()
        {
            // prewarm soundobjectpool with 20 sound objects
            SoundObjectPool.Prewarm(20);
        }

        static SoundManager()
        {
            EditorApplication.playModeStateChanged += HandlePlayModeChanged;
        }

        private static void HandlePlayModeChanged(PlayModeStateChange state)
        {
            switch (state)
            {
                case PlayModeStateChange.ExitingEditMode:

                    foreach (SoundObject soundObject in GameObject.FindObjectsOfType<SoundObject>())
                        GameObject.DestroyImmediate(soundObject.gameObject);

                    SoundObjectPool.Clear();

                    break;
                case PlayModeStateChange.ExitingPlayMode:

                    SoundObjectPool.Clear();

                    break;
            }
        }

        public static void Play(Sound sound)
        {
            SoundObject soundObject = SoundObjectPool.Request();
            soundObject.Load(sound);
            soundObject.Play();
        }
    }
}
