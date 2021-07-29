using UnityEngine;
using UnityEngine.Audio;

namespace TinyTools.Audio
{
    [CreateAssetMenu(menuName = "TinyTools/Audio/Sound")]
    public class Sound : ScriptableObject
    {
        [Tooltip("The AudioClip asset played by the audio source.")]
        public AudioClip clip;
        [Tooltip("Sets whether the sound should play through an Audio Mixer first or directly to the Audio Listener.")]
        public AudioMixerGroup output;

        [Tooltip("High > Low / Sets the priority of the audio source.")]
        [Range(0, 256)]
        public int priority = 128;

        [Tooltip("Sets the volume of the sound.")]
        [Range(0, 1)]
        public float volume = 1;

        [Tooltip("Sets the frequency of the sound.")]
        [Range(-3, 3)]
        public float pitch = 1;

        [Tooltip("Sets the random pitch range when playing the sound.")]
        [Range(-1, 1)]
        public float randomPitch = 0;

        public void Play() => SoundManager.Play(this);
    }
}
