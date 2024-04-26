using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponeRange : Weapon
{
    [SerializeField] protected GameObject _bullet;
    [SerializeField] protected float _distance;
    [SerializeField] protected int b_round, b_roundammo, b_ammo;
    [SerializeField] protected float r_time;
    [SerializeField] protected bool is_reload;

    protected override void Awake()
    {
        base.Awake();
        OnAttack += Shoot;
    }

    protected virtual void Shoot()
    {
        
    }
}
