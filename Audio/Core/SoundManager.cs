using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            // Clear soundObjects when changing playmode
            EditorApplication.playModeStateChanged += HandlePlayModeChanged;

            // Clear soundObjects when changing scenes
            EditorSceneManager.sceneClosing += HandleSceneClosing;
        }

        private static void HandlePlayModeChanged(PlayModeStateChange state)
        {
            switch (state)
            {
                case PlayModeStateChange.ExitingEditMode:
                    ClearAll();
                    break;
                case PlayModeStateChange.ExitingPlayMode:
                    SoundObjectPool.Clear();
                    break;
            }
        }

        private static void HandleSceneClosing(Scene scene, bool removingScene) => ClearAll();

        private static void ClearAll()
        {
            foreach (SoundObject soundObject in GameObject.FindObjectsOfType<SoundObject>())
                GameObject.DestroyImmediate(soundObject.gameObject);

            SoundObjectPool.Clear();
        }

        public static void Play(Sound sound)
        {
            SoundObject soundObject = SoundObjectPool.Request();
            soundObject.Load(sound);
            soundObject.Play();
        }
    }
}
