using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using MiniGames.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace DialogSystem.Scripts
{
    public class DialogViewer : MonoBehaviour
    {
        public List<ContentContainer> ContentContainer;
        public int current;
        private ScrollRect ScrollRect;
        public int currentText;
        public float textPause = 1;
        [Header("UI")] public Transform textContainer;
        public TMP_Text textPrefab;
        public TMP_Text answerPrefab;
        public ChoiceView choiceViewPrefab;
        [Header("Events")] public UnityEvent onEndDialog;

        [SerializeField] private bool isDebug;
        
        private void Awake()
        {
            ScrollRect = GetComponentInChildren<ScrollRect>();
        }

        private void Update()
        {
            ScrollRect.normalizedPosition = new Vector2(0, 0);
        }
        
        public void StartDialog(int dialog, BaseMinigame game)
        {
            onEndDialog.RemoveAllListeners();

            if (game)
            {
                onEndDialog.AddListener(game.StartGame);
                game.onGameFinished.AddListener(parent.End);
            }
            else
            {
                onEndDialog.AddListener(parent.End);
            }
            
            current = dialog;
            currentText = 0;
            StartCoroutine(ShowText());
        }

        public void NextText(int id = -1)
        {
            if (id == -1)
            {
                id = currentText + 1;
            }

            if (id < ContentContainer[current].texts.Length)
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
            onEndDialog?.Invoke();
        }

        public TMP_Text AddText(string txt, bool alt = false)
        {
            TMP_Text text = Instantiate(alt ? answerPrefab : textPrefab, textContainer);
            text.text = txt;
            return text;
        }

        IEnumerator ShowText()
        {
            TextData textData = ContentContainer[current].texts[currentText];
            TMP_Text text = !textData.player ? AddText("- ") : AddText("");

            float symbolTime = textData.delayTime / textData.text.Length;
            foreach (var symbol in textData.text)
            {
                text.text += symbol;
                if(!isDebug)
                    yield return new WaitForSeconds(symbolTime);
                else
                    yield return new WaitForEndOfFrame();
            }

            if (textData.variants.Length > 0)
            {
                ShowVariants(textData.variants);
            }
            else
            {
                if(!isDebug)
                    yield return new WaitForSeconds(textPause);
                else
                    yield return new WaitForEndOfFrame();
                NextText(textData.nextIndex);
            }
        }

        public void ShowVariants(TextVariant[] variants)
        {
            ChoiceView choiceView = Instantiate(choiceViewPrefab, textContainer);
            choiceView.SetTexts(this, variants);
        }
        
        [SerializeField] private IO_UIOpener parent;
    
        public void SetParentUIOpener(IO_UIOpener par)
        {
            parent = par;
        }
    }
}