using DialogSystem.Scripts;
using UnityEngine;
using UnityEngine.Events;

namespace MiniGames.Scripts
{
    public class BaseMinigame : MonoBehaviour
    {
        public UnityEvent onGameFinished; 
        public GameObject gameView;

        public int dialogInd;
        public DialogViewer dv;
        public virtual void StartGame()
        {
            gameView.SetActive(true);
        }
    
        public virtual void FinishGame()
        {
            if (dialogInd != -1)
            {
                dv.onEndDialog.AddListener(onGameFinished.Invoke);
                dv.StartDialog(dialogInd, null);
            }
            else
                onGameFinished.Invoke();
            gameView.SetActive(false);
        }
    }
}
