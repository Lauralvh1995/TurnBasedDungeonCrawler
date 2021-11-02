using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractButtonController : MonoBehaviour
{
    [SerializeField] RectTransform interactGraphic;
    [SerializeField] TextMeshProUGUI textGraphic;

    public void Show(Vector2 pos, string text)
    {
        textGraphic.text = text;
        interactGraphic.position = pos;
        interactGraphic.gameObject.SetActive(true);
    }
    public void Hide()
    {
        interactGraphic.gameObject.SetActive(false);
    }
}
