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
        pathfinder.RequestFindPath(currentTile, GridController.Instance.GetTileFromWorldPosition(target),
            brain.IsFlying(), SetPath);
        if (currentPath.Count > 0)
        {
            currentTile = currentPath[0];
            currentPath.Remove(currentTile);
        }
        brain.Move(currentTile.GetWorldPosition());
        CheckTransitions();
    }

    private Vector3 MakeRandomMove()
    {
        return transform.position + randomDirections[Random.Range(0, randomDirections.Length)];
    }
}
