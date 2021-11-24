using Assets.Scripts.Entity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chasing : State
{
    [SerializeField] private State OnPlayerWithinReach;
    [SerializeField] private State OnLeashPointReached;

    [SerializeField] private Vector3 leashPoint;
    [SerializeField] float gizmoSize = 0.1f;
    [SerializeField] private Vector3 target;
    [SerializeField, Range(1,20)] private int maxDistance;
    public override void ExecuteState()
    {
        //target = player position

        //if player is more than maxDistance moves away
        //target = leashPoint
        //make move towards target (usually player)
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(leashPoint, Vector3.one * gizmoSize);
    }
}
