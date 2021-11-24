using Assets.Scripts.Entity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(State))]
public class Attacking : MonoBehaviour
{
    private State state;
    private EntityActions actions;
    private EnemyStats stats;

    private void Awake()
    {
        state = GetComponent<State>();
        stats = GetComponentInParent<Enemy>().GetEnemyStats();
    }
    public void Execute()
    {
        //check if either primary or secondary attack can hit
        //face the correct way
        //execute that one
    }
}
