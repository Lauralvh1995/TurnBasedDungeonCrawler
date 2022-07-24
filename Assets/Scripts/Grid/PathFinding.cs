using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using Assets.Scripts.Grid;
using System.Collections;

namespace Assets.Scripts.Entity
{
    public class PathFinding : MonoBehaviour
    {
        public static PathFinding Instance { get; private set; }
        GridController grid;

        List<Tile> openSet;
        HashSet<Tile> closedSet;

        private void Awake()
        {
            Instance = this;
            grid = GridController.Instance;
        }

        public Tile GetTile(Vector3 position)
        {
            return grid.GetTileFromWorldPosition(position);
        }

        List<Tile> ReconstructPath(Tile end)
        {
            Debug.Log("Path Found!");
            List<Tile> path = new List<Tile>();
            path.Add(end);
            Tile current = end;
            while(current.CameFrom != null)
            {
                path.Prepend(current.CameFrom);
                current = current.CameFrom;
            }
            return path;
        }
        public List<Tile> FindPath(Tile start, Tile goal, bool flying)
        {
            grid.Regenerate();
            for (int x = 0; x < grid.GetGrid().Width; x++)
            {
                for (int y = 0; y < grid.GetGrid().Length; y++)
                {
                    for (int z = 0; z < grid.GetGrid().Height; z++)
                    {
                        Tile tile = grid.GetGrid().GetGridArray()[x, y, z];
                        tile.GCost = int.MaxValue;
                        tile.HCost = CalculateDistanceCost(tile, goal);
                        tile.FCost = tile.GCost + tile.HCost;
                        tile.CameFrom = null;
                    }
                }
            }
            start.GCost = 0;
            start.HCost = CalculateDistanceCost(start, goal);
            start.FCost = start.GCost + start.HCost;

            //create emtpy sets
            openSet = new List<Tile>();
            closedSet = new HashSet<Tile>();

            //add neighbours to openSet and add cameFrom values
            foreach (Tile t in GetNeighbours(start))
            {
                if(t != null)
                    openSet.Add(t);
            }
            closedSet.Add(start);
            while (openSet.Count > 0)
            {
                Tile current = GetLowestFCost(openSet);
                //if current == goal, return path
                if (current.Equals(goal))
                {
                    return ReconstructPath(current);
                }
                openSet.Remove(current);
                closedSet.Add(current);

                //debug visualisation
                foreach(Tile t in openSet)
                {
                    Debug.DrawLine(t.GetWorldPosition(), (t.GetWorldPosition() + (Vector3.up * 0.5f)), Color.green, 500f);
                }
                foreach (Tile t in closedSet)
                {
                    Debug.DrawLine(t.GetWorldPosition(), (t.GetWorldPosition() + (Vector3.up * 0.5f)), Color.green, 500f);
                }

                Debug.DrawLine(current.GetWorldPosition(), (current.GetWorldPosition() + (Vector3.up * 0.5f)), Color.cyan, 500f);
                

                //add all neighbours to openSet
                foreach (Tile t in GetNeighbours(current))
                {
                    if (t != null)
                    {
                        Debug.Log(t.ToString());
                        if (closedSet.Contains(t)) continue;

                        int tentativeGcost = current.GCost + t.HazardRating + CalculateDistanceCost(current, t); //all tiles are in manhattan distance, making weight 1 + hazard

                        if (tentativeGcost < t.GCost)
                        {
                            if (flying || t.Floor)
                            {
                                t.CameFrom = current;
                                t.GCost = tentativeGcost;
                                t.FCost = tentativeGcost + CalculateDistanceCost(t, goal);
                                if (!openSet.Contains(t))
                                    openSet.Add(t);
                            }
                        }
                    }
                }
            }
            //could not find a path, return empty path
            //TODO: add proper handling for not finding a path
            Debug.LogWarning("Could not find path!");
            return new List<Tile>();
        }

        private int CalculateDistanceCost(Tile start, Tile goal)
        {
            int xdist = Mathf.Abs(start.X - goal.X);
            int ydist = Mathf.Abs(start.Y - goal.Y);
            int zdist = Mathf.Abs(start.Z - goal.Z);

            return xdist + ydist + zdist;
        }

        private Tile GetLowestFCost(List<Tile> set)
        {
            Tile lowest = set[0];
            foreach(Tile tile in set)
            {
                if(tile.FCost < lowest.FCost)
                {
                    lowest = tile;
                }
            }
            return lowest;
        }

        private List<Tile> GetNeighbours(Tile tile)
        {
            List<Tile> neighbours = new List<Tile>();
            if (!tile.FrontWall)
            {
                if(tile.Z < grid.Length-1)
                    neighbours.Add(grid.GetGrid().GetGridArray()[tile.X, tile.Y, tile.Z + 1]);
            }
            if (!tile.BackWall)
            {
                if(tile.Z > 0)
                    neighbours.Add(grid.GetGrid().GetGridArray()[tile.X, tile.Y, tile.Z - 1]);
            }
            if (!tile.LeftWall)
            {
                if(tile.X > 0)
                    neighbours.Add(grid.GetGrid().GetGridArray()[tile.X - 1, tile.Y, tile.Z]);
            }
            if (!tile.RightWall)
            {
                if(tile.X < grid.Width-1)
                    neighbours.Add(grid.GetGrid().GetGridArray()[tile.X + 1, tile.Y, tile.Z]);
            }
            if (!tile.Ceiling)
            {
                if(tile.Y < grid.Height-1)
                    neighbours.Add(grid.GetGrid().GetGridArray()[tile.X, tile.Y + 1, tile.Z]);
            }
            if (!tile.Floor)
            {
                if(tile.Y > 0)
                    neighbours.Add(grid.GetGrid().GetGridArray()[tile.X, tile.Y - 1, tile.Z]);
            }
            return neighbours;
        }
    }
}
