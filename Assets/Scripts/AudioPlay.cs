using UnityEngine;

// The Audio Source component has an AudioClip option.  The audio
// played in this example comes from AudioClip and is called audioData.

[RequireComponent(typeof(AudioSource))]
public class AudioPlay : MonoBehaviour
{
    public AudioSource jump;

    void Start() {}
    void Update() {}
    void playJump()
    {
        jump.Play();
    }
}