using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IO_Key : InteractableObject
{
    [SerializeField] private string _name;

    protected override void Awake()
    {
        OnInteractE.AddListener(AddKey);
    }

    private void AddKey()
    {
        PlayerInventoryKeys.PIK.AddKey(_name, 1);
        gameObject.SetActive(false);
    }
}
