using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
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

        public UnityEvent OnDayChange;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            Instance = this;
        }

        private void Start()
        {
            LoadDay(0);
        }

        public void LoadDay(int dayIndex)
        {
            if (dayIndex >= 0 && dayIndex < daysInfos.days.Length)
            {
                headerText.text = daysInfos.days[dayIndex].dayName;
                subheaderText.text = daysInfos.days[dayIndex].dayDescription;
                _animator.SetTrigger("Show");
                Freeze();
            }
        }

        public void Freeze()
        {
            PlayerInteracter.PI.freezed = true;
            PlayerMovementCtrl.PMC.freezed = true;
        }

        public void UnFreeze()
        {
            PlayerInteracter.PI.freezed = false;
            PlayerMovementCtrl.PMC.freezed = false;
            OnDayChange?.Invoke();
        }
    }
}