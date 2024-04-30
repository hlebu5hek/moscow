using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteracter : MonoBehaviour
{
    [SerializeField] private InteractableObject _ioE;
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip click, inter;

    public static PlayerInteracter PI;
    public bool freezed;
    public Action<bool> Interact;
    
    private void Awake()
    {
        PI = this;
        GameManager.FxUpd += FxUpd;
        Interact += Interaction;
    }

    private void FxUpd()
    {
        if (Input.GetMouseButtonDown(0))
        {
            source.clip = click;
            source.Play();
        }
        
        if (freezed) return;
        
        if (Input.GetKeyDown(GameManager.gm.input["interact"]))
        {
            Interact?.Invoke(false);
        }
    }

    private void Interaction(bool m)
    {
        if (freezed) return;

        if (_ioE)
        {
            _ioE.OnInteractE?.Invoke();

            source.clip = inter;
            source.Play();
        }
    }

    public void SetInteractableObject(InteractableObject io)
    {
        if (freezed) return;

        if (_ioE)
        {
            if ((_ioE.transform.position - transform.position).magnitude >
                (io.transform.position - transform.position).magnitude)
                _ioE = io;
        }
        else _ioE = io;
    }

    public void ResetInteractableObject(InteractableObject io)
    {
        if (freezed) return;

        if (_ioE == io) _ioE = null;
    }
}
