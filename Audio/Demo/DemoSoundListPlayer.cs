using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTools.Audio;

public class DemoSoundListPlayer : MonoBehaviour
{
    // sound we are going to play
    public SoundList demoSoundList;

    // desc
    [TextArea]
    public string text;

    void Update()
    {
        // play sound when hitting g key
        if (Input.GetKeyDown("h"))
            demoSoundList.PlayRandom();
    }
}
