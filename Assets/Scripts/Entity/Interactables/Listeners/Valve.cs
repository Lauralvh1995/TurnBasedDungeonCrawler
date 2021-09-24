using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Valve : Listener
{
    [SerializeField] private bool on;
    [SerializeField] private WaterLevelEvent waterLevelChanged;

    public override void Execute()
    {
        on = !on;
        waterLevelChanged.Invoke(on);
    }
}
[Serializable]
public class WaterLevelEvent : UnityEvent<bool>
{

}
