using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IO_Lever : InteractableObject
{
    [SerializeField] private IO_Door[] _doors;

    protected override void Awake()
    {
        OnInteractE.AddListener(ChangeState);
        OnInteractMouse.AddListener(ChangeState);
    }

    protected void ChangeState()
    {
        foreach (var d in _doors)
        {
            d.OnInteractE?.Invoke();
        }
    }
}
