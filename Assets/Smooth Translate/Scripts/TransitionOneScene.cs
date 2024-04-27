using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Smooth_Translate.Scripts
{
    
    public class TransitionOneScene : MonoBehaviour
    {
        public static TransitionOneScene Instance;
        public DaysInfo daysInfos;
        [Header("UI")]
        public TMP_Text headerText;
        public TMP_Text subheaderText;
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            Instance = this;
        }

        public void LoadDay(int dayIndex)
        {
            if (dayIndex > 0 && dayIndex < daysInfos.days.Length)
            {
                headerText.text = daysInfos.days[dayIndex].dayName;
                subheaderText.text = daysInfos.days[dayIndex].dayDescription;
                _animator.SetTrigger("Show");
            }
        }
    }
}