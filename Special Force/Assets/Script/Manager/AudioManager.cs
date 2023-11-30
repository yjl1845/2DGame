using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Sound
{
    public AudioClip[] audioClip;
}

public class AudioManager : Singleturn<AudioManager>
{
    [SerializeField] AudioSource effectSource;
    [SerializeField] AudioSource scenerySource;

    public void Sound(AudioClip audioClip)
    {
        effectSource.PlayOneShot(audioClip);
    }

}
