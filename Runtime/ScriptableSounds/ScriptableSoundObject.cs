using System.Collections;
using UnityEngine;

namespace TinyTools.ScriptableSounds
{
    internal class ScriptableSoundObject : MonoBehaviour
    {
        /// <summary>
        /// Small buffer added to audio playtime before returning to pool.
        /// Prevents audio from cutting off before it has finished playing.
        /// </summary>
        public const float AudioPlaytimeBuffer = 0.1f;

        private AudioSource _audioSource;

        public void Load(ScriptableSound scriptableSound)
        {
            if (_audioSource == null)
            {
                _audioSource = gameObject.AddComponent<AudioSource>();
            }

            if (_audioSource.outputAudioMixerGroup != null)
            {
                _audioSource.outputAudioMixerGroup = scriptableSound.AudioMixerGroup;
            }

            _audioSource.clip = scriptableSound.AudioClip;
            _audioSource.priority = (int)scriptableSound.AudioPriority;
            _audioSource.volume = scriptableSound.Volume;
            _audioSource.pitch = scriptableSound.Pitch;
        }

        public void Play(bool autoRelease = true)
        {
            _audioSource.Play();

            if (autoRelease)
            {
                StartCoroutine(ReleaseCoroutine());
            }
        }

        private IEnumerator ReleaseCoroutine()
        {
            yield return new WaitForSeconds((_audioSource.clip.length / _audioSource.pitch) + AudioPlaytimeBuffer);

            ScriptableSoundManager.Release(this);
        }
    }
}
