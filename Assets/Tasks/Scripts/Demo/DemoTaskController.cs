using System;
using Tasks.Scripts.Core;
using UnityEngine;

namespace Tasks.Scripts.Demo
{
    public class DemoTaskController : MonoBehaviour
    {

        public void Task1Sub1()
        {
            TaskManager.Instant.SetSubtaskProgress(0, 0, 1);
        }
        public void Task1Sub2()
        {
            TaskManager.Instant.SetSubtaskProgress(0, 1, 1);
        }
        public void Task1Sub3()
        {
            TaskManager.Instant.AddSubtaskProgress(0, 2, 1);
        }
    
        public void Task2Sub0()
        {
            TaskManager.Instant.SetSubtaskProgress(1, 0, 1);
        }
    }
}
