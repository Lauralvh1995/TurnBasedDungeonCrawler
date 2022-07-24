using Assets.Scripts.Entity;
using Assets.Scripts.Grid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Wandering : State
{
    [SerializeField] Vector3[] randomDirections;

    [SerializeField] private State OnNoticePlayer;

    PathFinding pathfinder;
    [SerializeField] List<Tile> currentPath;
    Tile nextTile;
    Tile currentTile;

    public override void EnterState(EnemyBrain brain)
    {
        base.EnterState(brain);
        pathfinder = PathFinding.Instance;
        currentTile = pathfinder.GetTile(transform.position);
        currentPath = pathfinder.FindPath(currentTile, pathfinder.GetTile(MakeRandomMove()), brain.IsFlying());
    }

    public override void ExecuteState()
    {
        string nodes = "";
        foreach (Tile t in currentPath)
        {
            nodes += t.ToString() + ";";
        }
        Debug.Log("Current path: " + nodes);
        //make random move
        Vector3 target = MakeRandomMove();
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
                currentPath = pathfinder.FindPath(nextTile, GridController.Instance.GetTileFromWorldPosition(target), brain.IsFlying());
            }
        }
        brain.Move(nextTile.GetWorldPosition());
        CheckTransitions();
    }

    private Vector3 MakeRandomMove()
    {
        return randomDirections[Random.Range(0, randomDirections.Length)];
    }
}
