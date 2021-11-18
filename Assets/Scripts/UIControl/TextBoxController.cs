using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextBoxController : MonoBehaviour
{
    [SerializeField] RectTransform textBox;
    [SerializeField] TextMeshProUGUI uiText;
    IEnumerator typeWriter;
    public void ShowText(string text, float time)
    {
        if (typeWriter != null)
        {
            HideText();
            StopCoroutine(typeWriter);
            typeWriter = null;
        }

        typeWriter = TypeWriter(text);

        uiText.text = "";
        textBox.gameObject.SetActive(true);
        StartCoroutine(typeWriter);
        Invoke("HideText", time);
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
