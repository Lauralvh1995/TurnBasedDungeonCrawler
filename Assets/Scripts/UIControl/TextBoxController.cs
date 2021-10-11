using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextBoxController : MonoBehaviour
{
    [SerializeField] RectTransform textBox;
    [SerializeField] TextMeshProUGUI uiText;

    public void ShowText(string text)
    {
        textBox.gameObject.SetActive(true);
        StartCoroutine(TypeWriter(text));
        Invoke("HideText", 5f);
    }

    IEnumerator TypeWriter(string text)
    {
        for(int i = 0; i < text.Length; i++)
        {
            uiText.text += text[i];
            yield return null;
        }
    }

    private void HideText()
    {
        uiText.text = "";
        textBox.gameObject.SetActive(false);
    }
}
