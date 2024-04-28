using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ambient : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private List<AudioClip> ambient;
    [SerializeField] private int current;
    [SerializeField] private List<float> ambientLength;
    [SerializeField] private AudioClip ambientElec;

    public static Ambient ins;

    private void Awake()
    {
        ins = this;
    }

    private void Start()
    {
        PlayAmb(false);
    }

    public void PlayAmb(bool elec)
    {
        source.Stop();
        if (elec)
        {
            StopAllCoroutines();
            source.loop = true;
            source.clip = ambientElec;
            source.Play();
        }
        else
        {
            current++;
            if (current >= ambient.Count) current = 0;
            source.loop = false;
            source.clip = ambient[current];
            source.Play();
            StartCoroutine(timer(ambientLength[current]));
        }
    }

    public IEnumerator timer(float t)
    {
        yield return new WaitForSeconds(t);
        PlayAmb(false);
    }
}
