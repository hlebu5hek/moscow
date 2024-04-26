using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W_Firebreaker : WeaponeRange
{
    [SerializeField] private ParticleSystem _ps;
    [SerializeField] private Collider dmg_coll;
    [SerializeField] private W_FB_Dmg fb;
    [SerializeField] private float ammo;
    
    protected override void Awake()
    {
        base.Awake();
        OnAttack += StartShooting;
        OnStopAttack += StopShooting;
        GameManager.Upd += Upd;
        
        OnStopAttack?.Invoke();
    }

    private void Upd()
    {
        if (_ps.isPlaying & ammo > 0) ammo -= Time.deltaTime;
        if(ammo <= 0) OnStopAttack?.Invoke();
    }

    private void StartShooting()
    {
        if(ammo <= 0) return;
        
        _ps.Play();
        dmg_coll.enabled = true;
        fb.enabled = true;
    }

    private void StopShooting()
    {
        _ps.Stop();
        dmg_coll.enabled = false;
        fb.Clear();
        fb.enabled = false;
    }
}
