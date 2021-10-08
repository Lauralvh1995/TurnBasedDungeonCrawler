using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MapUIController : MonoBehaviour
{
    [SerializeField] private RectTransform bigMap;
    [SerializeField] public MapOpenedEvent mapOpened;

    [SerializeField] private GameObject firstSelected;

    public void Open()
    {
        bigMap.gameObject.SetActive(true);
        mapOpened?.Invoke(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstSelected);
    }

    public void Close()
    {
        bigMap.gameObject.SetActive(false);
        mapOpened?.Invoke(false);
        EventSystem.current.SetSelectedGameObject(null);
    }
}

[Serializable]
public class MapOpenedEvent : UnityEvent<bool>
{

}


