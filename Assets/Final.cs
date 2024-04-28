using System;
using System.Collections;
using System.Collections.Generic;
using Tasks.Scripts.Core;
using UnityEngine;

public class Final : MonoBehaviour
{
    [SerializeField] private Animator FinalAnim;
    [SerializeField] private GameObject door;
    
    private bool isFinal = false;
    
    
    public void StartFinal()
    {
        isFinal = true;
        StartCoroutine(CountDown());
    }

    public void StartAnim()
    {
        PlayerInteracter.PI.freezed = true;
        PlayerMovementCtrl.PMC.freezed = true;
        TaskManager.Instant.SetSubtaskProgress(15, 0, 1);
        door.SetActive(false);
        FinalAnim.SetTrigger("f");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(isFinal) StartAnim();
    }

    public IEnumerator CountDown()
    {
        yield return new WaitForSeconds(6f);
        TaskManager.Instant.SetSubtaskProgress(14, 0, 1);
    }
}
