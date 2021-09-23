using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaterLevel : MonoBehaviour
{
    [SerializeField] private int currentLevel;
    [SerializeField] private WaterLevelEvent waterLevelChangedEvent;
    [SerializeField] Transform waterLevelVisual;

    public void IncreaseLevel()
    {
        currentLevel++;
        waterLevelVisual.position += Vector3.up;
        waterLevelChangedEvent?.Invoke(currentLevel);
    }
    public void DecreaseLevel()
    {
        currentLevel--; 
        waterLevelVisual.position += Vector3.down;
        waterLevelChangedEvent?.Invoke(currentLevel);
    }
}

[Serializable]
public class WaterLevelEvent : UnityEvent<int>
{

}
