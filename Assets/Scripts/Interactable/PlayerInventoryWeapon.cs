using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInventoryWeapon : MonoBehaviour
{
    [SerializeField] private Transform w_holder;
    [SerializeField] private int w_range, w_current;
    [SerializeField] private List<Weapon> w_list;
    
    public static PlayerInventoryWeapon PIW;
    public Action<Weapon> OnWeaponPickup;

    private void Awake()
    {
        PIW = this;
        OnWeaponPickup += AddWeapon;
        GameManager.FxUpd += FxUpd;
    }

    private void FxUpd()
    {
        if(Input.GetMouseButtonDown(0) && w_list[w_current])
            w_list[w_current].OnAttack?.Invoke();
        if(Input.GetMouseButtonUp(0) && w_list[w_current])
            w_list[w_current].OnStopAttack?.Invoke();
        if(Input.GetKeyDown(KeyCode.R) && w_list[w_current])
            w_list[w_current].OnReload?.Invoke();
        
        if(Input.mouseScrollDelta.y != 0) ChangeWeapon(Input.mouseScrollDelta.y);
    }

    private void ChangeWeapon(float delta)
    {
        int w_p = w_current;
        
        if (delta > 0) w_current = w_current + 1 >= w_range ? 0 : w_current + 1;
        if (delta < 0) w_current = w_current - 1 < 0 ? w_range - 1 : w_current - 1;
        
        if(w_list[w_p]) w_list[w_p].gameObject.SetActive(false);
        if(w_list[w_current]) w_list[w_current].gameObject.SetActive(true);
    }
    
    public void AddWeapon(Weapon w)
    {
        if (w_list[w_current]) DropWeapon(w_current);
        
        w_list[w_current] = w;
        w.transform.SetParent(w_holder);
        w.transform.localPosition = Vector3.zero;
        w.transform.localRotation = Quaternion.identity;
        w.Body.isKinematic = true;
        w.Trigger.enabled = false;
    }

    private void DropWeapon(int w_d)
    {
        Weapon w = w_list[w_d];
        w_list[w_d] = null;
        
        w.transform.SetParent(null);
        w.Body.isKinematic = false;
        w.Trigger.enabled = true;
    }
    
}
