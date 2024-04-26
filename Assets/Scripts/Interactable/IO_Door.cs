using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IO_Door : Door
{
    [SerializeField] private bool _iskey;
    [SerializeField] private string _keyname;

    protected override void Awake()
    {
        base.Awake();
        OnInteractE += ChangeState;
    }

    protected void ChangeState()
    {
        if ((!_iskey) ||
            (PlayerInventoryKeys.PIK.HasKey(_keyname, 0)))
        {
            _isopen = !_isopen;
            CheckState();
            return;
        }
    }
}
