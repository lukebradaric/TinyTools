using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace TinyTools.Audio
{
    // List of Sounds in one container. Can player random or targeted
    [CreateAssetMenu(menuName = "TinyTools/Audio/SoundList")]
    public class SoundList : ScriptableObject
    {
        [SerializeField] private List<Sound> sounds;

        private bool IsListEmpty()
        {
            if (sounds.Count == 0)
                throw new System.Exception("Sound list contains no elements");

            return false;
        }

        /// <summary>
        /// Plays a random sound from the list
        /// </summary>
        public void PlayRandom()
        {
            if (IsListEmpty())
                return;

            sounds[Random.Range(0, sounds.Count)].Play();
        }

        /// <summary>
        /// Returns a random sound from the list
        /// </summary>
        /// <returns></returns>
        public Sound GetRandom()
        {
            if (IsListEmpty())
                return null;

            return sounds[Random.Range(0, sounds.Count)];
        }

        /// <summary>
        /// Plays sound from list based on name
        /// </summary>
        /// <param name="soundName"></param>
        public void Play(string soundName)
        {
            if (IsListEmpty())
                return;

            Sound sound = sounds.FirstOrDefault(sound => sound.name == soundName);

            if (sound == null)
                throw new System.Exception("Sound list did not find any matching elements");

            sound.Play();
        }
    }
}
