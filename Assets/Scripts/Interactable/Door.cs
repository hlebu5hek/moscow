using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : InteractableObject
{
    [SerializeField] protected Animator _anim;
    [SerializeField] protected bool isopen_anim;

    public bool _isopen;
    public int Rooms;
    protected override void Awake()
    {
        room.OnEnter += CheckState;
    }

    public virtual void Open()
    {
        if(_isopen && !isopen_anim)
            _anim.SetTrigger("open");
    }
    
    public virtual void Close()
    {
        if(isopen_anim)
        {
            _anim.SetTrigger("close");
            isopen_anim = false;
        }
    }

    protected virtual void CheckState()
    {
        if (_isopen) Open();
        else Close();
    }

    public virtual void SetAnimState()
    {
        isopen_anim = _isopen;
    }

    public void CheckRoomExit()
    {
        if (Rooms <= 0)
        {
            Rooms = 0;
            gameObject.SetActive(false);
        }
    }
}
