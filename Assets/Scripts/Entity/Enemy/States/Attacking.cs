using Assets.Scripts.Entity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Attacking : State
{
    [SerializeField] private EnemyStats stats;
    [SerializeField] private Transform player;

    public override void EnterState(EnemyBrain brain)
    {
        base.EnterState(brain);
        stats = GetComponentInParent<Enemy>().GetEnemyStats();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    public override void ExecuteState()
    {
        //check if either primary or secondary attack can hit
        //face the correct way
        //execute that one
        //brain.Attack(target);
        //brain.AlternateAttack(target);
        Vector3 target = player.position;
        int primaryAttackRange = stats.GetPrimaryAttack().GetAttackRange();
        int secondaryAttackRange = stats.GetSecondaryAttack().GetAttackRange();
        float distance = Vector3.Distance(transform.position, target);
        if (distance <= primaryAttackRange)
        {
            brain.Attack(target);
            CheckTransitions();
            return;
        }
        if (distance <= secondaryAttackRange)
        {
            brain.AlternateAttack(target);
            CheckTransitions();
            return;
        }
        CheckTransitions();
    }
}
