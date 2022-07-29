using Assets.Scripts.Entity;
using Assets.Scripts.Grid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Retreating : State
{
    [SerializeField] private Transform leashPoint;
    [SerializeField] float gizmoSize = 0.1f;

    PathFinderMaster pathfinder;
    [SerializeField] List<Tile> currentPath;
    Tile currentTile;
    public override void EnterState(EnemyBrain brain)
    {
        base.EnterState(brain);
        pathfinder = PathFinderMaster.GetInstance();
        currentTile = pathfinder.GetTile(transform.position);
        pathfinder.RequestFindPath(currentTile, pathfinder.GetTile(leashPoint.position), brain.IsFlying(), SetPath);
    }

    public void SetPath(List<Tile> path)
    {
        currentPath = path;
    }
    public override void ExecuteState()
    {
        //make move towards leash point
        Vector3 target = leashPoint.position;
        if (currentPath.Count > 0)
        {
            currentTile = currentPath[0];
            currentPath.Remove(currentTile);
        }
        brain.Move(currentTile.GetWorldPosition());
        CheckTransitions();
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(leashPoint.position, Vector3.one * gizmoSize);
    }

    public Vector3 GetLeashPointLocation()
    {
        return leashPoint.position;
    }
}
