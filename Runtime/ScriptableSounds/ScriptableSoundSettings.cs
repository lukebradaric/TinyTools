using UnityEngine;

// Commented out because we only want settings asset
//[CreateAssetMenu(menuName = "TinyTools/ScriptableSoundSettings")]
internal class ScriptableSoundSettings : ScriptableObject
{
    [Space]
    [Header("Repetition")]
    [Tooltip("Should there be a limit on how many times one Audio Asset can be played in a second? (Helps to reduce sound clutter)")]
    [SerializeField] private bool _enablePlayRateLimit = false;
    public bool EnablePlayRateLimit => _enablePlayRateLimit;

    [Tooltip("The maximum amount of times an Audio Asset can be played in one second. (Eg. 10 = 10 times per second)")]
    [SerializeField] private float _maxPlayRatePerSecond = 10;
    public float MaxPlayRatePerSecond => _maxPlayRatePerSecond;

    [Space]
    [Header("Playback")]
    [Tooltip("Time waited after playing audio before it is returned to the pool. (Prevents clipping)")]
    [SerializeField] private float _audioPlaytimeBuffer = 0.15f;
    public float AudioPlaytimeBuffer => _audioPlaytimeBuffer;
}
