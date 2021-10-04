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

    public void ChangeLevel(bool state)
    {
        if (state)
        {
            currentLevel++;
            waterLevelVisual.position += Vector3.up;
            GridController.Instance.ChangeWaterLevel(currentLevel);
        }
        else
        {
            currentLevel--;
            waterLevelVisual.position += Vector3.down;
            GridController.Instance.ChangeWaterLevel(currentLevel);
        }
        
    }

    public int GetCurrentLevel()
    {
        return currentLevel;
    }
}


