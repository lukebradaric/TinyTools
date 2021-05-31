using UnityEngine;
using UnityEngine.Audio;

namespace TinyTools.Audio
{
    [CreateAssetMenu(menuName = "TinyTools/Audio/SoundSO")]
    public class SoundSO : ScriptableObject
    {
        // audio clip
        public AudioClip clip;
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

        // should sound use random pitch
        public bool useRandomPitch = false;
        // random pitch rangfe
        [Range(0,1)]
        public float randomPitch = 0.1f;

        // TODO:
        // play on awake

        // should clip loop
        public bool loop = false;
        
        // priority

        //public bool is3d = false;
        // stereo pan

        // spatial blend
        [Range(0,1)]
        public float spatialBlend = 0;
        
        // reverb zone mix

        // 3d sound settings
        public float dopplerLevel = 1;
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
