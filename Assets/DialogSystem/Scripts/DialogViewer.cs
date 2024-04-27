using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace DialogSystem.Scripts
{
    public class DialogViewer : MonoBehaviour
    {
        public ContentContainer ContentContainer;
        private ScrollRect ScrollRect;
        public int currentText;
        public float textPause = 1;
        [Header("UI")] public Transform textContainer;
        public TMP_Text textPrefab;
        public TMP_Text answerPrefab;
        public ChoiceView choiceViewPrefab;
        [Header("Events")] public UnityEvent onEndDialog;

        private void Awake()
        {
            ScrollRect = GetComponentInChildren<ScrollRect>();
        }

        private void Update()
        {
            ScrollRect.normalizedPosition = new Vector2(0, 0);
            ;
        }

        public void StartDialog()
        {
            currentText = 0;
            StartCoroutine(ShowText());
        }

        public void NextText(int id = -1)
        {
            if (id == -1)
            {
                id = currentText + 1;
            }

            if (id < ContentContainer.texts.Length)
            {
                currentText = id;
                StartCoroutine(ShowText());
            }
            else
            {
                EndDialog();
            }
        }

        void EndDialog()
        {
            onEndDialog.Invoke();
        }

        public TMP_Text AddText(string txt, bool alt = false)
        {
            TMP_Text text = Instantiate(alt ? answerPrefab : textPrefab, textContainer);
            text.text = txt;
            return text;
        }

        IEnumerator ShowText()
        {
            TextData textData = ContentContainer.texts[currentText];
            TMP_Text text = !textData.player ? AddText("- ") : AddText("");

            float symbolTime = textData.delayTime / textData.text.Length;
            foreach (var symbol in textData.text)
            {
                text.text += symbol;
                yield return new WaitForSeconds(symbolTime);
            }

            if (textData.variants.Length > 0)
            {
                ShowVariants(textData.variants);
            }
            else
            {
                yield return new WaitForSeconds(textPause);
                NextText(textData.nextIndex);
            }
        }

        public void ShowVariants(TextVariant[] variants)
        {
            ChoiceView choiceView = Instantiate(choiceViewPrefab, textContainer);
            choiceView.SetTexts(this, variants);
        }
    }
}