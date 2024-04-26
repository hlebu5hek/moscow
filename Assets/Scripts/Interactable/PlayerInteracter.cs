using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteracter : MonoBehaviour
{
    [SerializeField] private InteractableObject _ioE, _ioM;

    public static PlayerInteracter PI;
    public Action<bool> Interact;
    
    private void Awake()
    {
        GameManager.FxUpd += FxUpd;
        Interact += Interaction;
    }

    private void Start()
    {
        PI = this;
    }

    private void FxUpd()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact?.Invoke(false);
        }
    }

    private void Interaction(bool m)
    {
        if (m && _ioM) _ioM.OnInteractMouse?.Invoke();
        else if (_ioE) _ioE.OnInteractE?.Invoke();   
    }

    public void SetInteractableObject(InteractableObject io, bool isM)
    {
        if (isM) _ioM = io;
        else
        {
            if (_ioE)
            {
                if ((_ioE.transform.position - transform.position).magnitude >
                    (io.transform.position - transform.position).magnitude)
                    _ioE = io;
            }
            else _ioE = io;
        }
    }

    public void ResetInteractableObject(InteractableObject io)
    {
        if (io == null)
        {
            if(_ioM)
                _ioM.OnMouseExit?.Invoke();
            _ioM = null;
            return;
        }
        
        if (_ioE == io) _ioE = null;
    }
}
