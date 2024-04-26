using System;
using System.Linq;
using UnityEngine;

namespace Tasks.Scripts.Core
{

    [Serializable]
    public class Task
    {
        public string taskText;
        public Subtask[] subtasks;

        public bool IsCompleted => _IsCompleted();
        private bool _IsCompleted()
        {
            foreach (var t in subtasks)
            {
                if (!t.IsCompleted)
                {
                    return false;
                }
            }

            return true;
        }
    }

    [Serializable]
    public class Subtask
    {
        public string subtaskText;
        public int requiredProgress;
        public int progress;
        public bool IsCompleted => progress >= requiredProgress;

        public bool UpdateProgress(int val)
        {
            progress = val;
            return IsCompleted;
        }
        public bool AddProgress(int val)
        {
            progress += val;
            return IsCompleted;
        }
    }
}