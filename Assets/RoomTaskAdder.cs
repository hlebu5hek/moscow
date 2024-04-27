using System;
using System.Collections;
using System.Collections.Generic;
using Tasks.Scripts.Core;
using UnityEngine;

public class RoomTaskAdder : MonoBehaviour
{
    [SerializeField] private int taskInd;

    private void OnTriggerEnter(Collider other)
    {
        TaskManager.Instant.SetSubtaskProgress(taskInd, 0, 1);
    }
}
