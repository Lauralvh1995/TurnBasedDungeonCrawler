using Assets.Scripts.Grid;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaterLevel : MonoBehaviour
{
    [SerializeField] private int currentLevel;
    [SerializeField] private GridController grid;
    [SerializeField] Transform waterLevelVisual;

    public void ChangeLevel(bool state)
    {
        if (state)
        {
            currentLevel++;
            waterLevelVisual.position += Vector3.up;
            grid.ChangeWaterLevel(currentLevel);
        }
        else
        {
            currentLevel--;
            waterLevelVisual.position += Vector3.down;
            grid.ChangeWaterLevel(currentLevel);
        }
    }
}


