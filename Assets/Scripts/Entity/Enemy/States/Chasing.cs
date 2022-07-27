using Assets.Scripts.Entity;
using Assets.Scripts.Grid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chasing : State
{
    [SerializeField, Range(1,20)] private int maxDistance;

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
        string nodes = "";
        foreach(Tile t in currentPath)
        {
            nodes += t.ToString() + ";";
        }
        Debug.Log("Current path: " + nodes);
        Vector3 target = player.position;
        //target = player position
        //move towards player
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
        //if Player is within attack range -> change to attacking
        //if Player is out of chase range -> change to retreating
    }

    public int GetCurrentPathLength()
    {
        return currentPath.Count;
    }
}
