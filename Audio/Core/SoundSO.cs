using UnityEngine;
using UnityEngine.Audio;

namespace TinyTools.Audio
{
    [CreateAssetMenu(menuName = "TinyTools/Audio/SoundSO")]
    public class SoundSO : ScriptableObject
    {
        // audio clip
        public AudioClip clip;
        public AudioClip[] clips;

        public bool useList;

        // mixer group
        public AudioMixerGroup audioMixerGroup = default;

        // priority
        [Range(0,256)]
        public int priority = 128;

        // volume
        [Range(0, 1)]
        public float volume = 1;

        // pitch
        [Range(-3, 3)]
        public float pitch = 1;

        // variation value of random pitch
        [Range(0,1)]
        public float pitchVariation;

        // TODO:
        // play on awake

        // should clip loop
        public bool loop = false;
        public bool looping = false;

        public float timeBetweenLoop;
        
        // priority

        //public bool is3d = false;
        // stereo pan

        // spatial blend
        [Range(0,1)]
        public float spatialBlend = 0;
        
        // reverb zone mix

        // 3d sound settings
        [Range(0,5)]
        public float dopplerLevel = 1;
        [Range(0,360)]
        public float spread = 0;
        public AudioRolloffMode rollOffMode = AudioRolloffMode.Linear;
        public float minDistance = 1;
        public float maxDistance = 500;

        // Play sound through audio manager
        public void Play() => AudioManager.PlaySoundSO(this);
        public void Play(Vector3 position) => AudioManager.PlaySoundSO(this, position);

        // stop sound through audio manager
        public void Stop() => AudioManager.StopSoundSO(this);
    }
}
