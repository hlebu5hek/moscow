using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IO_UIOpener : InteractableObject
{
    [SerializeField] private InteractableUI ui;
    
    protected override void Awake()
    {
        base.Awake();
        Activate();
    }
    
    public void Activate()
    {
        OnInteractE += ShowUI;
    }
    
    public void Deactivate()
    {
        OnInteractE -= ShowUI;
    }
    
    protected virtual void ShowUI()
    {
        ui.gameObject.SetActive(true);
        ui.SetParentUIOpener(this);
        PlayerInteracter.PI.enabled = false;
        PlayerMovementCtrl.PMC.enabled = false;
    }

    public virtual void HideUI()
    {
        ui.gameObject.SetActive(false);
        ui.SetParentUIOpener(this);
        PlayerInteracter.PI.enabled = true;
        PlayerMovementCtrl.PMC.enabled = true;
    }
}
