using Assets.Scripts.Entity;
using Assets.Scripts.Grid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOutOfChaseRange : StateChangeCondition
{
    [SerializeField] private Transform player;
    [SerializeField] private int chaseRange;
    private void Start()
    {
        player = GetComponentInParent<Chasing>().GetPlayer();
        chaseRange = GetComponentInParent<Enemy>().GetEnemyStats().GetChaseRange();
    }
    public override bool ConditionMet()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        return distance > chaseRange;
    }
}
