using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Tasks.Scripts.Core
{
    [CreateAssetMenu(menuName = nameof(Tasks) + "/" + nameof(Scripts) + "/" + nameof(TaskManager),
        fileName = nameof(TaskManager))]
    public class TaskManager : ScriptableObject
    {
        public UnityEvent onTaskCompleted;
        public UnityEvent<int> onSubtaskCompleted;
        public UnityEvent<int> onSubtaskEdited;
        public List<Task> taskList;
        public int currentTaskIndex;
        public static TaskManager Instant;

        public void SetSingletone()
        {
            Instant = this;
        }
        public Task CurrentTask => taskList[currentTaskIndex];

        public void SetSubtaskProgress(int index, int subtaskIndex, int progress)
        {
            if (index == currentTaskIndex && subtaskIndex < CurrentTask.subtasks.Length)
            {
                Subtask subtask = CurrentTask.subtasks[subtaskIndex];
                if (!subtask.IsCompleted)
                {
                    if (subtask.UpdateProgress(progress))
                    {
                        onSubtaskCompleted.Invoke(subtaskIndex);
                        CheckTaskCompleted();
                    }
                    else
                    {
                        onSubtaskEdited.Invoke(subtaskIndex);
                    }
                }
            }
        }
        public void AddSubtaskProgress(int index, int subtaskIndex, int progress)
        {
            if (index == currentTaskIndex && subtaskIndex < CurrentTask.subtasks.Length)
            {
                Subtask subtask = CurrentTask.subtasks[subtaskIndex];
                if (!subtask.IsCompleted)
                {
                    if (subtask.AddProgress(progress))
                    {
                        onSubtaskCompleted.Invoke(subtaskIndex);
                        CheckTaskCompleted();
                    }
                    else
                    {
                        onSubtaskEdited.Invoke(subtaskIndex);
                    }
                }
            }
        }

        private void CheckTaskCompleted()
        {
            if (CurrentTask.IsCompleted)
            {
                currentTaskIndex++;
                onTaskCompleted.Invoke();
            }
        }
    }
}
