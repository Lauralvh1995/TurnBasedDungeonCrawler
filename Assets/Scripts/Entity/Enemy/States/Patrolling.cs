using Assets.Scripts.Entity;
using Assets.Scripts.Grid;
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

    PathFinderMaster pathfinder;
    [SerializeField] List<Tile> currentPath;
    Tile currentTile; 
    public override void EnterState(EnemyBrain brain)
    {
        base.EnterState(brain);
        pathfinder = PathFinderMaster.GetInstance();
        currentTile = pathfinder.GetTile(transform.position);
        pathfinder.RequestFindPath(currentTile, pathfinder.GetTile(waypoints[currentWaypointIndex]), brain.IsFlying(), SetPath);
    }

    public void SetPath(List<Tile> path)
    {
        currentPath = path;
    }
    public override void ExecuteState()
    {
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex]) < 0.1f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count;
            pathfinder.RequestFindPath(currentTile, pathfinder.GetTile(waypoints[currentWaypointIndex]), brain.IsFlying(), SetPath);
        }
        string nodes = "";
        foreach (Tile t in currentPath)
        {
            nodes += t.ToString() + ";";
        }
        Debug.Log("Current path: " + nodes);
        Vector3 target = waypoints[currentWaypointIndex];
        Debug.Log("Im moving towards " + waypoints[currentWaypointIndex]);
        if (currentPath.Count > 0)
        {
            currentTile = currentPath[0];
            currentPath.Remove(currentTile);
            //check next tile
            bool isTargetStillOnPath = false;
            //check if player is still on the path
            foreach (Tile t in currentPath)
            {
                if (Vector3.Distance(t.GetWorldPosition(), target) < 0.01f)
                {
                    isTargetStillOnPath = true;
                }
            }
            //if not recalculate path
            if (!isTargetStillOnPath)
            {
                Debug.Log("Target was not on path, recalculating");
                pathfinder.RequestFindPath(currentTile, GridController.Instance.GetTileFromWorldPosition(target), brain.IsFlying(), SetPath);
            }
        }
        brain.Move(currentTile.GetWorldPosition());
        
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
