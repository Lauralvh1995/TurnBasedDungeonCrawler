using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawPlayer : StateChangeCondition
{
    [SerializeField] int visionRange;
    public override bool ConditionMet()
    {
        //do something with a fov cone thing
        return true;
    }
}
