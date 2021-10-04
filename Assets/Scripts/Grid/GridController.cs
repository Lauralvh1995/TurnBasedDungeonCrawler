using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Grid
{
    public class GridController : MonoBehaviour
    {
        public static GridController Instance { get; private set; }
        [SerializeField, Range(1, 20)] int gridWidth = 10;
        [SerializeField, Range(1, 20)] int gridLength = 10;
        [SerializeField, Range(1, 10)] int gridHeight = 5;
        [SerializeField] private LayerMask groundMask;
        [SerializeField] private LayerMask entityMask;

        [SerializeField] private WaterLevel level;

        [SerializeField]
        Grid<Tile> grid;

        private void Awake()
        {
            Instance = this;
            grid = new Grid<Tile>(gridWidth, gridHeight, gridLength, transform.position, 1f);
            for (int x = 0; x < grid.GetGridArray().GetLength(0); x++)
            {
                for (int y = 0; y < grid.GetGridArray().GetLength(1); y++)
                {
                    for (int z = 0; z < grid.GetGridArray().GetLength(2); z++)
                    {
                        grid.GetGridArray()[x, y, z] = new Tile(grid);
                        grid.GetGridArray()[x, y, z].SetCoords(x, y, z);
                        grid.GetGridArray()[x, y, z].SetWorldPosition(grid.GetWorldPosition(x, y, z));
                        grid.GetGridArray()[x, y, z].CheckOccupation(grid.GetWorldPosition(x, y, z), groundMask, entityMask);

                        if(y <= level.GetCurrentLevel())
                        {
                            Debug.Log(grid.GetGridArray()[x, y, z].ToString() + "should be flooded");
                            grid.GetGridArray()[x, y, z].SetFlooded(true);
                        }
                        else
                        {
                            grid.GetGridArray()[x, y, z].SetFlooded(false);
                        }
                    }
                }
            }
        }

        public void Regenerate()
        {
            grid = new Grid<Tile>(gridWidth, gridHeight, gridLength, transform.position, 1f);
            for (int x = 0; x < grid.GetGridArray().GetLength(0); x++)
            {
                for (int y = 0; y < grid.GetGridArray().GetLength(1); y++)
                {
                    for (int z = 0; z < grid.GetGridArray().GetLength(2); z++)
                    {
                        grid.GetGridArray()[x, y, z] = new Tile(grid);
                        grid.GetGridArray()[x, y, z].SetCoords(x, y, z);
                        grid.GetGridArray()[x, y, z].SetWorldPosition(grid.GetWorldPosition(x, y, z));
                        grid.GetGridArray()[x, y, z].CheckOccupation(grid.GetWorldPosition(x, y, z), groundMask, entityMask);
                        if(y <= level.GetCurrentLevel())
                        {
                            grid.GetGridArray()[x, y, z].SetFlooded(true);
                        }
                        else
                        {
                            grid.GetGridArray()[x, y, z].SetFlooded(false);
                        }
                    }
                }
            }
        }

        public void ChangeWaterLevel()
        {
            foreach(Tile t in grid.GetGridArray())
            {
                if(t.Y <= level.GetCurrentLevel())
                {
                    t.SetFlooded(true);
                    Debug.Log("Flooded " + t.ToString());
                }
                else
                {
                    t.SetFlooded(false);
                }
                UpdatePassability(t.GetWorldPosition());
            }
            //Regenerate();
        }

        public void UpdatePassability(Vector3 pos)
        {
            Tile tile = GetTileFromWorldPosition(pos);
            if (tile != null)
            {
                tile.CheckOccupation(pos, groundMask, entityMask);
                Debug.Log(tile.ToString());
                if (tile.Y <= level.GetCurrentLevel())
                {
                    tile.SetFlooded(true);
                }
                else
                {
                    tile.SetFlooded(false);
                }
                //tile.GetNeighbours();
            }
        }

        public Tile GetTileFromWorldPosition(Vector3 pos)
        {
            return grid.GetFromWorldPosition(pos);
        }

        public void GetCoords(Vector3 pos, out int x, out int y, out int z)
        {
            Tile tile = GetTileFromWorldPosition(pos);
            x = tile.X;
            y = tile.Y;
            z = tile.Z;
        }

        public Vector3 GetWorldPositionFromTile(Tile t)
        {
            return t.GetWorldPosition();
        }

        public bool CanMoveThere(Vector3 currentPos, Vector3 destination, bool isFlying)
        {
            //check if direction is blocked
            Vector3 direction = destination - currentPos;
            Tile currentTile = GetTileFromWorldPosition(currentPos);
            Tile destinationTile = GetTileFromWorldPosition(destination);
            if (destinationTile == null)
            {
                Debug.Log("No destination possible!");
                return false;
            }
            if(Physics.Raycast(currentPos,direction, 1f, groundMask))
            {
                Debug.Log("Hit a wall!");
                return false;
            }
            //check if destination tile is occupied or passable
            if (destinationTile.Occupied)
            {
                Debug.Log("Tile is occupied");
                return false;
            }
            if (destinationTile.Floor || isFlying)
            {
                return true;
            }
            else
            {
                Debug.Log("No floor");
                return false;
            }
        }

        private void OnDrawGizmos()
        {
            if(grid == null)
            {
                return;
            }
            Tile[,,] gridArray = grid.GetGridArray();
            for (int x = 0; x < gridArray.GetLength(0); x++)
            {
                for (int y = 0; y < gridArray.GetLength(1); y++)
                {
                    for (int z = 0; z < gridArray.GetLength(2); z++)
                    {
                        //Debug.Log("Tile at " + x + "," + y + "," + z + grid.GetGridArray()[x, y, z].ToString());
                        
                        grid?.GetGridArray()[x, y, z].DrawOccupationGizmos(grid.GetWorldPosition(x, y, z));
                    }
                }
            }
        }
    }
}