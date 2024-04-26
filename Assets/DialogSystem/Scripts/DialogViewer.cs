using System.Collections;
using System.Collections.Generic;
using DialogSystem.Scripts;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class DialogViewer : MonoBehaviour
{
    public ContentContainer ContentContainer;
    public int currentText;
    public float textPause = 1;
    [Header("UI")] public Transform textContainer;
    public TMP_Text textPrefab;
    public ChoiceView choiceViewPrefab;
    [Header("Events")] public UnityEvent onEndDialog;

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

        EndDialog();
    }

    void EndDialog()
    {
        onEndDialog.Invoke();
    }

    IEnumerator ShowText()
    {

        TextData textData = ContentContainer.texts[currentText];
        TMP_Text text = Instantiate(textPrefab, textContainer);
        float symbolTime = textData.delayTime / textData.text.Length;
        text.text += "* ";
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