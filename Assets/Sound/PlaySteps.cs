using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySteps : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] steps;
    private bool first;

    public void PlayStep()
    {
        source.clip = steps[first ? 0 : 1];
        source.Play();
        first = !first;
    }
}
