using MiniGames.Scripts;
using System;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;
using Slider = UnityEngine.UI.Slider;

namespace MiniGames.Game1.Scripts
{
    public class GraphColntroller : MonoBehaviour
    {
        private BaseMinigame _baseMinigame;
        public GraphHandler sourceGraph;
        public GraphHandler targetGraph;

        public Slider sliderX;
        public Slider sliderY;

        public ProgressBar _progressBar;

        private void Awake()
        {
            _baseMinigame = GetComponentInParent<BaseMinigame>();
        }

        public void ChangeXValueGraph(Single value)
        {
            targetGraph.GetComponent<GraphSettings>().GraphScale = new Vector2(value, targetGraph.GetComponent<GraphSettings>().GraphScale.y);
            UpdateProgress();
            if (CheckComplete()) _baseMinigame.FinishGame();
        }

        public void ChangeYValueGraph(Single value)
        {
            targetGraph.GetComponent<GraphSettings>().GraphScale = new Vector2(targetGraph.GetComponent<GraphSettings>().GraphScale.x, value);
            UpdateProgress();
            if (CheckComplete()) {_baseMinigame.FinishGame();}
        }

        public float GetProgress()
        {
            float x = 1 - Mathf.Min(1, Mathf.Abs(targetGraph.GetComponent<GraphSettings>().GraphScale.x - sourceGraph.GetComponent<GraphSettings>().GraphScale.x) / 50);
            float y = 1 - Mathf.Min(1, Mathf.Abs(targetGraph.GetComponent<GraphSettings>().GraphScale.y - sourceGraph.GetComponent<GraphSettings>().GraphScale.y) / 50);
            return (x + y) / 2;
        }

        public void UpdateProgress()
        {
            _progressBar.SetProgress(GetProgress());
        }

        public bool CheckComplete()
        {
            return GetProgress() >= 0.95f;
        }
    }
}