using UnityEngine;
using UnityEngine.Audio;

namespace TinyTools.ScriptableSounds
{
    [CreateAssetMenu(menuName = "TinyTools/ScriptableSound")]
    public class ScriptableSound : ScriptableObject
    {
        [Space]
        [Header("Components")]
        [Tooltip("The AudioClip to play.")]
        [SerializeField] private AudioClip _audioClip;
        public AudioClip AudioClip => _audioClip;

        [Tooltip("The Mixer Group to play the audio through. (Not required)")]
        [SerializeField] private AudioMixerGroup _audioMixerGroup;
        public AudioMixerGroup AudioMixerGroup => _audioMixerGroup;

        [Space]
        [Header("Settings")]
        [Tooltip("The priority of the audio.")]
        [SerializeField] private AudioPriority _audioPriority;
        public AudioPriority AudioPriority => _audioPriority;

        [Range(0f, 1f)]
        [SerializeField] private float _volume = 0.5f;
        public float Volume => _volume;

        [Range(-3f, 3f)]
        [SerializeField] private float _pitch = 1;
        public float Pitch
        {
            get
            {
                if (PitchVariation == 0) return _pitch;

                return Mathf.Clamp(_pitch + UnityEngine.Random.Range(-PitchVariation, PitchVariation), -3f, 3f);
            }
        }

        [Range(0f, 1f)]
        [Tooltip("The random variation in pitch each time the audio is played.")]
        [SerializeField] private float _pitchVariation = 0.0f;
        public float PitchVariation => _pitchVariation;

        [Tooltip("Should this Audio Asset ignore the max play rate? (How many times one sound can be played per second)")]
        [SerializeField] private bool _ignorePlayRateLimit = false;
        public bool IgnorePlayRateLimit => _ignorePlayRateLimit;

        /// <summary>
        /// Plays the Scriptable Sound.
        /// </summary>
        public void Play()
        {
            ScriptableSoundManager.Play(this);
        }

#if UNITY_EDITOR
        public void PlayEditor()
        {
            ScriptableSoundManager.Play(this, true);
        }
#endif
    }
}
