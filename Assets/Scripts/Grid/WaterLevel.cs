using Assets.Scripts.Grid;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaterLevel : MonoBehaviour
{
    [SerializeField] private int currentLevel;
    [SerializeField] Transform waterLevelVisual;

    [SerializeField] private float waterChangeSpeed = 0.3f;

    public void ChangeLevel(bool state)
    {
        if (state)
        {
            currentLevel++;
            StartCoroutine(ChangeWaterLevel(Vector3.up));
        }
        else
        {
            currentLevel--;
            StartCoroutine(ChangeWaterLevel(Vector3.down));
        }
    }

    IEnumerator ChangeWaterLevel(Vector3 dir)
    {
        Vector3 from = waterLevelVisual.position;
        Vector3 to = waterLevelVisual.position + dir;
        
        for (float t = 0f; t <= 1; t += Time.deltaTime / waterChangeSpeed)
        {
            waterLevelVisual.position = Vector3.Lerp(from, to, t);
            yield return null;
        }
        GridController.Instance.ChangeWaterLevel();
    }

    public int GetCurrentLevel()
    {
        return currentLevel;
    }
}


