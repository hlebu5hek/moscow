using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IO_DoorSensor : IO_Door
{
    protected override void Awake()
    {
        base.Awake();
        OnPlayerEnter += Open;
        OnPlayerExit += Close;
    }
    
    public override void Open()
    {
        if (_isopen && !isopen_anim)
        {
            _anim.SetTrigger("open");
        }
    }
    
    public override void Close()
    {
        if(isopen_anim)
        {
            _anim.SetTrigger("close");
        }
    }

    protected override void CheckState()
    {
        
    }

    protected override void OnTriggerEnter(Collider other)
    {
        _isopen = true;
        OnPlayerEnter?.Invoke();
    }

    protected override void OnTriggerExit(Collider other)
    {
        _isopen = false;
        OnPlayerExit?.Invoke();
    }
}
