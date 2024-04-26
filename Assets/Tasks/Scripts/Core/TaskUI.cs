using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Tasks.Scripts.Core
{
    public class TaskUI : MonoBehaviour
    {
        public TaskManager taskManager;
        public Transform subtaskParent;

        [Header("UI")] 
        public SubTaskView subTaskView;

        public TMP_Text headerText;

        public List<SubTaskView> subtasksList;

        private void Awake()
        {
            taskManager = Instantiate(taskManager);
            taskManager.SetSingletone();
            taskManager.onTaskCompleted.AddListener(UpdateTask);
            taskManager.onSubtaskCompleted.AddListener(UpdateSubtask);
            taskManager.onSubtaskEdited.AddListener(UpdateSubtask);
            UpdateTask();
        }

        private void UpdateTask()
        {
            headerText.text = taskManager.CurrentTask.taskText;
            subtasksList.ForEach(s => Destroy(s.gameObject));
            subtasksList.Clear();
            foreach (var t in taskManager.CurrentTask.subtasks)
            {
                SubTaskView viewer = Instantiate(subTaskView, subtaskParent);
                subtasksList.Add(viewer);
                viewer.SetData(t);
            }
        }

        private void UpdateSubtask(int index)
        {
            subtasksList[index].UpdateProgress(taskManager.CurrentTask.subtasks[index]);
        }
    }
}
