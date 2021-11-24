using Assets.Scripts.Entity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(State))]
public class Patrolling : MonoBehaviour
{
    private State state;
    private EntityActions actions;

    [SerializeField] private State OnNoticePlayer;

    [SerializeField] List<Vector3> waypoints;
    [SerializeField] int currentWaypointIndex = 0;
    [SerializeField] Color waypointColor = Color.cyan;
    [SerializeField] float gizmoSize = 0.1f;

    private void Awake()
    {
        state = GetComponent<State>();
        
    }
    public void Execute()
    {
        //make move towards next waypoint
        //if reached, set next waypoint
        if(Vector3.Distance(transform.position, waypoints[currentWaypointIndex]) > 0.1f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count;
        }
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
