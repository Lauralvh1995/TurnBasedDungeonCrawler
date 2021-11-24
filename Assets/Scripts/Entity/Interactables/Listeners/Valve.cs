using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace Assets.Scripts.Entity
{
    public class Valve : Listener
    {
        [SerializeField] private bool on;
        [SerializeField] public WaterLevelEvent waterLevelChanged;

        public override void Execute()
        {
            on = !on;
            waterLevelChanged.Invoke(on);
        }
    }
}
[Serializable]
public class WaterLevelEvent : UnityEvent<bool>
{

}
