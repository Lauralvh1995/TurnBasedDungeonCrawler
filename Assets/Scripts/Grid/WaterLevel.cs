using Assets.Scripts.Grid;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaterLevel : MonoBehaviour
{
    [SerializeField] Transform waterLevelVisual;
    [SerializeField] Vector3 baseLevel;
    [SerializeField] Vector3 upperLevel;

    [SerializeField] private float waterChangeSpeed = 0.3f;
    [SerializeField] ChangingWaterLevelEvent changingWaterLevelEvent;
    [SerializeField] ChangedWaterLevelEvent changedWaterLevel;

    bool changingLevel;

    private void Awake()
    {
        baseLevel = transform.position;
        upperLevel = baseLevel + Vector3.up;
    }
    public void ChangeLevel(bool state)
    {
        if (!changingLevel)
        {
            if (state)
            {
                changingLevel = true;
                StartCoroutine(ChangeWaterLevel(upperLevel));
            }
            else
            {
                changingLevel = true;
                StartCoroutine(ChangeWaterLevel(baseLevel));
            }
        }
    }

    IEnumerator ChangeWaterLevel(Vector3 destination)
    {
        changingWaterLevelEvent.Invoke();
        Vector3 from = waterLevelVisual.position;
        
        for (float t = 0f; t <= 1; t += Time.deltaTime / waterChangeSpeed)
        {
            waterLevelVisual.position = Vector3.Lerp(from, destination, t);
            yield return null;
        }
        waterLevelVisual.position = destination;
        changingLevel = false;
        changedWaterLevel.Invoke();
    }
}
[Serializable]
public class ChangingWaterLevelEvent : UnityEvent
{

}
[Serializable]
public class ChangedWaterLevelEvent : UnityEvent
{

}


