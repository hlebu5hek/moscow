using UnityEngine;
using UnityEngine.Events;

namespace MiniGames.Scripts
{
    public class BaseMinigame : MonoBehaviour
    {
        public UnityEvent onGameFinished; 
        public GameObject gameView;
        public virtual void StartGame()
        {
            gameView.SetActive(true);
        }
    
        public virtual void FinishGame()
        {
            onGameFinished.Invoke();
            gameView.SetActive(false);
        }
    }
}
