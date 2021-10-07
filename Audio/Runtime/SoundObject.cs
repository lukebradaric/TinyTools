using UnityEngine;
using System.Collections;
using System;

namespace TinyTools.Audio
{
    [ExecuteAlways]
    [RequireComponent(typeof(AudioSource))]
    public class SoundObject : MonoBehaviour
    {
        private AudioSource audioSource;
        private void Awake() => audioSource = GetComponent<AudioSource>();

        public void Load(Sound sound)
        {
            audioSource.playOnAwake = false;

            audioSource.clip = sound.clip;
            audioSource.outputAudioMixerGroup = sound.output;

            audioSource.priority = sound.priority;
            audioSource.volume = sound.volume;
            audioSource.pitch = sound.pitch;

            if (Mathf.Abs(sound.randomPitch) > 0)
                audioSource.pitch += UnityEngine.Random.Range(-sound.randomPitch, sound.randomPitch);
        }

        public void Play()
        {
            audioSource.Play();
            StartCoroutine(PlayTimer());
        }

        private IEnumerator PlayTimer()
        {
            // wait for length of clip + 0.25f buffer, then return to pool
            yield return new WaitForSeconds((float)Math.Round((audioSource.clip.length / audioSource.pitch) + 0.25f, 2));
            SoundObjectPool.Return(this);
        }
    }
}