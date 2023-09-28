using UnityEngine;
using UnityEngine.Pool;

namespace TinyTools.ScriptableSounds
{
    internal class ScriptableSoundPool
    {
        private ObjectPool<ScriptableSoundObject> _scriptableSoundObjectPool = new ObjectPool<ScriptableSoundObject>(Create, OnGet, OnRelease);

        public ScriptableSoundObject Get() => _scriptableSoundObjectPool.Get();

        public ScriptableSoundObject GetTemporary()
        {
            ScriptableSoundObject scriptableSoundObject = Create();
            scriptableSoundObject.gameObject.name = $"Editor{scriptableSoundObject.gameObject.name}";
            scriptableSoundObject.gameObject.hideFlags = HideFlags.HideAndDontSave;
            return scriptableSoundObject;
        }

        public void Release(ScriptableSoundObject scriptableSoundObject) => _scriptableSoundObjectPool.Release(scriptableSoundObject);

        private static ScriptableSoundObject Create()
        {
            GameObject gameObject = new GameObject(nameof(ScriptableSoundObject));

            if (ScriptableSoundManager.Instance != null)
            {
                gameObject.transform.SetParent(ScriptableSoundManager.Instance.transform);
            }

            ScriptableSoundObject scriptableSoundObject = gameObject.AddComponent<ScriptableSoundObject>();
            return scriptableSoundObject;
        }

        private static void OnGet(ScriptableSoundObject scriptableSoundObject)
        {
            scriptableSoundObject.gameObject.SetActive(true);
        }

        private static void OnRelease(ScriptableSoundObject scriptableSoundObject)
        {
            scriptableSoundObject.gameObject.SetActive(false);
        }
    }
}
