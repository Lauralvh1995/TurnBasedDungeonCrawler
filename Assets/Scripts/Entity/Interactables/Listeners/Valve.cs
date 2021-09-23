using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valve : Listener
{
    [SerializeField] private bool on;
    [SerializeField] private WaterLevel waterLevel;

    private void Awake()
    {
        waterLevel = grid.GetComponent<WaterLevel>();
    }
    public override void Execute()
    {
        on = !on;
        if (on)
        {
            waterLevel.IncreaseLevel();
        }
        else
        {
            waterLevel.DecreaseLevel();
        }
    }
}
