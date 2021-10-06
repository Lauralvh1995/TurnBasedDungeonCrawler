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

    public void Open()
    {
        bigMap.gameObject.SetActive(true);
        mapOpened?.Invoke(true);
    }

    public void Close()
    {
        bigMap.gameObject.SetActive(false);
        mapOpened?.Invoke(false);
    }
}

[Serializable]
public class MapOpenedEvent : UnityEvent<bool>
{

}


