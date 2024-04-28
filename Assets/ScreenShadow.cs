using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenShadow : MonoBehaviour
{
    [SerializeField] private Image shadow;
    [SerializeField] private float shadowdur;
    [SerializeField] private IO_UIOpener io;

    private void Awake()
    {
        io.OnInteractE += StartShadow;
    }

    public void StartShadow()
    {
        StartCoroutine(Shadow());
    }

    public void EndShadow()
    {
        StopCoroutine(Shadow());
        shadow.color = new Color(0, 0, 0, 0);
    }
    
    public IEnumerator Shadow()
    {
        for (float i = 0; i < 1; i += 0.01f)
        {
            shadow.color = Color.Lerp(new Color(0,0,0,0), Color.black, i);
            yield return new WaitForSeconds(shadowdur / 100);
        }
        shadow.color = Color.black;
    }
}
