using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEvent:MonoBehaviour
{

    public AudioSource Target;

    public void PlayOneShot(AudioClip clip)
    {
        if (Target != null)
        {
            Target.PlayOneShot(clip);
        }
    }
}
