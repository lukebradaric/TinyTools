using UnityEngine;
using TinyTools.Audio;

public class DemoSoundPlayer : MonoBehaviour
{
    // sound we are going to play
    public Sound demoSound;

    // desc
    [TextArea]
    public string text;

    void Update()
    {
        // play sound when hitting g key
        if (Input.GetKeyDown("g"))
            demoSound.Play();
    }
}
