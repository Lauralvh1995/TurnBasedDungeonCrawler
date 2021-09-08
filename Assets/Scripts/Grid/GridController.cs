using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Grid
{
    [ExecuteAlways]
    public class GridController : MonoBehaviour
    {
        [SerializeField, Range(1, 20)] int gridWidth = 10;
        [SerializeField, Range(1, 20)] int gridLength = 10;
        [SerializeField, Range(1, 10)] int gridHeight = 5;
        [SerializeField] private LayerMask groundMask;
        [SerializeField] private LayerMask entityMask;

        [SerializeField]
        Grid<Tile> grid;
        private void Start()
        {
            
        }
        private void Update()
        {
            grid = new Grid<Tile>(gridWidth, gridHeight, gridLength, transform.position);
            for (int x = 0; x < grid.GetGridArray().GetLength(0); x++)
            {
                for (int y = 0; y < grid.GetGridArray().GetLength(1); y++)
                {
                    for (int z = 0; z < grid.GetGridArray().GetLength(2); z++)
                    {
                        grid.GetGridArray()[x, y, z] = new Tile();
                    }
                }
            }
        }

        private void OnDrawGizmos()
        {
            Tile[,,] gridArray = grid.GetGridArray();
            for (int x = 0; x < gridArray.GetLength(0); x++)
            {
                for (int y = 0; y < gridArray.GetLength(1); y++)
                {
                    for (int z = 0; z < gridArray.GetLength(2); z++)
                    {
                        gridArray[x, y, z].CheckOccupation(new Vector3(x, y, z), groundMask, entityMask);
                        gridArray[x, y, z].DrawOccupationGizmos(new Vector3(x,y,z));
                    }
                }
            }
        }
    }
}