using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DialogSystem.Scripts
{
    public class ChoiceView : MonoBehaviour
    {
        public Button buttonPrefab;

        public void SetTexts(DialogViewer dialogViewer, TextVariant[] variants)
        {
            foreach (var t in variants)
            {
                Button button = Instantiate(buttonPrefab, transform);
                button.GetComponent<TMP_Text>().text = "> " + t.text;
                int index = t.toIndex;
                button.onClick.AddListener(() =>
                {
                    dialogViewer.NextText(index);
                    Close();
                });
            }
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }
    }
}