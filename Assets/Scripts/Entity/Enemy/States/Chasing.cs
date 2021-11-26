using Assets.Scripts.Entity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chasing : State
{
    [SerializeField] private Transform target;
    [SerializeField, Range(1,20)] private int maxDistance;

    private EnemyStats stats;
    private void Awake()
    {
        stats = GetComponentInParent<Enemy>().GetEnemyStats();
    }

    public override void ExecuteState()
    {
        //target = player position
        //move towards player

        CheckTransitions();
        //if Player is within attack range -> change to attacking
        //if Player is out of chase range -> change to retreating
    }

}
