using Assets.Scripts.Entity;
using Assets.Scripts.Grid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Wandering : State
{
    [SerializeField] Vector3[] randomDirections;

    [SerializeField] private State OnNoticePlayer;

    PathFinderMaster pathfinder;
    [SerializeField] List<Tile> currentPath;
    Tile currentTile;

    public override void EnterState(EnemyBrain brain)
    {
        base.EnterState(brain);
        pathfinder = PathFinderMaster.GetInstance();
        currentTile = pathfinder.GetTile(transform.position);
        pathfinder.RequestFindPath(currentTile, pathfinder.GetTile(MakeRandomMove()), brain.IsFlying(), SetPath);
    }

    public void SetPath(List<Tile> path)
    {
        currentPath = path;
    }

    public override void ExecuteState()
    {
        //make random move
        Vector3 target = MakeRandomMove();
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

    private Vector3 MakeRandomMove()
    {
        return randomDirections[Random.Range(0, randomDirections.Length)];
    }
}
