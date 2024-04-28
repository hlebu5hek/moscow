using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySteps : MonoBehaviour
{
    public AudioClip[] steps;
    private bool first;

    public void PlayStep()
    {
       SoundManager.Instance.PlaySoundFX(first ? steps[0] : steps[1], transform.position);
        first = !first;
    }
}
