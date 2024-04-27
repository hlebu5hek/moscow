using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MiniGames.Scripts
{
    public class MiniGameWithSub : BaseMinigame
    {
        public UnityEvent onSubMinigameFinished;
        public List<GameObject> gameViews;
        public int curIndex;

        public override void StartGame()
        {
            curIndex = 0;
            StartSubGame();
        }

        private void StartSubGame()
        {
            if (gameView != null)
            {
                gameView.SetActive(false);
            }
            gameView = gameViews[curIndex];
            print(gameView);
            gameView.SetActive(true);
        }

        public override void FinishGame()
        {
            if (curIndex + 1 < gameViews.Count)
            {
                curIndex += 1;
                onSubMinigameFinished.Invoke();
                StartSubGame();
            }
            else
            {
                base.FinishGame();
            }
        }
    }
}