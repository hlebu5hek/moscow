using System.Collections;
using System.Collections.Generic;
using Tasks.Scripts.Core;
using UnityEngine;
using UnityEngine.Events;

public class IO_UIOpener : InteractableObject
{
    [SerializeField] private bool activateOnStart;
    [SerializeField] private InteractableUI ui;
    public int taskInd;

    public UnityEvent OnEnd;
    
    protected override void Awake()
    {
        if(activateOnStart)
            Activate();

        HideOutline();
    }
    
    public void Activate()
    {
        OnPlayerEnter += ShowOutline;
        OnPlayerExit += HideOutline;
        OnInteractE += Test;
        
        HideOutline();
    }
    
    public void Deactivate()
    {
        OnPlayerEnter -= ShowOutline;
        OnPlayerExit -= HideOutline;
        OnInteractE -= ShowUI;
        
        HideOutline();
    }
    
    protected virtual void ShowUI()
    {
        ui.gameObject.SetActive(true);
        ui.SetParentUIOpener(this);
        PlayerInteracter.PI.enabled = false;
        PlayerMovementCtrl.PMC.enabled = false;
    }

    public void Test()
    {
        TaskManager.Instant.SetSubtaskProgress(taskInd, 0, 1);
    }

    public void SetTaskInd(int ind)
    {
        taskInd = ind;
    }
    
    public virtual void HideUI()
    {
        OnEnd?.Invoke();
        ui.gameObject.SetActive(false);
        ui.SetParentUIOpener(this);
        PlayerInteracter.PI.enabled = true;
        PlayerMovementCtrl.PMC.enabled = true;
    }
}
