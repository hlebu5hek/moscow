using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IO_Key : InteractableObject
{
    [SerializeField] private string _name;
    [SerializeField] private bool _destr;

    protected override void Awake()
    {
        OnInteractE += AddKey;
    }

    private void AddKey()
    {
        PlayerInventoryKeys.PIK.AddKey(_name, 1);
        OnInteractE -= AddKey;
        if (_destr) gameObject.SetActive(false);
        else GetComponent<Collider>().enabled = false;
    }
}
