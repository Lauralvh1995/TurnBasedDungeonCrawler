using Assets.Scripts.Entity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrolling : State
{

    [SerializeField] private State OnNoticePlayer;

    [SerializeField] List<Vector3> waypoints;
    [SerializeField] int currentWaypointIndex = 0;
    [SerializeField] Color waypointColor = Color.cyan;
    [SerializeField] float gizmoSize = 0.1f;

    public override void ExecuteState()
    {
        //make move towards next waypoint
        //if reached, set next waypoint
        if(Vector3.Distance(transform.position, waypoints[currentWaypointIndex]) > 0.1f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count;
        }
        CheckTransitions();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = waypointColor;
        foreach(Vector3 waypoint in waypoints)
        {
            Gizmos.DrawSphere(waypoint, gizmoSize);
        }
    }
}
