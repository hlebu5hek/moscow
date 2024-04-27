using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    public TMP_Text LoadingPercentage;
    public Image LoadingProgressBar;
    
    private static SceneTransition instance;
    private static bool shouldPlayOpeningAnimation = false; 
    
    private Animator componentAnimator;
    private AsyncOperation loadingSceneOperation;

    public static void SwitchToScene(string sceneName)
    {
        instance.componentAnimator.SetTrigger("sceneClosing");

        instance.loadingSceneOperation = SceneManager.LoadSceneAsync(sceneName);
        
        // Чтобы сцена не начала переключаться пока играет анимация closing:
        instance.loadingSceneOperation.allowSceneActivation = false;
        
        instance.LoadingProgressBar.fillAmount = 0;
    }
    
    private void Start()
    {
        instance = this;
        
        componentAnimator = GetComponent<Animator>();
        
        if (shouldPlayOpeningAnimation) 
        {
            componentAnimator.SetTrigger("sceneOpening");
            instance.LoadingProgressBar.fillAmount = 1;
            
            // Чтобы если следующий переход будет обычным SceneManager.LoadScene, не проигрывать анимацию opening:
            shouldPlayOpeningAnimation = false; 
        }
    }

    private void Update()
    {
        if (loadingSceneOperation != null)
        {
            LoadingPercentage.text = Mathf.RoundToInt((loadingSceneOperation.progress + 0.1f) * 100) + "%";
            
            LoadingProgressBar.fillAmount = Mathf.Lerp(LoadingProgressBar.fillAmount , loadingSceneOperation.progress + 0.1f,
                Time.deltaTime * 5);
            if (loadingSceneOperation.progress >= 0.9f)
            {
                componentAnimator.SetBool("Loaded", true);
            }
        }
    }

    public void OnAnimationOver()
    {
        // Чтобы при открытии сцены, куда мы переключаемся, проигралась анимация opening:
        shouldPlayOpeningAnimation = true;
        
        loadingSceneOperation.allowSceneActivation = true;
    }
}
