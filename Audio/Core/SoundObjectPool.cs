using System.Collections.Generic;
using UnityEngine;

namespace TinyTools.Audio
{
    public static class SoundObjectPool
    {
        private static Stack<SoundObject> available = new Stack<SoundObject>();
        private static bool isPrewarmed;
        public static Transform soundObjectParent;

        private static SoundObject Create()
        {
            SoundObject soundObject = new GameObject("SoundObject").AddComponent<SoundObject>();

            if (soundObjectParent != null)
                soundObject.transform.parent = soundObjectParent;

            GameObject.DontDestroyOnLoad(soundObject.gameObject);

            return soundObject;
        }

        public static void Prewarm(int count)
        {
            if (isPrewarmed)
                return;

            soundObjectParent = new GameObject("TinyTools").transform;
            GameObject.DontDestroyOnLoad(soundObjectParent.gameObject);

            for (int i = 0; i < count; i++)
            {
                available.Push(Create());
            }
            isPrewarmed = true;
        }

        public static SoundObject Request()
        {
            return available.Count > 0 ? available.Pop() : Create();
        }

        public static void Return(SoundObject member)
        {
            available.Push(member);
        }

        public static void Clear() => available.Clear();
    }
}
