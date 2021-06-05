using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using TinyTools.Audio;

public class DemoSoundPlayer : MonoBehaviour
{
    // public SoundSO variable to be played
    public SoundSO demoSound;

    public Vector3 playPosition;

    public void PlaySound()
    {
        if (playPosition != Vector3.zero)
        {
            demoSound.Play(playPosition);
            return;
        }

        // How to play SoundSO via code
        demoSound.Play();
    }
}

// Custom editor to add button to play sound in Inspector
#if UNITY_EDITOR
[CustomEditor(typeof(DemoSoundPlayer))]
public class DemoPlaySoundEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        DemoSoundPlayer demoPlaySound = (DemoSoundPlayer)target;

        if (GUILayout.Button("Demo Sound"))
        {
            demoPlaySound.PlaySound();
        }
    }
}
#endif
