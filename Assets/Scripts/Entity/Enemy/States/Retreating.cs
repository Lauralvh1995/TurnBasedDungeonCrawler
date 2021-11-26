using Assets.Scripts.Entity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Retreating : State
{
    [SerializeField] private Vector3 leashPoint;
    [SerializeField] float gizmoSize = 0.1f;

    public override void ExecuteState()
    {
        //make move towards leash point
        CheckTransitions();
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(leashPoint, Vector3.one * gizmoSize);
    }
}
