using Assets.Scripts.Entity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Attacking : State
{
    private EnemyStats stats;

    private void Awake()
    {
        stats = GetComponentInParent<Enemy>().GetEnemyStats();
    }
    public override void ExecuteState()
    {
        Vector3 target = brain.GetPlayer().transform.position;
        //check if either primary or secondary attack can hit
        //face the correct way
        //execute that one
        //brain.Attack(target);
        //brain.AlternateAttack(target);
        CheckTransitions();
    }
}
