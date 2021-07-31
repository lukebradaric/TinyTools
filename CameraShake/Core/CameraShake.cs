using System.Collections;
using UnityEngine;

namespace TinyTools.CameraShake
{
    public class CameraShake : MonoBehaviour
    {
        #region Singleton
        public static CameraShake Singleton;
        private void Awake()
        {
            if (Singleton != null)
                Debug.Log("More than one CameraShake instance! Be careful when referencing CameraShake.Singleton.");
            else
                Singleton = this;
        }
        #endregion

        [Space]
        [Header("Settings")]
        [Tooltip("Sets the frequency of camera shakes.")]
        [SerializeField] private float shakeFrequency = 0.05f;
        [Tooltip("Sets the smoothing speed of the camera shakes.")]
        [SerializeField] private float smoothSpeed = 0.1f;
        [Tooltip("Should the camera reset to it's starting position after shaking has finished.")]
        [SerializeField] private bool resetPosition;

        // position camera is shaking to
        private Vector3 shakePosition;
        // position camera started at
        private Vector3 startPosition;
        // coroutine of current camera shake
        private Coroutine shakeCoroutine;
        // current smooth speed to use
        private float curSmoothSpeed = 0.1f;

        private void FixedUpdate()
        {
            // if camera not active, return
            if (shakeCoroutine == null)
                return;

            transform.localPosition = Vector3.Lerp(transform.localPosition, shakePosition, curSmoothSpeed);
        }

        public void Play(Shake shake) => Play(shake.duration, shake.magnitude, shake.frequency, shake.smoothSpeed);
        public void Play(float duration, float magnitude) => Play(duration, magnitude, this.shakeFrequency);
        public void Play(float duration, float magnitude, float frequency) => Play(duration, magnitude, frequency, this.smoothSpeed);
        public void Play(float duration, float magnitude, float frequency, float smoothSpeed)
        {
            if (shakeCoroutine != null)
            {
                StopCoroutine(shakeCoroutine);

                // reset pos when stopping coroutine
                if (resetPosition)
                    transform.localPosition = startPosition;
            }

            curSmoothSpeed = smoothSpeed;

            shakeCoroutine = StartCoroutine(ShakeTimer(duration, magnitude, frequency));
        }

        private IEnumerator ShakeTimer(float duration, float magnitude, float frequency)
        {
            startPosition = transform.localPosition;

            float elapsed = 0f;
            while (elapsed < duration)
            {
                float xShake = Random.Range(-magnitude, magnitude);
                float yShake = Random.Range(-magnitude, magnitude);
                xShake += transform.localPosition.x;
                yShake += transform.localPosition.y;

                shakePosition = new Vector3(xShake, yShake, startPosition.z);

                elapsed += shakeFrequency;

                yield return new WaitForSeconds(shakeFrequency);
            }

            if (resetPosition)
                transform.localPosition = startPosition;

            curSmoothSpeed = this.smoothSpeed;

            shakeCoroutine = null;
        }
    }
}
