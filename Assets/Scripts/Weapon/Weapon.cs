using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : InteractableObject
{
    public Collider Trigger;
    public Rigidbody Body;
    public Action OnAttack, OnStopAttack;
    public Action OnReload, OnAmmoOut;

    protected override void Awake()
    {
        OnInteractE.AddListener(PickUp);
    }

    private void PickUp()
    {
        PlayerInventoryWeapon.PIW.OnWeaponPickup?.Invoke(this);
        PlayerInteracter.PI.ResetInteractableObject(this);
    }
}
