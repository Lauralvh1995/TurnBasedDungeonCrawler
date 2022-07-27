using Assets.Scripts.Entity;
using Assets.Scripts.Grid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOutOfRange : StateChangeCondition
{
    [SerializeField] private List<Tile> path;
    [SerializeField] private int chaseRange;
    private void Start()
    {
        path = GetComponentInParent<Chasing>().GetCurrentPath();
        chaseRange = GetComponentInParent<Enemy>().GetEnemyStats().GetChaseRange();
    }
    public override bool ConditionMet()
    {
        path = GetComponentInParent<Chasing>()?.GetCurrentPath();
        return path.Count > chaseRange;
    }
}
