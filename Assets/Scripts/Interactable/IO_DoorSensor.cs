using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IO_DoorSensor : IO_Door
{
    [SerializeField] private IO_DoorSensor secondSide;
    
    protected override void Awake()
    {
        OnPlayerEnter += Open;
        OnPlayerExit += Close;
    }
    
    public override void Open()
    {
        if (_isopen && !isopen_anim)
        {
            _anim.SetTrigger("open");
            secondSide.gameObject.SetActive(true);
            secondSide.Open();
        }
    }
    
    public override void Close()
    {
        if(isopen_anim)
        {
            _anim.SetTrigger("close");
            isopen_anim = false;
            secondSide.gameObject.SetActive(false);
        }
    }
}
