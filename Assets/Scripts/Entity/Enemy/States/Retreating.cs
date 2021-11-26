using Assets.Scripts.Entity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Retreating : State
{
    [SerializeField] private Transform leashPoint;
    [SerializeField] float gizmoSize = 0.1f;

    public override void ExecuteState()
    {
        //make move towards leash point
        CheckTransitions();
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(leashPoint.position, Vector3.one * gizmoSize);
    }
}
