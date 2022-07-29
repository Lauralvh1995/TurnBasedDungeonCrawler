using Assets.Scripts.Entity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOutOfAttackRange : StateChangeCondition
{
    [SerializeField] private EnemyStats enemyStats;
    [SerializeField] private Transform player;
    private void Start()
    {
        enemyStats = GetComponentInParent<Enemy>().GetEnemyStats();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    public override bool ConditionMet()
    {
        int attackRange = enemyStats.GetPrimaryAttack().GetAttackRange();
        int alternateAttackRange = enemyStats.GetSecondaryAttack().GetAttackRange();
        float distance = Vector3.Distance(transform.position, player.position);
        return distance > attackRange || distance > alternateAttackRange;
    }
}
