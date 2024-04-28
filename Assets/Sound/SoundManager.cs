using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    public List<AudioClip> backgrounds;
    public float volumeBackground = 0.1f;
    public float volumeFX = 0.4f;
    private AudioSource bAudioSource;

    private void Awake()
    {
        if (Instance != null){ Destroy(gameObject);}

        Instance = this;
        DontDestroyOnLoad(this);
        bAudioSource = GetComponent<AudioSource>();
        bAudioSource.loop = true;
        SetBackground(0);
    }
    
    public void PlaySoundFX(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, volumeFX);
    }
    public void PlaySoundFX(AudioClip clip, Vector3 position)
    {
        AudioSource.PlayClipAtPoint(clip, position, volumeFX);
    }

    public void SetBackground()
    {
        StartCoroutine(FadeInOutBackground(backgrounds[Random.Range(0, backgrounds.Count)]));
    }
    
    public void SetBackground(int idx)
    {
        SetBackground(backgrounds[idx]);
    }
    public void SetBackground(AudioClip audioClip)
    {
        bAudioSource.clip = audioClip;
        bAudioSource.Play();
    }
    
    public void SetFadeBackground(int idx)
    {
        StartCoroutine(FadeInOutBackground(backgrounds[idx]));
    }
    
    public void SetFadeBackground(AudioClip audioClip)
    {
        StopCoroutine(FadeInOutBackground(audioClip));
    }

    IEnumerator FadeInOutBackground(AudioClip audioClip)
    {
        float startVolume = bAudioSource.volume;
        bAudioSource.volume = Mathf.Lerp(startVolume, 0, Time.deltaTime * 5);
        yield return new WaitForSeconds(0.1f);
        SetBackground(audioClip);
        bAudioSource.volume = startVolume;
    }
    
    
}
