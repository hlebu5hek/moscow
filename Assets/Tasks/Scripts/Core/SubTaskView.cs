using TMPro;
using UnityEngine;

namespace Tasks.Scripts.Core
{
    public class SubTaskView : MonoBehaviour
    {
        public TMP_Text subtaskText;
        public TMP_Text progressText;
        
        public void SetData(Subtask subtask)
        {
            subtaskText.text = subtask.subtaskText;
            UpdateProgress(subtask);
        }

        public void UpdateProgress(Subtask subtask)
        {
            if (subtask.IsCompleted)
            {
                progressText.text = "Completed";
                // print(TaskManager.Instant.CurrentTask.IsCompleted);
            }

            else
            {
                // print(subtask.progress);
                progressText.text = subtask.progress + " / " + subtask.requiredProgress;
            }
        }
    }
}
