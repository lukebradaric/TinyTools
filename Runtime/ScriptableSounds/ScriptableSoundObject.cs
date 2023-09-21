using System.Collections;
using UnityEngine;

namespace TinyTools.ScriptableSounds
{
    internal class ScriptableSoundObject : MonoBehaviour
    {
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
            yield return new WaitForSeconds((_audioSource.clip.length / _audioSource.pitch) + ScriptableSoundManager.Settings.AudioPlaytimeBuffer);

            ScriptableSoundManager.Release(this);
        }
    }
}
