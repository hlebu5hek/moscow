using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class W_Pistol : W_MouseInteract
{
    protected override void Awake()
    {
        base.Awake();
        OnReload += Reload;
    }

    protected override void Shoot()
    {
        if (is_reload) return;
        if (b_ammo == 0) return;
        if (b_round == 0)
        {
            OnReload?.Invoke(); 
            return;
        }
        
        base.Shoot();
        b_round -= 1;
    }
    
    protected void Reload()
    {
        if (is_reload) return;
        if (b_ammo == 0) return;
        if (b_round == b_roundammo) return;
        is_reload = true;

        StartCoroutine(Reloading());
    }

    protected IEnumerator Reloading()
    {
        //anim.play
        yield return new WaitForSeconds(r_time);

        b_ammo -= b_roundammo - b_round;
        b_round = b_roundammo;
        
        if (b_ammo < 0)
        {
            b_round += b_ammo;
            b_ammo = 0;
        }
        
        is_reload = false;
    }
}
