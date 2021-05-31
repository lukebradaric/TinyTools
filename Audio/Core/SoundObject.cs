using System.Collections.Generic;
using UnityEngine;

namespace TinyTools.Audio
{
    [ExecuteAlways]
    public class SoundObject : MonoBehaviour
    {
        // Sound this sound object is playing from
        private SoundSO sound;

        // list of audio sources to play through (0 is initial)
        private List<AudioSource> audioSourcePool = new List<AudioSource>();

        // Set SoundSO of this
        public void SetSound(SoundSO sound) => this.sound = sound;

        // Get the SoundSO of this
        public SoundSO GetSound() => this.sound;

        // Remove this from AudioManager when destroyed
        private void OnDisable() => AudioManager.RemoveSoundObject(this);

        // Setup an audio source from a SoundSO
        public AudioSource SetupAudioSource(AudioSource audioSource)
        {
            audioSource.clip = sound.clip;
            audioSource.priority = sound.priority;
            audioSource.volume = sound.volume;
            audioSource.pitch = sound.pitch;
            audioSource.loop = sound.loop;
            audioSource.spatialBlend = sound.spatialBlend;

            audioSource.rolloffMode = sound.rollOffMode;
            //audioSource.rolloffFactor

            // add SoundSO option
            audioSource.playOnAwake = false;

            return audioSource;
        }

        // Randomize pitch of audio source
        public void RandomizePitch(AudioSource audioSource)
        {
            if (!sound.useRandomPitch)
                return;

            // Random pitch within range
            audioSource.pitch = Mathf.Clamp(sound.pitch + Random.Range(-sound.randomPitch, sound.randomPitch), -3f, 3f);
        }

        // returns first available audio source in audiosourcepool
        public AudioSource GetAudioSource()
        {
            foreach (AudioSource audioSource in audioSourcePool)
            {
                // If audio source not playing, return it as available
                if (!audioSource.isPlaying)
                    return SetupAudioSource(audioSource);
            }

            // If no available audio sources, create new
            AudioSource newAudioSource = gameObject.AddComponent<AudioSource>();
            newAudioSource = SetupAudioSource(newAudioSource);

            // Add new audio source
            audioSourcePool.Add(newAudioSource);

            // return new audio source
            return newAudioSource;
        }

        // Play sound from first available audio source
        public void Play()
        {
            // If sound is set to loop, stop sound first
            if (sound.loop)
                Stop();

            // Get audio source from pool
            AudioSource audioSource = GetAudioSource();

            // Randomize pitch of audio source
            RandomizePitch(audioSource);

            // Play audio source
            audioSource.Play();
        }

        // Stop all audio sources on this
        public void Stop()
        {
            // Stop all audio sources in audioSource pool
            foreach (AudioSource audioSource in audioSourcePool)
                audioSource.Stop();
        }
    }
}
