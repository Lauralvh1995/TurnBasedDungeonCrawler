using Assets.Scripts.Entity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOutOfRange : StateChangeCondition
{
    [SerializeField] private int pathLength;
    [SerializeField] private int chaseRange;
    private void Start()
    {
        pathLength = GetComponentInParent<Chasing>().GetCurrentPathLength();
        chaseRange = GetComponentInParent<Enemy>().GetEnemyStats().GetChaseRange();
    }
    public override bool ConditionMet()
    {
        pathLength = GetComponentInParent<Chasing>().GetCurrentPathLength();
        return pathLength > chaseRange;
    }
}
