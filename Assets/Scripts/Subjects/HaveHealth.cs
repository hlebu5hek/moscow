using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaveHealth : MonoBehaviour
{
    [SerializeField] private float _hp, _iframes;
    [SerializeField] private bool _invcble;

    public Action OnDeath;
    
    public virtual void GetDmg(float dmg)
    {
        if (_invcble) return;
        if(_hp == 0) return;
        
        _hp = Mathf.Max(0, _hp - dmg);
        if(_hp == 0) OnDeath?.Invoke();
        
        _invcble = true;
        StartCoroutine(IFrameTimer());
    }

    public IEnumerator IFrameTimer()
    {
        yield return new WaitForSeconds(_iframes);
        _invcble = false;
    }
}
