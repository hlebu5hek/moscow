using UnityEngine;
using UnityEngine.UI;

namespace MiniGames.Scripts
{
    public class ProgressBar : MonoBehaviour
    {
        public Image progressImage;

        public void SetProgress(float progress)
        {
            progressImage.fillAmount = progress;
        }
    }
}
