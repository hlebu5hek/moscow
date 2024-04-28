using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioClip AudioClip;

    public void PlayClip()
    {
        SoundManager.Instance.PlaySoundFX(AudioClip);
    }
}
