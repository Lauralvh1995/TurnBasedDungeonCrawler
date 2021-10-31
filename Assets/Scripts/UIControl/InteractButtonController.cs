using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractButtonController : MonoBehaviour
{
    [SerializeField] RectTransform interactGraphic;

    public void Show(Vector2 pos)
    {
        interactGraphic.position = pos;
        interactGraphic.gameObject.SetActive(true);
    }
    public void Hide()
    {
        interactGraphic.gameObject.SetActive(false);
    }
}
