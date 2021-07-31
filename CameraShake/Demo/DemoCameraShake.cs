using UnityEngine;
using TinyTools.CameraShake;

public class DemoCameraShake : MonoBehaviour
{
    // Shake ScriptableObject with our shake settings
    public Shake demoShake;

    [TextArea]
    // description
    public string note;

    // Demo input
    private void Update()
    {
        if (Input.GetKeyDown("g"))
        {
            demoShake.Play();

            // Other ways to play CameraShake without using ScriptableObjects
            if (note == "Other ways to play CameraShakes!")
            {
                CameraShake.Singleton.Play(duration: 0.25f, magnitude: 1f);
                CameraShake.Singleton.Play(duration: 0.25F, magnitude: 1f, frequency: 0.05f);
                CameraShake.Singleton.Play(duration: 0.25F, magnitude: 1f, frequency: 0.05f, smoothSpeed: 0.1f);
            }
        }
    }
}
