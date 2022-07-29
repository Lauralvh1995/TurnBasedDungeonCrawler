using Assets.Scripts.Entity;
using Assets.Scripts.Grid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chasing : State
{
    [SerializeField] private Transform player;

    PathFinderMaster pathfinder;
    [SerializeField] List<Tile> currentPath;
    Tile currentTile;
    public override void EnterState(EnemyBrain brain)
    {
        base.EnterState(brain);
        pathfinder = PathFinderMaster.GetInstance();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentTile = pathfinder.GetTile(transform.position);
        pathfinder.RequestFindPath(currentTile, pathfinder.GetTile(player.position), brain.IsFlying(), SetPath);
    }

    public void SetPath(List<Tile> path)
    {
        currentPath = path;
    }

    public override void ExecuteState()
    {
        Vector3 target = player.position;
        pathfinder.RequestFindPath(currentTile, GridController.Instance.GetTileFromWorldPosition(target), brain.IsFlying(), SetPath);
        //move towards player
        if (currentPath.Count > 0)
        {
            currentTile = currentPath[0];
            currentPath.Remove(currentTile);
        }
        brain.Move(currentTile.GetWorldPosition());
        CheckTransitions();

    }

    public Transform GetPlayer()
    {
        return player;
    }
}
