using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W_FB_Dmg : MonoBehaviour
{
    [SerializeField] private float dmg;
    [SerializeField] private List<HaveHealth> dmgable;

    private void Awake()
    {
        GameManager.Upd += ApplyDmg;
    }

    private void OnTriggerEnter(Collider other)
    {
        dmgable.Add(other.GetComponent<HaveHealth>());
    }

    private void OnTriggerExit(Collider other)
    {
        dmgable.Remove(other.GetComponent<HaveHealth>());
    }

    public void Clear()
    {
        dmgable.Clear();
    }
    
    private void ApplyDmg()
    {
        foreach (var d in dmgable)
        {
            d.GetDmg(dmg);
        }
    }
}
