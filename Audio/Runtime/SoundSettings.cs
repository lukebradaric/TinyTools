using UnityEngine;

namespace TinyTools.Audio
{
    // Commented out because we only want one SoundSettings SO :)
    // [CreateAssetMenu(menuName = "TinyTools/Audio/SoundSettings")]
    public class SoundSettings : ScriptableObject
    {
        [Tooltip("Starting size of SoundPool. How many Sound GameObjects are created whenever a scene loads.")]
        [SerializeField] private int soundPoolSize = 20;
        public int SoundPoolSize => this.soundPoolSize;
    }
}
