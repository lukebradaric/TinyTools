using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

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
            // If using list of clips, get random
            AudioClip clip = sound.clip;
            if(sound.useList)
                clip = sound.clips[Random.Range(0, sound.clips.Length)];

            audioSource.clip = clip;
            audioSource.priority = sound.priority;
            audioSource.volume = sound.volume;
            audioSource.pitch = sound.pitch;
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
            if (sound.pitchVariation <= 0)
                return;

            // Random pitch within range
            audioSource.pitch = Mathf.Clamp(sound.pitch + Random.Range(-sound.pitchVariation, sound.pitchVariation), -3f, 3f);
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
            // If sound is set to loop, start loop play
            if (sound.loop)
            {
                // enable looping and play
                if (!sound.looping)
                {
                    sound.looping = true;
                    PlayLoop();
                }

                return;
            }

            // Get audio source from pool
            AudioSource audioSource = GetAudioSource();

            // Randomize pitch of audio source
            RandomizePitch(audioSource);

            //if (sound.loop)
            //    AsyncLoop(sound.clip.length / audioSource.pitch);

            // Play audio source
            audioSource.Play();
        }

        // Stop all audio sources on this
        public void Stop()
        {
            // disable looping
            sound.looping = false;

            // Stop all audio sources in audioSource pool
            foreach (AudioSource audioSource in audioSourcePool)
                audioSource.Stop();
        }

        public void PlayLoop()
        {
            // if loop disabled, stop looping
            if (!sound.loop)
                sound.looping = false;

            // if not looping return
            if (!sound.looping)
                return;

            AudioSource audioSource = GetAudioSource();

            // Randomize pitch of audio source
            RandomizePitch(audioSource);

            // async loop play
            AsyncLoop(sound.clip.length / audioSource.pitch);

            // Play audio source
            audioSource.Play();
        }

        // Wait time then PlayLoop
        async void AsyncLoop(float time)
        {
            int t = (int)(time * 1000);

            // if time between loop, add to delay
            if(sound.timeBetweenLoop > 0)
                t += (int)(sound.timeBetweenLoop * 1000);

            await Task.Delay(t);
            PlayLoop();
        }
    }
}
