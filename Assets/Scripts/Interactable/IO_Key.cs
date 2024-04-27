using System;
using System.Collections;
using System.Collections.Generic;
using Tasks.Scripts.Core;
using Unity.VisualScripting;
using UnityEngine;

public class IO_Key : InteractableObject
{
    [SerializeField] private string _name;
    [SerializeField] private bool _destr;
    [SerializeField] private int taskInd;

    protected override void Awake()
    {
        base.Awake();
        OnInteractE += AddKey;
    }

    private void AddKey()
    {
        PlayerInventoryKeys.PIK.AddKey(_name, 1);
        OnInteractE -= AddKey;
        if (_destr) gameObject.SetActive(false);
        else GetComponent<Collider>().enabled = false;
        
        HideOutline();
        if(taskInd!=-1) TaskManager.Instant.SetSubtaskProgress(taskInd, 0, 1);
    }
}
