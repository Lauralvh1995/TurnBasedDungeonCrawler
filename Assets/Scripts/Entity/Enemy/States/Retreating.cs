using Assets.Scripts.Entity;
using Assets.Scripts.Grid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Retreating : State
{
    [SerializeField] private Transform leashPoint;
    [SerializeField] float gizmoSize = 0.1f;

    PathFinding pathfinder;
    [SerializeField] List<Tile> currentPath;
    Tile nextTile;
    Tile currentTile;
    public override void EnterState(EnemyBrain brain, EntityActions actions)
    {
        base.EnterState(brain, actions);
        pathfinder = PathFinding.Instance;
        currentTile = pathfinder.GetTile(transform.position);
        currentPath = pathfinder.FindPath(currentTile, pathfinder.GetTile(leashPoint.position), brain.GetComponent<Enemy>().IsFlying());
    }
    public override void ExecuteState()
    {
        string nodes = "";
        foreach (Tile t in currentPath)
        {
            nodes += t.ToString() + ";";
        }
        Debug.Log("Current path: " + nodes);
        //make move towards leash point
        Vector3 target = leashPoint.position;
        if (currentPath.Count > 0)
        {
            currentTile = currentPath[0];
            currentPath.Remove(currentTile);
            if (currentPath.Count > 0)
                nextTile = currentPath[0];
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
                currentPath = pathfinder.FindPath(nextTile, GridController.Instance.GetTileFromWorldPosition(target), brain.GetComponent<Enemy>().IsFlying());
            }
        }
        brain.Move(nextTile.GetWorldPosition());
        CheckTransitions();
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(leashPoint.position, Vector3.one * gizmoSize);
    }
}
