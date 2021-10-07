using UnityEngine;

namespace TinyTools.CameraShake
{
    [CreateAssetMenu(menuName = "TinyTools/CameraShake/Shake")]
    public class Shake : ScriptableObject
    {
        [Tooltip("Duration of the camera shake.")]
        public float duration = 0.25f;

        [Tooltip("Magnitude of the camera shake.")]
        public float magnitude = 1;

        [Tooltip("Smooth speed of the camera movement.")]
        public float smoothSpeed = 0.1f;

        [Tooltip("Frequency of the camera shakes.")]
        public float frequency = 0.05f;

        public void Play() => CameraShake.Singleton.Play(this);
    }
}