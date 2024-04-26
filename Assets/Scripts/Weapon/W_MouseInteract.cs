using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W_MouseInteract : WeaponeRange
{
    protected override void Shoot()
    {
        base.Shoot();
        PlayerInteracter.PI.Interact?.Invoke(true);
    }

}
