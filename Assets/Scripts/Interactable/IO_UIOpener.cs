using System.Collections;
using System.Collections.Generic;
using DialogSystem.Scripts;
using MiniGames.Scripts;
using Tasks.Scripts.Core;
using UnityEngine;
using UnityEngine.Events;

public class IO_UIOpener : InteractableObject
{
    [SerializeField] private BaseMinigame game;
    [SerializeField] private bool activateOnStart;
    [SerializeField] private DialogViewer dialog;
    [SerializeField] private GameObject canvas;
    public int taskInd;
    public List<int> dialogInd;
    public int current;
    
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
        OnInteractE += ShowUI;
        
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
        canvas.SetActive(true);
        dialog.SetParentUIOpener(this);
        PlayerInteracter.PI.freezed = true;
        PlayerMovementCtrl.PMC.SetVector(Vector2.zero);
        PlayerMovementCtrl.PMC.freezed = true;
        
        if(game)
            dialog.StartDialog(dialogInd[current], game);
        else 
            dialog.StartDialog(dialogInd[current], null);
        current++;
    }

    public void End()
    {
        if(taskInd != -1)
            TaskManager.Instant.SetSubtaskProgress(taskInd, 0, 1);

        HideUI();
    }

    public void SetTaskInd(int ind)
    {
        taskInd = ind;
    }
    
    public virtual void HideUI()
    {
        canvas.SetActive(false);
        dialog.SetParentUIOpener(this);
        PlayerInteracter.PI.freezed = false;
        PlayerMovementCtrl.PMC.freezed = false;
    }
}
