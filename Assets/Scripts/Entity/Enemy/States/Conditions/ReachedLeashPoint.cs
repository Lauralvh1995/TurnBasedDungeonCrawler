using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReachedLeashPoint : StateChangeCondition
{
    public Vector3 leashPoint;
    public override bool ConditionMet()
    {
        return Vector3.Distance(transform.position, leashPoint) < 0.01f;
    }
}
