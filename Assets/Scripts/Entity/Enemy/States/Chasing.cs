using Assets.Scripts.Entity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(State))]
public class Chasing : MonoBehaviour
{
    private State state;
    private EntityActions actions;

    [SerializeField] private State OnPlayerWithinReach;
    [SerializeField] private State OnLeashPointReached;

    [SerializeField] private Vector3 leashPoint;
    [SerializeField] float gizmoSize = 0.1f;
    [SerializeField] private Vector3 target;
    [SerializeField, Range(1,20)] private int maxDistance;

    private void Awake()
    {
        state = GetComponent<State>();
    }
    public void Execute()
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
